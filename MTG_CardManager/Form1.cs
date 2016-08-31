using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace MTG_CardManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private String ListToText(List<String> list)
        {
            String result = "";
            if (list == null)
                return "";
            for(int i = 0;i < list.Count;i++)
            {
                result += list[i] + " || ";
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MagicCard Card = MagicCardsInfo_WebReader.URLToMagicCard(textBox1.Text);
            pictureBox1.Image = Card.image;
            pictureBox1.Width = pictureBox1.Image.Width;

            lbl_Name.Text = "Name:\n" + Card.name;
            lbl_ruleText.Text = "RuleText:\n" + Card.ruleText;
            lbl_FlavorText.Text = "FlavorText:\n" + Card.flavorText;
            lbl_Types.Text = "Types:\n" + ListToText(Card.types); 
            lbl_Color.Text = "Color:\n" + Card.color;
            lbl_ManaCost.Text = "ManaCost:\n" + Card.manaCost;
            lbl_Power.Text = "Power:\n" + Card.power;
            lbl_toughness.Text = "Toughness:\n" + Card.toughness;
            lbl_convmanacost.Text = "ConvManaCost:\n" + Card.convertedManaCost.ToString();
            lbl_subtypes.Text = "SubTypes:\n" + ListToText(Card.subTypes);
            lbl_Rarity.Text = "Editions:\n" + Card.rarity;
        }

    }
}
