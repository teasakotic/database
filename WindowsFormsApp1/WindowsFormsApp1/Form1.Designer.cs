namespace WindowsFormsApp1
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
            this.kreiraj_tabelu = new System.Windows.Forms.Button();
            this.napuni_tabelu = new System.Windows.Forms.Button();
            this.izvrsi_upit = new System.Windows.Forms.Button();
            this.lista_upita = new System.Windows.Forms.ListBox();
            this.prikaz_upita = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // kreiraj_tabelu
            // 
            this.kreiraj_tabelu.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.kreiraj_tabelu.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.kreiraj_tabelu.Location = new System.Drawing.Point(114, 24);
            this.kreiraj_tabelu.Name = "kreiraj_tabelu";
            this.kreiraj_tabelu.Size = new System.Drawing.Size(125, 54);
            this.kreiraj_tabelu.TabIndex = 0;
            this.kreiraj_tabelu.Text = "Kreiraj tabelu";
            this.kreiraj_tabelu.UseVisualStyleBackColor = false;
            this.kreiraj_tabelu.Click += new System.EventHandler(this.kreiraj_tabelu_Click);
            // 
            // napuni_tabelu
            // 
            this.napuni_tabelu.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.napuni_tabelu.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.napuni_tabelu.Location = new System.Drawing.Point(411, 24);
            this.napuni_tabelu.Name = "napuni_tabelu";
            this.napuni_tabelu.Size = new System.Drawing.Size(121, 54);
            this.napuni_tabelu.TabIndex = 1;
            this.napuni_tabelu.Text = "Napuni tabelu";
            this.napuni_tabelu.UseVisualStyleBackColor = false;
            this.napuni_tabelu.Click += new System.EventHandler(this.napuni_tabelu_Click);
            // 
            // izvrsi_upit
            // 
            this.izvrsi_upit.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.izvrsi_upit.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.izvrsi_upit.Location = new System.Drawing.Point(713, 126);
            this.izvrsi_upit.Name = "izvrsi_upit";
            this.izvrsi_upit.Size = new System.Drawing.Size(138, 71);
            this.izvrsi_upit.TabIndex = 2;
            this.izvrsi_upit.Text = "Izvrsi upit";
            this.izvrsi_upit.UseVisualStyleBackColor = false;
            this.izvrsi_upit.Click += new System.EventHandler(this.izvrsi_upit_Click);
            // 
            // lista_upita
            // 
            this.lista_upita.BackColor = System.Drawing.SystemColors.Menu;
            this.lista_upita.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lista_upita.FormattingEnabled = true;
            this.lista_upita.Items.AddRange(new object[] {
            "1.Ispisati na kojoj lokaciji je najviše bilo uplata u 2018.-oj",
            "2.Ispisati koji je prosek starosti gostiju iz inostranstva",
            "3.Ispisati koja igra je najviše igrana od igara na stolu i koliko puta je tražena",
            "4.Ispisati koliko je zaradila kockarnice u Kragujevcu u 2016.-oj godini",
            "5.Ispisati koliko je zarađeno na pokeru na svim lokacijama",
            "6.Ispisati koliko je novca isplaćeno u februaru  2016. godine, a koliko u februru 2017. godine",
            "7.Ispisati godinu u kojoj je bilo najviše uplata",
            "8.Ispisati broj gostiju koji dolaze iz inostranstva i imaju preko 40 godina",
            "9.Ispisati kolike su isplate bile za elektronske igre u 2016.,2017.,2018. ",
            "10.Ispisati broj gostiju za svaku godinu između 2016. i 2018. godine u Nišu",
            "11.Ispisati koja igra je najvise igrana od elektronskih igara",
            "12.Ispisati ukupne uplate za sve vrste igara za leto 2016. i leto 2017. godine ",
            "13.Ispisati koliko je novca isplaćeno u periodu od 2016. do 2018. godine",
            "14.Ispisati koliko je puta koja igra korišćena od dodatnog sadržaja",
            "15.Ispisati lokaciju u kojoj je izvrseno najvise isplata i njihov broj",
            "16.Ispisati zaradu od pića po godini",
            "17.Ispisati koliko je gostiju bilo u 2016. a koliko u 2017.godini na lokaciji u Beogradu",
            "18.Ispisati koliko je ukupno zarađeno od elektronskih igara",
            "19.Ispisati elektronske igre koje igraju gosti preko 30 godina prema opadajucem redosledu i njihov broj uplata",
            "20.Ispisati kolike su isplate bile za igre na stolu u 2016.,2017.,2018. godini"});
            this.lista_upita.Location = new System.Drawing.Point(12, 102);
            this.lista_upita.Name = "lista_upita";
            this.lista_upita.Size = new System.Drawing.Size(665, 264);
            this.lista_upita.TabIndex = 3;
            this.lista_upita.SelectedIndexChanged += new System.EventHandler(this.lista_upita_SelectedIndexChanged);
            // 
            // prikaz_upita
            // 
            this.prikaz_upita.BackColor = System.Drawing.SystemColors.Menu;
            this.prikaz_upita.ForeColor = System.Drawing.SystemColors.MenuText;
            this.prikaz_upita.Location = new System.Drawing.Point(12, 406);
            this.prikaz_upita.Multiline = true;
            this.prikaz_upita.Name = "prikaz_upita";
            this.prikaz_upita.Size = new System.Drawing.Size(665, 92);
            this.prikaz_upita.TabIndex = 4;
            this.prikaz_upita.TextChanged += new System.EventHandler(this.prikaz_upita_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(883, 510);
            this.Controls.Add(this.prikaz_upita);
            this.Controls.Add(this.lista_upita);
            this.Controls.Add(this.izvrsi_upit);
            this.Controls.Add(this.napuni_tabelu);
            this.Controls.Add(this.kreiraj_tabelu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kreiraj_tabelu;
        private System.Windows.Forms.Button napuni_tabelu;
        private System.Windows.Forms.Button izvrsi_upit;
        private System.Windows.Forms.ListBox lista_upita;
        private System.Windows.Forms.TextBox prikaz_upita;
    }
}

