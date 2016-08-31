using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace MTG_CardManager
{
    static class MagicCardsInfo_WebReader
    {
        private static WebBrowser webBrowser;
        private static bool documentIsCompleted;

        //************************************************************************
        // Gets the html Part where the MagicCard informations are stored
        private static String GetMainBody(String html)
        {
            // Gets the beginning of the html part, where all the Information is
            String mainBody = html.Substring(html.IndexOf("<table border") + 1);
            mainBody = mainBody.Substring(mainBody.IndexOf("<table border") + 1);
            mainBody = mainBody.Substring(mainBody.IndexOf("<table border") + 1);
            // Cuts the not needed information at the end away
            mainBody = mainBody.Substring(0, mainBody.LastIndexOf("<table border"));

            return mainBody;
        }

        //************************************************************************
        // Gets the URL of the card image in the given html
        private static String GetCardImageURL(String mainBody)
        {
            String imageFlag = "<img src=\"http://magiccards.info/scans/";
            mainBody = mainBody.Substring(mainBody.IndexOf(imageFlag) + 10);
            mainBody = mainBody.Substring(0, mainBody.IndexOf("\""));
            return mainBody;
        }

        //************************************************************************
        // Gets the Name of the card 
        private static String GetCardName(String mainBody)
        {
            mainBody = mainBody.Substring(mainBody.IndexOf("<a href=") + 1);
            String cardName = CutOutString(mainBody, ">", "<");
            return cardName;
        }

        //************************************************************************
        // Gets the raw meta-information of the card 
        private static String GetCardRawMetaInformation(String mainBody)
        {
            return CutOutString(mainBody, "<p>", "</p>");
        }

        //************************************************************************
        // Returns an Array of Card-Types from the Meta-Information
        private static List<String> GetCardTypes(String metaInformation)
        {
            if (metaInformation.Contains("—"))
                metaInformation = metaInformation.Substring(0, metaInformation.IndexOf("—")).Trim();
            else if (metaInformation.Contains(","))
                metaInformation = metaInformation.Substring(0, metaInformation.IndexOf(",")).Trim();
            else if (metaInformation.Contains("\n"))
                metaInformation = metaInformation.Substring(0, metaInformation.IndexOf("\n")).Trim();

            List<String> cardTypes = new List<String>();
            while(metaInformation.Contains(" "))
            {
                cardTypes.Add(metaInformation.Substring(0, metaInformation.IndexOf(" ")));
                metaInformation = metaInformation.Substring(metaInformation.IndexOf(" ") + 1);
            }
            cardTypes.Add(metaInformation);

            return cardTypes;
        }

        //************************************************************************
        // Returns an Array of Sub-Types from the Meta-Information
        private static List<String> GetCardSubTypes(String metaInformation)
        {
            if (!metaInformation.Contains("—"))
                return null;
            if (metaInformation.Contains(","))
                metaInformation = CutOutString(metaInformation, "—", ",");
            else if (metaInformation.Contains("\n"))
                metaInformation = CutOutString(metaInformation, "—", "\n");
            List<String> cardSubTypes = new List<String>();

            String pattern = "[^\\d/\\* ]+";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(metaInformation);
            while (match.Success)
            {
                cardSubTypes.Add(match.Value);
                match = match.NextMatch();
            }

            return cardSubTypes;
        }

        //************************************************************************
        // Returns the power of the card
        private static String GetCardPower(String metaInformation)
        {
            if (metaInformation.Contains(","))
                metaInformation = CutOutString(metaInformation, "—", ",");
            else if (metaInformation.Contains("\n"))
                metaInformation = CutOutString(metaInformation, "—", "\n");
            metaInformation = metaInformation.Substring(metaInformation.LastIndexOf(" ") + 1);
            if (!metaInformation.Contains("/"))
                return null;
            String power = metaInformation.Substring(0, metaInformation.IndexOf("/"));

            return power;
        }

        //************************************************************************
        // Returns the toughness of the card
        private static String GetCardToughness(String metaInformation)
        {
            if (metaInformation.Contains(","))
                metaInformation = CutOutString(metaInformation, "—", ",");
            else if (metaInformation.Contains("\n"))
                metaInformation = CutOutString(metaInformation, "—", "\n");
            metaInformation = metaInformation.Substring(metaInformation.LastIndexOf(" ") + 1);
            if (!metaInformation.Contains("/"))
                return null;
            return CutOutString(metaInformation, "/");
        }

        //************************************************************************
        // Returns the mana cost of the card
        private static String GetCardManaCost(String metaInformation)
        {
            metaInformation = CutOutString(metaInformation, "\n");
            if (!metaInformation.Contains("\n"))
                return "";
            return CutOutString(metaInformation, "", "(").Trim();
        }

        //************************************************************************
        // Returns the Index of a Search-Text with multiple Language options
        // The First Word in the Array must be the equal to the Original Word
        private static int MultiLanguageIndexOf(String searchString, String originalWord, String[] languageArray)
        {
            originalWord = originalWord.ToUpper();
            if (languageArray[0].ToUpper() == originalWord)
            {
                for (int i = 0; i < languageArray.Length; i++)
                {
                    String multiLanguageWord = languageArray[i].ToUpper();
                    int index = searchString.IndexOf(multiLanguageWord);
                    if (index >= 0)
                        return index;
                }
            }

            return -1;
        }

        //************************************************************************
        // Checks if the color Indicator holds the given color 
        // Checked Language in given order:
        //    English (Must be first)
        //    Deutsch
        //    Français 
        //    Italiano 
        //    Español
        //    Português 
        private static bool MultiLanguageIsColor(String colorIndicator, String englishColorName)
        {
            englishColorName = englishColorName.ToUpper();
            String[] whiteColorNames = { "White", "Weiß" , "Blanc", "Bianco", "Blanco", "Branco" };
            String[] blueColorNames = { "Blue", "Blau", "Bleu", "Blu", "Azul", "Azul" };
            String[] blackColorNames = { "Black", "Schwarz", "Noir", "Nero", "Negro", "Preto" };
            String[] redColorNames = { "Red", "Rot", "Rouge", "Rosso", "Rojo", "Vermelho" };
            String[] greenColorNames = { "Green", "Grün", "Vert", "Verde", "Verde", "Verde" };
            String[][] colorArrays = { whiteColorNames, blueColorNames, blackColorNames, redColorNames, greenColorNames };
            for(int i = 0;i < colorArrays.Length;i++)
            {
                String[] currentArray = colorArrays[i];
                if(currentArray[0].ToUpper() == englishColorName)
                {
                    return MultiLanguageIndexOf(colorIndicator, englishColorName, currentArray) >= 0;
                }
            }

            return false;
        }

        //************************************************************************
        // Returns the color of the card
        private static String GetCardColor(String metaInformation, String manaCost)
        {
            String color = "";
            if(metaInformation.Contains("(Color Indicator: "))
            {
                metaInformation = CutOutString(metaInformation, "(Color Indicator: ", ")").ToUpper();
                if (MultiLanguageIsColor(metaInformation, "White"))
                    color += "W";
                if (MultiLanguageIsColor(metaInformation, "Blue"))
                    color += "U";
                if (MultiLanguageIsColor(metaInformation, "Black"))
                    color += "B";
                if (MultiLanguageIsColor(metaInformation, "Red"))
                    color += "R";
                if (MultiLanguageIsColor(metaInformation, "Green"))
                    color += "G";
            }
            else
            {
                if (manaCost.Contains("W"))
                    color += "W";
                if (manaCost.Contains("U"))
                    color += "U";
                if (manaCost.Contains("B"))
                    color += "B";
                if (manaCost.Contains("R"))
                    color += "R";
                if (manaCost.Contains("G"))
                    color += "G";
            }
            return color;
        }

        //************************************************************************
        // Returns the rule text of the card
        private static String GetCardRuleText(String mainBody)
        {
            String ruleText = CutOutString(mainBody, "><b>", "</b></p>").Trim();
            ruleText = ruleText.Replace("<br>", "\n");
            return ruleText;
        }

        //************************************************************************
        // Returns the flavor text of the card
        private static String GetCardFlavorText(String mainBody)
        {
            String flavorText = CutOutString(mainBody, "><i>", "</i></p>").Trim();
            flavorText = flavorText.Replace("<br>", "\n");
            return flavorText;
        }

        //************************************************************************
        // Gets the raw extra-information of the card 
        private static String GetCardRawExtraInformation(String mainBody)
        {
            mainBody = CutOutString(mainBody, "<td");
            String extraInformation = CutOutString(mainBody, ">", "</td>");
            return extraInformation;
        }

        //************************************************************************
        // Creates a MagicCard Object out of an html Code from MagicCards.Info
        //************************************************************************
        public static MagicCard HTMLToMagicCard(String html)
        {
            if (html == "")
                throw new Exception("Empty HTML string");            

            String mainBody = GetMainBody(html);
            String imageUrl = GetCardImageURL(mainBody);
            String cardName = GetCardName(mainBody);
            // Meta-Information contains:
            //    Card-Type
            //    Sub-Type
            //    Power / Toughness 
            //    Mana-Cost
            //    Color Indicator
            String metaInformation = GetCardRawMetaInformation(mainBody);
            List<String> cardTypes = GetCardTypes(metaInformation);
            List<String> subTypes = GetCardSubTypes(metaInformation);
            String power = GetCardPower(metaInformation);
            String toughness = GetCardToughness(metaInformation);
            String manaCost = GetCardManaCost(metaInformation);
            String color = GetCardColor(metaInformation, manaCost);

            // Cuts the Meta-Information away, since it's no longer needed
            mainBody = CutOutString(mainBody, metaInformation);

            String ruleText = GetCardRuleText(mainBody);
            String flavorText = GetCardFlavorText(mainBody);

            // Extra-Information about other Version
            //    Other Part of a 2 Faced card
            //    Editions (Rarity)
            //    Names in other Languages
            String extraInformation = GetCardRawExtraInformation(mainBody);
            // Get the Link to the Other Part
            //MagicCard otherPart = GetCardOtherPart(extraInformation); // Not-Used jet 
            //String editionsRawData = GetCardEditionsRawData(extraInformation);
            //List<String> editionsWithRarity = GetCardEditionsWithRarity(editionsRawData);
            //String newestRarity = GetCardNewestRarity(editionsWithRarity);
            //String linkToNewestEdition = GetCardNewestEditionLink(editionsWithRarity);

            // Filling the Information into a MagicCard object
            MagicCard resultCard = new MagicCard();

            resultCard.name = cardName;
            resultCard.types = cardTypes;
            resultCard.subTypes = subTypes;
            resultCard.power = power;
            resultCard.toughness = toughness;
            resultCard.manaCost = manaCost;
            resultCard.color = color;
            resultCard.ruleText = ruleText;
            resultCard.flavorText = flavorText;
            resultCard.image = WebImageAsBitmap(imageUrl);
            return resultCard;
        }

        //************************************************************************
        // Creates a MagicCard Object out of an URL from MagicCards.Info
        public static MagicCard URLToMagicCard(String url)
        {
            String baseURL = "http://magiccards.info/";
            String edition = url.Replace(baseURL, "");
            edition = edition.Substring(0, edition.IndexOf("/"));

            String IDPart = url.Substring(url.LastIndexOf("/"));
            url = baseURL + edition + "/en" + IDPart;

            WaitForNavigate(url);
            return HTMLToMagicCard(webBrowser.DocumentText);
        }

        //************************************************************************
        // Fills the informations from an URL 
        private static void WaitForNavigate(String url)
        {
            // Use The Web-Browser to get around the 401 Authentication error
            if (webBrowser == null)
            {
                webBrowser = new WebBrowser();
                webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(WaitForDocumentCompleted);
            }
            documentIsCompleted = false;
            webBrowser.Navigate(url);
            // Wait for the document to be completly loaded
            while (!documentIsCompleted)
            {
                Application.DoEvents();
            }
        }

        //************************************************************************
        // Sets a flag when the Document is completely loaded
        private static void WaitForDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            documentIsCompleted = true;
        }

        //************************************************************************
        // Crops the given Bitmap by the Rectangle, where X/Y are the Offsets
        private static Bitmap CropImage(Bitmap source, Rectangle cropRectangle)
        { 
            Bitmap target = new Bitmap(cropRectangle.Width, cropRectangle.Height);
            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(source, new Rectangle(0, 0, target.Width, target.Height),
                                 cropRectangle,
                                 GraphicsUnit.Pixel);
            }
            return target;
        }

        //************************************************************************
        // Sets a flag when the Document is completely loaded
        private static Bitmap WebImageAsBitmap(String url)
        {
            WaitForNavigate(url);
            HtmlElementCollection images = webBrowser.Document.Images;
            if (images.Count == 1)
            {
                HtmlElement imageElement = images[0];
                Rectangle imageRectangle = imageElement.OffsetRectangle;
                // Set Bitmap Size (including the Offset) 
                Bitmap bitmap = new Bitmap(imageElement.ClientRectangle.Width + imageElement.OffsetRectangle.X,
                                        imageElement.ClientRectangle.Height + imageElement.OffsetRectangle.Y);

                // Set the Size of the Browser such the hole image can be captured
                Size webBrowserSize = new Size();
                webBrowserSize.Width = imageRectangle.Width + webBrowser.Size.Width;
                webBrowserSize.Height = imageRectangle.Height + +webBrowser.Size.Height;
                webBrowser.Size = webBrowserSize;
                // Include the Offset in the Width and Height
                imageRectangle.Width += imageRectangle.X;
                imageRectangle.Height += imageRectangle.Y;
                // Remove the offset, since the browser will always draw from his top left point
                imageRectangle.X = 0;
                imageRectangle.Y = 0;
                // Draws the Browser into the Bitmap
                webBrowser.DrawToBitmap(bitmap, imageRectangle);
                // Get the original Image
                bitmap = CropImage(bitmap, imageElement.OffsetRectangle);

                return bitmap;
            }
            throw new Exception("You can only load Image Pages");
        }

        //************************************************************************
        // Returns the string after a given string
        private static String CutOutString(String mainString, String startString)
        {
            int startPosition = mainString.IndexOf(startString) + startString.Length;
            return mainString.Substring(startPosition);
        }

        //************************************************************************
        // Returns the string between to given Strings
        private static String CutOutString(String mainString, String startString, String endString)
        {            
            mainString = CutOutString(mainString, startString);
            int endPosition = mainString.IndexOf(endString);
            return mainString.Substring(0, endPosition);
        }
    }
}
