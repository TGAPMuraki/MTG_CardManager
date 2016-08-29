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

        private void button1_Click(object sender, EventArgs e)
        {
            MagicCard Card = MagicCardsInfo_WebReader.URLToMagicCard("http://magiccards.info/shm/en/260.html");
            pictureBox1.ImageLocation = "http://magiccards.info/scans/en/shm/260.jpg";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {            
            HtmlElementCollection coll = webBrowser1.Document.Images;
            HtmlElement ele = null; 
            for (int i = 0; i < coll.Count; i++)
            {
                ele = coll[i];
            }
            
        }

        private void webBrowser1_ControlAdded(object sender, ControlEventArgs e)
        {
            MessageBox.Show(e.Control.Name);
        }

        private void webBrowser1_FileDownload(object sender, EventArgs e)
        {
            WebBrowser wb = (WebBrowser)sender;
        }
    }
}
