namespace Saving_Web_Page_to_PNG_Image
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripAddress = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripUpload = new System.Windows.Forms.ToolStripButton();
            this.browserView = new DotNetBrowser.WinForms.WinFormsBrowserView();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripAddress,
            this.toolStripUpload});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(852, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(77, 22);
            this.toolStripLabel1.Text = "Enter address";
            // 
            // toolStripAddress
            // 
            this.toolStripAddress.Name = "toolStripAddress";
            this.toolStripAddress.Size = new System.Drawing.Size(500, 25);
            this.toolStripAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripAddress_KeyDown);
            // 
            // toolStripUpload
            // 
            this.toolStripUpload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripUpload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripUpload.Image")));
            this.toolStripUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripUpload.Name = "toolStripUpload";
            this.toolStripUpload.Size = new System.Drawing.Size(37, 22);
            this.toolStripUpload.Text = "Load";
            this.toolStripUpload.ToolTipText = "Load";
            this.toolStripUpload.Click += new System.EventHandler(this.toolStripUpload_Click);
            // 
            // browserView
            // 
            this.browserView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserView.Location = new System.Drawing.Point(0, 25);
            this.browserView.Name = "browserView";
            this.browserView.Size = new System.Drawing.Size(852, 444);
            this.browserView.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 469);
            this.Controls.Add(this.browserView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripAddress;
        private System.Windows.Forms.ToolStripButton toolStripUpload;
        private DotNetBrowser.WinForms.WinFormsBrowserView browserView;
    }
}

