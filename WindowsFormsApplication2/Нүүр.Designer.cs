namespace WindowsFormsApplication2
{
    partial class Нүүр
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Нүүр));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.хэрэглэгчийнМэдээлэлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.системToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тусламжToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.буцахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.хэрэглэгчийнМэдээлэлToolStripMenuItem,
            this.системToolStripMenuItem,
            this.тусламжToolStripMenuItem,
            this.буцахToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(470, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // хэрэглэгчийнМэдээлэлToolStripMenuItem
            // 
            this.хэрэглэгчийнМэдээлэлToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("хэрэглэгчийнМэдээлэлToolStripMenuItem.Image")));
            this.хэрэглэгчийнМэдээлэлToolStripMenuItem.Name = "хэрэглэгчийнМэдээлэлToolStripMenuItem";
            this.хэрэглэгчийнМэдээлэлToolStripMenuItem.Size = new System.Drawing.Size(171, 20);
            this.хэрэглэгчийнМэдээлэлToolStripMenuItem.Text = "Хэрэглэгчийн мэдээлэл ";
            this.хэрэглэгчийнМэдээлэлToolStripMenuItem.Click += new System.EventHandler(this.хэрэглэгчийнМэдээлэлToolStripMenuItem_Click);
            // 
            // системToolStripMenuItem
            // 
            this.системToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("системToolStripMenuItem.Image")));
            this.системToolStripMenuItem.Name = "системToolStripMenuItem";
            this.системToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
            this.системToolStripMenuItem.Text = "Системээс  гарах";
            this.системToolStripMenuItem.Click += new System.EventHandler(this.системToolStripMenuItem_Click);
            // 
            // тусламжToolStripMenuItem
            // 
            this.тусламжToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("тусламжToolStripMenuItem.Image")));
            this.тусламжToolStripMenuItem.Name = "тусламжToolStripMenuItem";
            this.тусламжToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.тусламжToolStripMenuItem.Text = "  Буцах";
            this.тусламжToolStripMenuItem.Click += new System.EventHandler(this.тусламжToolStripMenuItem_Click);
            // 
            // буцахToolStripMenuItem
            // 
            this.буцахToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("буцахToolStripMenuItem.Image")));
            this.буцахToolStripMenuItem.Name = "буцахToolStripMenuItem";
            this.буцахToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.буцахToolStripMenuItem.Text = "Тусламж";
            this.буцахToolStripMenuItem.Click += new System.EventHandler(this.буцахToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Awicons-Vista-Artistic-Delete.ico");
            this.imageList1.Images.SetKeyName(1, "Custom-Icon-Design-Flatastic-1-Back.ico");
            this.imageList1.Images.SetKeyName(2, "Oxygen-Icons.org-Oxygen-Places-user-identity.ico");
            this.imageList1.Images.SetKeyName(3, "Tatice-Cristal-Intense-FAQ.ico");
            // 
            // button1
            // 
            this.button1.ImageKey = "(none)";
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(15, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Хэрэглэгч нэмэх";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(108, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 46);
            this.button2.TabIndex = 2;
            this.button2.Text = "Хэрэглэгч хасах";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(201, 119);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 46);
            this.button3.TabIndex = 3;
            this.button3.Text = "Хэрэглэгч өөрчлөх";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(293, 119);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 46);
            this.button4.TabIndex = 4;
            this.button4.Text = "Эрх олгох";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(386, 119);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 46);
            this.button5.TabIndex = 5;
            this.button5.Text = "Тайлан";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Нүүр
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 247);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Нүүр";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Нүүр";
            this.Load += new System.EventHandler(this.Нүүр_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem хэрэглэгчийнМэдээлэлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem системToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тусламжToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem буцахToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}