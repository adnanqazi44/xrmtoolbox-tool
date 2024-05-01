namespace MSToolByAdn
{
    partial class MyPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSample = new System.Windows.Forms.ToolStripButton();
            this.LoadSolutionButton = new System.Windows.Forms.Button();
            this.DirectoryTextBox = new System.Windows.Forms.TextBox();
            this.DirectoryButton = new System.Windows.Forms.Button();
            this.ExtractSolutionButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ExportResultButton = new System.Windows.Forms.Button();
            this.SearchKeywordTextBox = new System.Windows.Forms.TextBox();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.SolutionComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsbSample});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(826, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(86, 22);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSample
            // 
            this.tsbSample.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSample.Name = "tsbSample";
            this.tsbSample.Size = new System.Drawing.Size(46, 22);
            this.tsbSample.Text = "Try me";
            this.tsbSample.Click += new System.EventHandler(this.tsbSample_Click);
            // 
            // LoadSolutionButton
            // 
            this.LoadSolutionButton.Location = new System.Drawing.Point(3, 29);
            this.LoadSolutionButton.Name = "LoadSolutionButton";
            this.LoadSolutionButton.Size = new System.Drawing.Size(93, 23);
            this.LoadSolutionButton.TabIndex = 5;
            this.LoadSolutionButton.Text = "Load Solution";
            this.LoadSolutionButton.UseVisualStyleBackColor = true;
            this.LoadSolutionButton.Click += new System.EventHandler(this.LoadSolutionButton_Click);
            // 
            // DirectoryTextBox
            // 
            this.DirectoryTextBox.Location = new System.Drawing.Point(100, 118);
            this.DirectoryTextBox.Name = "DirectoryTextBox";
            this.DirectoryTextBox.Size = new System.Drawing.Size(193, 20);
            this.DirectoryTextBox.TabIndex = 0;
            // 
            // DirectoryButton
            // 
            this.DirectoryButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectoryButton.Location = new System.Drawing.Point(295, 117);
            this.DirectoryButton.Name = "DirectoryButton";
            this.DirectoryButton.Size = new System.Drawing.Size(25, 23);
            this.DirectoryButton.TabIndex = 6;
            this.DirectoryButton.Text = "...";
            this.DirectoryButton.UseVisualStyleBackColor = true;
            this.DirectoryButton.Click += new System.EventHandler(this.DirectoryButton_Click);
            // 
            // ExtractSolutionButton
            // 
            this.ExtractSolutionButton.Location = new System.Drawing.Point(3, 149);
            this.ExtractSolutionButton.Name = "ExtractSolutionButton";
            this.ExtractSolutionButton.Size = new System.Drawing.Size(93, 23);
            this.ExtractSolutionButton.TabIndex = 7;
            this.ExtractSolutionButton.Text = "Extract Solution";
            this.ExtractSolutionButton.UseVisualStyleBackColor = true;
            this.ExtractSolutionButton.Click += new System.EventHandler(this.ExtractSolutionButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(3, 221);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 8;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ExportResultButton
            // 
            this.ExportResultButton.Location = new System.Drawing.Point(349, 221);
            this.ExportResultButton.Name = "ExportResultButton";
            this.ExportResultButton.Size = new System.Drawing.Size(78, 23);
            this.ExportResultButton.TabIndex = 9;
            this.ExportResultButton.Text = "Export Result";
            this.ExportResultButton.UseVisualStyleBackColor = true;
            this.ExportResultButton.Click += new System.EventHandler(this.ExportResultButton_Click);
            // 
            // SearchKeywordTextBox
            // 
            this.SearchKeywordTextBox.Location = new System.Drawing.Point(100, 185);
            this.SearchKeywordTextBox.Name = "SearchKeywordTextBox";
            this.SearchKeywordTextBox.Size = new System.Drawing.Size(193, 20);
            this.SearchKeywordTextBox.TabIndex = 10;
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(3, 250);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(424, 186);
            this.ResultTextBox.TabIndex = 11;
            // 
            // SolutionComboBox
            // 
            this.SolutionComboBox.FormattingEnabled = true;
            this.SolutionComboBox.Location = new System.Drawing.Point(100, 69);
            this.SolutionComboBox.Name = "SolutionComboBox";
            this.SolutionComboBox.Size = new System.Drawing.Size(220, 21);
            this.SolutionComboBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Select Solution";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Extract Solution to";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Keyword to Search";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(0, 442);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 16;
            this.ClearButton.Text = "Clear Result";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SolutionComboBox);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.SearchKeywordTextBox);
            this.Controls.Add(this.ExportResultButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.ExtractSolutionButton);
            this.Controls.Add(this.DirectoryButton);
            this.Controls.Add(this.DirectoryTextBox);
            this.Controls.Add(this.LoadSolutionButton);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(826, 465);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbSample;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.Button LoadSolutionButton;
        private System.Windows.Forms.TextBox DirectoryTextBox;
        private System.Windows.Forms.Button DirectoryButton;
        private System.Windows.Forms.Button ExtractSolutionButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button ExportResultButton;
        private System.Windows.Forms.TextBox SearchKeywordTextBox;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.ComboBox SolutionComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ClearButton;
    }
}
