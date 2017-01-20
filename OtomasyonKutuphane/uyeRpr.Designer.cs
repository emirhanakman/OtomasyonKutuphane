namespace OtomasyonKutuphane
{
    partial class uyeRpr
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.uyelerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kutuphaneDBDataSet = new OtomasyonKutuphane.kutuphaneDBDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.uyelerTableAdapter = new OtomasyonKutuphane.kutuphaneDBDataSetTableAdapters.uyelerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.uyelerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kutuphaneDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // uyelerBindingSource
            // 
            this.uyelerBindingSource.DataMember = "uyeler";
            this.uyelerBindingSource.DataSource = this.kutuphaneDBDataSet;
            // 
            // kutuphaneDBDataSet
            // 
            this.kutuphaneDBDataSet.DataSetName = "kutuphaneDBDataSet";
            this.kutuphaneDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uyelerBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OtomasyonKutuphane.Report6.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 13);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(875, 476);
            this.reportViewer1.TabIndex = 0;
            // 
            // uyelerTableAdapter
            // 
            this.uyelerTableAdapter.ClearBeforeFill = true;
            // 
            // uyeRpr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(900, 404);
            this.Controls.Add(this.reportViewer1);
            this.Name = "uyeRpr";
            this.Text = "Üye Listesi Rapor";
            this.Load += new System.EventHandler(this.uyeRpr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uyelerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kutuphaneDBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uyelerBindingSource;
        private kutuphaneDBDataSet kutuphaneDBDataSet;
        private kutuphaneDBDataSetTableAdapters.uyelerTableAdapter uyelerTableAdapter;
    }
}