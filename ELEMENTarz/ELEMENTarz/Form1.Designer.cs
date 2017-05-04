namespace ELEMENTarz
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.search_btn = new System.Windows.Forms.Button();
            this.toSearch_tb = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.searchPage = new System.Windows.Forms.TabPage();
            this.shopsPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listOfShopsToSearch = new System.Windows.Forms.CheckedListBox();
            this.tabControl1.SuspendLayout();
            this.searchPage.SuspendLayout();
            this.shopsPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // search_btn
            // 
            this.search_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.search_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.search_btn.Location = new System.Drawing.Point(6, 269);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(95, 26);
            this.search_btn.TabIndex = 1;
            this.search_btn.Text = "Wyszukaj";
            this.search_btn.UseVisualStyleBackColor = true;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // toSearch_tb
            // 
            this.toSearch_tb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toSearch_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toSearch_tb.Location = new System.Drawing.Point(107, 270);
            this.toSearch_tb.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.toSearch_tb.Name = "toSearch_tb";
            this.toSearch_tb.Size = new System.Drawing.Size(539, 23);
            this.toSearch_tb.TabIndex = 2;
            this.toSearch_tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toSearch_tb_KeyDown);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(640, 228);
            this.flowLayoutPanel1.TabIndex = 5;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(6, 240);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(640, 23);
            this.progressBar.TabIndex = 6;
            this.progressBar.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.searchPage);
            this.tabControl1.Controls.Add(this.shopsPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 324);
            this.tabControl1.TabIndex = 7;
            // 
            // searchPage
            // 
            this.searchPage.Controls.Add(this.flowLayoutPanel1);
            this.searchPage.Controls.Add(this.progressBar);
            this.searchPage.Controls.Add(this.toSearch_tb);
            this.searchPage.Controls.Add(this.search_btn);
            this.searchPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.searchPage.Location = new System.Drawing.Point(4, 22);
            this.searchPage.Name = "searchPage";
            this.searchPage.Padding = new System.Windows.Forms.Padding(3);
            this.searchPage.Size = new System.Drawing.Size(652, 298);
            this.searchPage.TabIndex = 0;
            this.searchPage.Text = "     Wyszukiwanie     ";
            this.searchPage.UseVisualStyleBackColor = true;
            // 
            // shopsPage
            // 
            this.shopsPage.Controls.Add(this.groupBox1);
            this.shopsPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.shopsPage.Location = new System.Drawing.Point(4, 22);
            this.shopsPage.Name = "shopsPage";
            this.shopsPage.Padding = new System.Windows.Forms.Padding(3);
            this.shopsPage.Size = new System.Drawing.Size(652, 298);
            this.shopsPage.TabIndex = 1;
            this.shopsPage.Text = "     Sklepy     ";
            this.shopsPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listOfShopsToSearch);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 285);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista sklepów do przeszukania";
            // 
            // listOfShopsToSearch
            // 
            this.listOfShopsToSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listOfShopsToSearch.CheckOnClick = true;
            this.listOfShopsToSearch.FormattingEnabled = true;
            this.listOfShopsToSearch.Location = new System.Drawing.Point(7, 23);
            this.listOfShopsToSearch.MultiColumn = true;
            this.listOfShopsToSearch.Name = "listOfShopsToSearch";
            this.listOfShopsToSearch.Size = new System.Drawing.Size(626, 256);
            this.listOfShopsToSearch.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 337);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(700, 350);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.searchPage.ResumeLayout(false);
            this.searchPage.PerformLayout();
            this.shopsPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.TextBox toSearch_tb;
        //private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        //private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage searchPage;
        private System.Windows.Forms.TabPage shopsPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox listOfShopsToSearch;
    }
}

