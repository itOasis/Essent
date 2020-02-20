namespace Essent
{
    partial class frmMain
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
            this.btnCheckonDiskDelete = new System.Windows.Forms.Button();
            this.txtCheck = new System.Windows.Forms.TextBox();
            this.lsbErrors = new System.Windows.Forms.ListBox();
            this.btnExportErrors = new System.Windows.Forms.Button();
            this.btnZetopDisk = new System.Windows.Forms.Button();
            this.btnVoiceCheckandRemove = new System.Windows.Forms.Button();
            this.btnGetAllWAVenMP3 = new System.Windows.Forms.Button();
            this.btnUpdatePDF = new System.Windows.Forms.Button();
            this.btnOpenitems = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCheckonDiskDelete
            // 
            this.btnCheckonDiskDelete.Enabled = false;
            this.btnCheckonDiskDelete.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckonDiskDelete.Location = new System.Drawing.Point(36, 38);
            this.btnCheckonDiskDelete.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnCheckonDiskDelete.Name = "btnCheckonDiskDelete";
            this.btnCheckonDiskDelete.Size = new System.Drawing.Size(229, 57);
            this.btnCheckonDiskDelete.TabIndex = 0;
            this.btnCheckonDiskDelete.Text = "Check && Remove from Disk\r\nONLINE_OPZOEKINGEN";
            this.btnCheckonDiskDelete.UseVisualStyleBackColor = true;
            this.btnCheckonDiskDelete.Click += new System.EventHandler(this.btnCheckonDiskDelete_Click);
            // 
            // txtCheck
            // 
            this.txtCheck.Location = new System.Drawing.Point(36, 106);
            this.txtCheck.Multiline = true;
            this.txtCheck.Name = "txtCheck";
            this.txtCheck.Size = new System.Drawing.Size(447, 230);
            this.txtCheck.TabIndex = 1;
            // 
            // lsbErrors
            // 
            this.lsbErrors.FormattingEnabled = true;
            this.lsbErrors.ItemHeight = 33;
            this.lsbErrors.Location = new System.Drawing.Point(550, 12);
            this.lsbErrors.Name = "lsbErrors";
            this.lsbErrors.Size = new System.Drawing.Size(671, 433);
            this.lsbErrors.TabIndex = 2;
            // 
            // btnExportErrors
            // 
            this.btnExportErrors.Location = new System.Drawing.Point(657, 467);
            this.btnExportErrors.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnExportErrors.Name = "btnExportErrors";
            this.btnExportErrors.Size = new System.Drawing.Size(244, 46);
            this.btnExportErrors.TabIndex = 3;
            this.btnExportErrors.Text = "Export Errorlist";
            this.btnExportErrors.UseVisualStyleBackColor = true;
            this.btnExportErrors.Click += new System.EventHandler(this.btnExportErrors_Click);
            // 
            // btnZetopDisk
            // 
            this.btnZetopDisk.Enabled = false;
            this.btnZetopDisk.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZetopDisk.Location = new System.Drawing.Point(278, 30);
            this.btnZetopDisk.Name = "btnZetopDisk";
            this.btnZetopDisk.Size = new System.Drawing.Size(205, 65);
            this.btnZetopDisk.TabIndex = 4;
            this.btnZetopDisk.Text = "To Disk \r\nONLINE_OPZOEKINGEN";
            this.btnZetopDisk.UseVisualStyleBackColor = true;
            this.btnZetopDisk.Click += new System.EventHandler(this.btnZetopDisk_Click);
            // 
            // btnVoiceCheckandRemove
            // 
            this.btnVoiceCheckandRemove.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoiceCheckandRemove.Location = new System.Drawing.Point(36, 358);
            this.btnVoiceCheckandRemove.Name = "btnVoiceCheckandRemove";
            this.btnVoiceCheckandRemove.Size = new System.Drawing.Size(205, 65);
            this.btnVoiceCheckandRemove.TabIndex = 5;
            this.btnVoiceCheckandRemove.Text = "VOice check and remove Disk";
            this.btnVoiceCheckandRemove.UseVisualStyleBackColor = true;
            this.btnVoiceCheckandRemove.Click += new System.EventHandler(this.btnVoiceCheckandRemove_Click);
            // 
            // btnGetAllWAVenMP3
            // 
            this.btnGetAllWAVenMP3.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetAllWAVenMP3.Location = new System.Drawing.Point(36, 467);
            this.btnGetAllWAVenMP3.Name = "btnGetAllWAVenMP3";
            this.btnGetAllWAVenMP3.Size = new System.Drawing.Size(205, 65);
            this.btnGetAllWAVenMP3.TabIndex = 6;
            this.btnGetAllWAVenMP3.Text = "update Disk Items in DB";
            this.btnGetAllWAVenMP3.UseVisualStyleBackColor = true;
            this.btnGetAllWAVenMP3.Click += new System.EventHandler(this.btnGetAllWAVenMP3_Click);
            // 
            // btnUpdatePDF
            // 
            this.btnUpdatePDF.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePDF.Location = new System.Drawing.Point(296, 358);
            this.btnUpdatePDF.Name = "btnUpdatePDF";
            this.btnUpdatePDF.Size = new System.Drawing.Size(161, 72);
            this.btnUpdatePDF.TabIndex = 7;
            this.btnUpdatePDF.Text = "update PDF Disk Items in DB";
            this.btnUpdatePDF.UseVisualStyleBackColor = true;
            this.btnUpdatePDF.Click += new System.EventHandler(this.btnUpdatePDF_Click);
            // 
            // btnOpenitems
            // 
            this.btnOpenitems.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenitems.Location = new System.Drawing.Point(375, 466);
            this.btnOpenitems.Name = "btnOpenitems";
            this.btnOpenitems.Size = new System.Drawing.Size(161, 72);
            this.btnOpenitems.TabIndex = 8;
            this.btnOpenitems.Text = "update open items in DB";
            this.btnOpenitems.UseVisualStyleBackColor = true;
            this.btnOpenitems.Click += new System.EventHandler(this.btnOpenitems_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 550);
            this.Controls.Add(this.btnOpenitems);
            this.Controls.Add(this.btnUpdatePDF);
            this.Controls.Add(this.btnGetAllWAVenMP3);
            this.Controls.Add(this.btnVoiceCheckandRemove);
            this.Controls.Add(this.btnZetopDisk);
            this.Controls.Add(this.btnExportErrors);
            this.Controls.Add(this.lsbErrors);
            this.Controls.Add(this.txtCheck);
            this.Controls.Add(this.btnCheckonDiskDelete);
            this.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "frmMain";
            this.Text = "ESSENT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheckonDiskDelete;
        private System.Windows.Forms.TextBox txtCheck;
        private System.Windows.Forms.ListBox lsbErrors;
        private System.Windows.Forms.Button btnExportErrors;
        private System.Windows.Forms.Button btnZetopDisk;
        private System.Windows.Forms.Button btnVoiceCheckandRemove;
        private System.Windows.Forms.Button btnGetAllWAVenMP3;
        private System.Windows.Forms.Button btnUpdatePDF;
        private System.Windows.Forms.Button btnOpenitems;
    }
}

