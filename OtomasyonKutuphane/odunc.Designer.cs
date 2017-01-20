namespace OtomasyonKutuphane
{
    partial class odunc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(odunc));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.odID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kitapID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uyeTC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vTarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vSure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alKitAdedi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.odID,
            this.kitapID,
            this.perNO,
            this.uyeTC,
            this.vTarih,
            this.vSure,
            this.alKitAdedi,
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(12, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(790, 450);
            this.dataGridView1.TabIndex = 5;
            // 
            // odID
            // 
            this.odID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.odID.HeaderText = "Ödünç No";
            this.odID.Name = "odID";
            this.odID.ReadOnly = true;
            this.odID.Width = 75;
            // 
            // kitapID
            // 
            this.kitapID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kitapID.HeaderText = "Kitap Adı";
            this.kitapID.Name = "kitapID";
            this.kitapID.ReadOnly = true;
            // 
            // perNO
            // 
            this.perNO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.perNO.HeaderText = "Personel Adı";
            this.perNO.Name = "perNO";
            this.perNO.ReadOnly = true;
            this.perNO.Width = 84;
            // 
            // uyeTC
            // 
            this.uyeTC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.uyeTC.HeaderText = "Üye TC";
            this.uyeTC.Name = "uyeTC";
            this.uyeTC.ReadOnly = true;
            this.uyeTC.Width = 51;
            // 
            // vTarih
            // 
            this.vTarih.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.vTarih.HeaderText = "Veriliş Tarihi";
            this.vTarih.Name = "vTarih";
            this.vTarih.ReadOnly = true;
            this.vTarih.Width = 81;
            // 
            // vSure
            // 
            this.vSure.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.vSure.HeaderText = "Verilen Süre";
            this.vSure.Name = "vSure";
            this.vSure.ReadOnly = true;
            this.vSure.Width = 82;
            // 
            // alKitAdedi
            // 
            this.alKitAdedi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.alKitAdedi.HeaderText = "Alınan Kitap Adedi";
            this.alKitAdedi.Name = "alKitAdedi";
            this.alKitAdedi.ReadOnly = true;
            this.alKitAdedi.Width = 108;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Geçen Süre";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // odunc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(805, 464);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "odunc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ödünç Verilen Kitap Listesi";
            this.Load += new System.EventHandler(this.odunc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn odID;
        private System.Windows.Forms.DataGridViewTextBoxColumn kitapID;
        private System.Windows.Forms.DataGridViewTextBoxColumn perNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn uyeTC;
        private System.Windows.Forms.DataGridViewTextBoxColumn vTarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn vSure;
        private System.Windows.Forms.DataGridViewTextBoxColumn alKitAdedi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;

    }
}