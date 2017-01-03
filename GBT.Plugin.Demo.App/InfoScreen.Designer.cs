namespace GBT.Plugin.Demo.App
{
    partial class InfoScreen
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
            this.lytLists = new System.Windows.Forms.TableLayoutPanel();
            this.lstOnesInstance = new System.Windows.Forms.ListBox();
            this.lstOnes = new System.Windows.Forms.ListBox();
            this.lstTwos = new System.Windows.Forms.ListBox();
            this.lstTwosInstance = new System.Windows.Forms.ListBox();
            this.lytLists.SuspendLayout();
            this.SuspendLayout();
            // 
            // lytLists
            // 
            this.lytLists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lytLists.ColumnCount = 2;
            this.lytLists.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lytLists.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lytLists.Controls.Add(this.lstOnesInstance, 0, 1);
            this.lytLists.Controls.Add(this.lstOnes, 0, 0);
            this.lytLists.Controls.Add(this.lstTwos, 1, 0);
            this.lytLists.Controls.Add(this.lstTwosInstance, 1, 1);
            this.lytLists.Location = new System.Drawing.Point(12, 12);
            this.lytLists.Name = "lytLists";
            this.lytLists.RowCount = 2;
            this.lytLists.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lytLists.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lytLists.Size = new System.Drawing.Size(558, 286);
            this.lytLists.TabIndex = 2;
            // 
            // lstOnesInstance
            // 
            this.lstOnesInstance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstOnesInstance.FormattingEnabled = true;
            this.lstOnesInstance.Location = new System.Drawing.Point(3, 146);
            this.lstOnesInstance.Name = "lstOnesInstance";
            this.lstOnesInstance.Size = new System.Drawing.Size(273, 134);
            this.lstOnesInstance.TabIndex = 2;
            // 
            // lstOnes
            // 
            this.lstOnes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstOnes.FormattingEnabled = true;
            this.lstOnes.Location = new System.Drawing.Point(3, 3);
            this.lstOnes.Name = "lstOnes";
            this.lstOnes.Size = new System.Drawing.Size(273, 134);
            this.lstOnes.TabIndex = 1;
            // 
            // lstTwos
            // 
            this.lstTwos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTwos.FormattingEnabled = true;
            this.lstTwos.Location = new System.Drawing.Point(282, 3);
            this.lstTwos.Name = "lstTwos";
            this.lstTwos.Size = new System.Drawing.Size(273, 134);
            this.lstTwos.TabIndex = 3;
            // 
            // lstTwosInstance
            // 
            this.lstTwosInstance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTwosInstance.FormattingEnabled = true;
            this.lstTwosInstance.Location = new System.Drawing.Point(282, 146);
            this.lstTwosInstance.Name = "lstTwosInstance";
            this.lstTwosInstance.Size = new System.Drawing.Size(273, 134);
            this.lstTwosInstance.TabIndex = 4;
            // 
            // InfoScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 310);
            this.Controls.Add(this.lytLists);
            this.Name = "InfoScreen";
            this.Text = "PluginSharp Demo Application";
            this.lytLists.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel lytLists;
        private System.Windows.Forms.ListBox lstOnesInstance;
        private System.Windows.Forms.ListBox lstOnes;
        private System.Windows.Forms.ListBox lstTwos;
        private System.Windows.Forms.ListBox lstTwosInstance;
    }
}

