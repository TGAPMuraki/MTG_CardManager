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
            MagicCard Card = MagicCardsInfo_WebReader.URLToMagicCard(textBox1.Text);            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
            WebClient wc = new WebClient();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {            
            HtmlElementCollection coll = webBrowser1.Document.Images;
            HtmlElement ele = null; 
            for (int i = 0; i < coll.Count; i++)
            {
                ele = coll[i];
            }
            Bitmap bmp = new Bitmap(ele.ClientRectangle.Width + ele.OffsetRectangle.X, ele.ClientRectangle.Height + +ele.OffsetRectangle.Y);
            Rectangle imageRectangle = ele.ClientRectangle;

            if (textBox2.Text == "")
            {
                textBox2.Text = ele.OffsetRectangle.X.ToString();
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = ele.OffsetRectangle.Y.ToString();
            }

            imageRectangle.Width += Convert.ToInt32(textBox2.Text);
            imageRectangle.Height += Convert.ToInt32(textBox3.Text);

            webBrowser1.DrawToBitmap(bmp, imageRectangle);

            Rectangle cropRect = ele.OffsetRectangle;
            Bitmap src = bmp;
            Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height),
                                 cropRect,
                                 GraphicsUnit.Pixel);
            }

            pictureBox2.Image = target;
                        
            
        }

        private void webBrowser1_ControlAdded(object sender, ControlEventArgs e)
        {
            MessageBox.Show(e.Control.Name + "_1");
        }

        private void webBrowser1_FileDownload(object sender, EventArgs e)
        {
            WebBrowser wb = (WebBrowser)sender;            
        }
    }
}
