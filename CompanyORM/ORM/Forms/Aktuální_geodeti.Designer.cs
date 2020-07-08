namespace CompanyORM.ORM.Forms
{
    partial class Aktuální_geodeti
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
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Jmeno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Prijmeni = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Město = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ulice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PocetDokonceni = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Plat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(241, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(295, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Aktuálnie pracující geodeti";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Jmeno,
            this.Prijmeni,
            this.Město,
            this.Ulice,
            this.Email,
            this.PocetDokonceni,
            this.Plat});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(23, 134);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(765, 285);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = "ID:";
            // 
            // Jmeno
            // 
            this.Jmeno.Text = "Jmeno:";
            this.Jmeno.Width = 70;
            // 
            // Prijmeni
            // 
            this.Prijmeni.Text = "Příjmení";
            this.Prijmeni.Width = 86;
            // 
            // Město
            // 
            this.Město.Text = "Město:";
            this.Město.Width = 90;
            // 
            // Ulice
            // 
            this.Ulice.Text = "Ulice :";
            this.Ulice.Width = 109;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "zpět";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Email
            // 
            this.Email.Text = "Email:";
            this.Email.Width = 123;
            // 
            // PocetDokonceni
            // 
            this.PocetDokonceni.Text = "Dokončené zakázky";
            this.PocetDokonceni.Width = 136;
            // 
            // Plat
            // 
            this.Plat.Text = "Plat:";
            this.Plat.Width = 76;
            // 
            // Aktuální_geodeti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label2);
            this.Name = "Aktuální_geodeti";
            this.Text = "Aktuální_geodeti";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Jmeno;
        private System.Windows.Forms.ColumnHeader Prijmeni;
        private System.Windows.Forms.ColumnHeader Město;
        private System.Windows.Forms.ColumnHeader Ulice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader PocetDokonceni;
        private System.Windows.Forms.ColumnHeader Plat;
    }
}