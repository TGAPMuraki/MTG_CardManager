namespace MTG_CardManager
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_ruleText = new System.Windows.Forms.Label();
            this.lbl_FlavorText = new System.Windows.Forms.Label();
            this.lbl_ManaCost = new System.Windows.Forms.Label();
            this.lbl_Color = new System.Windows.Forms.Label();
            this.lbl_Types = new System.Windows.Forms.Label();
            this.lbl_editions = new System.Windows.Forms.Label();
            this.lbl_subtypes = new System.Windows.Forms.Label();
            this.lbl_convmanacost = new System.Windows.Forms.Label();
            this.lbl_toughness = new System.Windows.Forms.Label();
            this.lbl_Power = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(848, 554);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.webBrowser1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(840, 528);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(834, 522);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.FileDownload += new System.EventHandler(this.webBrowser1_FileDownload);
            this.webBrowser1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.webBrowser1_ControlAdded);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(840, 528);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 522);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(370, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(251, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "http://magiccards.info/shm/en/260.html";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(451, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(557, 12);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_editions);
            this.panel1.Controls.Add(this.lbl_subtypes);
            this.panel1.Controls.Add(this.lbl_convmanacost);
            this.panel1.Controls.Add(this.lbl_toughness);
            this.panel1.Controls.Add(this.lbl_Power);
            this.panel1.Controls.Add(this.lbl_ManaCost);
            this.panel1.Controls.Add(this.lbl_Color);
            this.panel1.Controls.Add(this.lbl_Types);
            this.panel1.Controls.Add(this.lbl_FlavorText);
            this.panel1.Controls.Add(this.lbl_ruleText);
            this.panel1.Controls.Add(this.lbl_Name);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(164, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 522);
            this.panel1.TabIndex = 1;
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Name.Location = new System.Drawing.Point(0, 0);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Padding = new System.Windows.Forms.Padding(5);
            this.lbl_Name.Size = new System.Drawing.Size(62, 28);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "Name:";
            // 
            // lbl_ruleText
            // 
            this.lbl_ruleText.AutoSize = true;
            this.lbl_ruleText.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_ruleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ruleText.Location = new System.Drawing.Point(0, 28);
            this.lbl_ruleText.Name = "lbl_ruleText";
            this.lbl_ruleText.Padding = new System.Windows.Forms.Padding(5);
            this.lbl_ruleText.Size = new System.Drawing.Size(80, 28);
            this.lbl_ruleText.TabIndex = 1;
            this.lbl_ruleText.Text = "RuleText:";
            // 
            // lbl_FlavorText
            // 
            this.lbl_FlavorText.AutoSize = true;
            this.lbl_FlavorText.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_FlavorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FlavorText.Location = new System.Drawing.Point(0, 56);
            this.lbl_FlavorText.Name = "lbl_FlavorText";
            this.lbl_FlavorText.Padding = new System.Windows.Forms.Padding(5);
            this.lbl_FlavorText.Size = new System.Drawing.Size(91, 28);
            this.lbl_FlavorText.TabIndex = 2;
            this.lbl_FlavorText.Text = "FlavorText:";
            // 
            // lbl_ManaCost
            // 
            this.lbl_ManaCost.AutoSize = true;
            this.lbl_ManaCost.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_ManaCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ManaCost.Location = new System.Drawing.Point(0, 140);
            this.lbl_ManaCost.Name = "lbl_ManaCost";
            this.lbl_ManaCost.Padding = new System.Windows.Forms.Padding(5);
            this.lbl_ManaCost.Size = new System.Drawing.Size(91, 28);
            this.lbl_ManaCost.TabIndex = 5;
            this.lbl_ManaCost.Text = "ManaCost:";
            // 
            // lbl_Color
            // 
            this.lbl_Color.AutoSize = true;
            this.lbl_Color.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Color.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Color.Location = new System.Drawing.Point(0, 112);
            this.lbl_Color.Name = "lbl_Color";
            this.lbl_Color.Padding = new System.Windows.Forms.Padding(5);
            this.lbl_Color.Size = new System.Drawing.Size(59, 28);
            this.lbl_Color.TabIndex = 4;
            this.lbl_Color.Text = "Color:";
            // 
            // lbl_Types
            // 
            this.lbl_Types.AutoSize = true;
            this.lbl_Types.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Types.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Types.Location = new System.Drawing.Point(0, 84);
            this.lbl_Types.Name = "lbl_Types";
            this.lbl_Types.Padding = new System.Windows.Forms.Padding(5);
            this.lbl_Types.Size = new System.Drawing.Size(62, 28);
            this.lbl_Types.TabIndex = 3;
            this.lbl_Types.Text = "Types:";
            // 
            // lbl_editions
            // 
            this.lbl_editions.AutoSize = true;
            this.lbl_editions.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_editions.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_editions.Location = new System.Drawing.Point(0, 280);
            this.lbl_editions.Name = "lbl_editions";
            this.lbl_editions.Padding = new System.Windows.Forms.Padding(5);
            this.lbl_editions.Size = new System.Drawing.Size(75, 28);
            this.lbl_editions.TabIndex = 10;
            this.lbl_editions.Text = "Editions:";
            // 
            // lbl_subtypes
            // 
            this.lbl_subtypes.AutoSize = true;
            this.lbl_subtypes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_subtypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_subtypes.Location = new System.Drawing.Point(0, 252);
            this.lbl_subtypes.Name = "lbl_subtypes";
            this.lbl_subtypes.Padding = new System.Windows.Forms.Padding(5);
            this.lbl_subtypes.Size = new System.Drawing.Size(86, 28);
            this.lbl_subtypes.TabIndex = 9;
            this.lbl_subtypes.Text = "subTypes:";
            // 
            // lbl_convmanacost
            // 
            this.lbl_convmanacost.AutoSize = true;
            this.lbl_convmanacost.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_convmanacost.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_convmanacost.Location = new System.Drawing.Point(0, 224);
            this.lbl_convmanacost.Name = "lbl_convmanacost";
            this.lbl_convmanacost.Padding = new System.Windows.Forms.Padding(5);
            this.lbl_convmanacost.Size = new System.Drawing.Size(156, 28);
            this.lbl_convmanacost.TabIndex = 8;
            this.lbl_convmanacost.Text = "convertedManaCost:";
            // 
            // lbl_toughness
            // 
            this.lbl_toughness.AutoSize = true;
            this.lbl_toughness.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_toughness.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_toughness.Location = new System.Drawing.Point(0, 196);
            this.lbl_toughness.Name = "lbl_toughness";
            this.lbl_toughness.Padding = new System.Windows.Forms.Padding(5);
            this.lbl_toughness.Size = new System.Drawing.Size(96, 28);
            this.lbl_toughness.TabIndex = 7;
            this.lbl_toughness.Text = "Toughness:";
            // 
            // lbl_Power
            // 
            this.lbl_Power.AutoSize = true;
            this.lbl_Power.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Power.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Power.Location = new System.Drawing.Point(0, 168);
            this.lbl_Power.Name = "lbl_Power";
            this.lbl_Power.Padding = new System.Windows.Forms.Padding(5);
            this.lbl_Power.Size = new System.Drawing.Size(65, 28);
            this.lbl_Power.TabIndex = 6;
            this.lbl_Power.Text = "Power:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 605);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_FlavorText;
        private System.Windows.Forms.Label lbl_ruleText;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_editions;
        private System.Windows.Forms.Label lbl_subtypes;
        private System.Windows.Forms.Label lbl_convmanacost;
        private System.Windows.Forms.Label lbl_toughness;
        private System.Windows.Forms.Label lbl_Power;
        private System.Windows.Forms.Label lbl_ManaCost;
        private System.Windows.Forms.Label lbl_Color;
        private System.Windows.Forms.Label lbl_Types;
    }
}

