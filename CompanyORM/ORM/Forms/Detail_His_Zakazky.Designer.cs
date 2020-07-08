namespace CompanyORM.ORM.Forms
{
    partial class Detail_His_Zakazky
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DatumOd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DatumDo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Typ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Objednavatel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Geodet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cena = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.DatumOd,
            this.DatumDo,
            this.Typ,
            this.Objednavatel,
            this.Geodet,
            this.Cena});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(1, 86);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(798, 215);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id:";
            this.columnHeader1.Width = 81;
            // 
            // DatumOd
            // 
            this.DatumOd.Text = "Datum Od:";
            this.DatumOd.Width = 93;
            // 
            // DatumDo
            // 
            this.DatumDo.Text = "Datum Do:";
            this.DatumDo.Width = 94;
            // 
            // Typ
            // 
            this.Typ.Text = "Typ zakázky";
            this.Typ.Width = 141;
            // 
            // Objednavatel
            // 
            this.Objednavatel.Text = "Objednavatel:";
            this.Objednavatel.Width = 173;
            // 
            // Geodet
            // 
            this.Geodet.Text = "Geodet:";
            this.Geodet.Width = 178;
            // 
            // Cena
            // 
            this.Cena.Text = "Cena\"";
            this.Cena.Width = 106;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(336, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(266, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Detail vybrané zakázky";
            // 
            // Detail_His_Zakazky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Name = "Detail_His_Zakazky";
            this.Text = "Detail_His_Zakazky";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader DatumOd;
        private System.Windows.Forms.ColumnHeader DatumDo;
        private System.Windows.Forms.ColumnHeader Typ;
        private System.Windows.Forms.ColumnHeader Objednavatel;
        private System.Windows.Forms.ColumnHeader Geodet;
        private System.Windows.Forms.ColumnHeader Cena;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}