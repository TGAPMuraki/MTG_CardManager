using System;
using System.Windows.Forms;
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
        private static bool documentIsCompleted;
        private static String html;
        private static Stream stream;

        //************************************************************************
        // Gets the html Part where the MagicCard informations are stored
        private static String GetMainBody(String html)
        {
            // Gets the beginning of the html part, where all the Information is
            String mainBody = html.Substring(html.IndexOf("<table border") + 1);
            mainBody = mainBody.Substring(mainBody.IndexOf("<table border") + 1);
            mainBody = mainBody.Substring(mainBody.IndexOf("<table border") + 1);
            // Cuts the not needed information away
            mainBody = mainBody.Substring(0, mainBody.LastIndexOf("<table border"));

            return mainBody;
        }

        // Gets the URL of the card image in the given html
        public static String GetCardImageURL(String mainBody)
        {
            String imageFlag = "<img src=\"http://magiccards.info/scans/";
            mainBody = mainBody.Substring(mainBody.IndexOf(imageFlag) + 10);
            mainBody = mainBody.Substring(0, mainBody.IndexOf("\""));
            return mainBody;
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

            mainBody = mainBody.Substring(0, mainBody.IndexOf("<td valign"));

            // Filling the Information into a MagicCard object
            MagicCard resultCard = new MagicCard();            

            GetInformationFromURL(imageUrl);
            resultCard.test = stream;
            /*
            using (MemoryStream memoryStream = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(resultCard.image, 0, resultCard.image.Length)) > 0)
                {
                    memoryStream.Write(resultCard.image, 0, read);
                }
            }
            */
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

            GetInformationFromURL(url);
            return HTMLToMagicCard(html);
        }

        //************************************************************************
        // Fills the informations from an URL 
        private static void GetInformationFromURL(String url)
        {
            // Use The Web-Browser to get around the 401 Authentication error
            WebBrowser webBrowser = new WebBrowser();
            documentIsCompleted = false;
            webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(WaitForDocumentCompleted);
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
            WebBrowser webBrowser = ((WebBrowser)sender);            
            html = webBrowser.DocumentText;
            stream = webBrowser.DocumentStream;
            HtmlElementCollection coll = webBrowser.Document.Images;//webBrowser.Document.GetElementsByTagName("img");
            for (int i = 0; i < coll.Count; i++)
            {
                HtmlElement ele = coll[i];
            }

            HtmlDocument doc = webBrowser.Document;

            documentIsCompleted = true;
        }
    }
}
