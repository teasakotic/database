using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private string run(string query)
        {

            if(query == "")
            {
                return ("Niste uneli unos");
            }

            string konekcija = "datasource=localhost;port=3306;username=root;password=;database=baza1";

            MySqlConnection db = new MySqlConnection(konekcija);

            MySqlCommand dbc = new MySqlCommand(query,db);
            dbc.CommandTimeout = 60;
            try
            {

                db.Open();

                if(!query.Substring(0,query.IndexOf(" ")).Equals("SELECT"))
                {
                    dbc.ExecuteNonQuery();
                    return "";
                }



                MySqlDataReader reader = dbc.ExecuteReader();
                if (reader.HasRows)
                {
                    StringBuilder sb = new StringBuilder();
                    while (reader.Read())
                    {
                        for(int i = 0;i < reader.FieldCount; i++){
                            sb.Append(reader.GetString(i));
                            sb.Append(" ");
                        }
                        sb.Append("\n");
                    }
                    return sb.ToString();
                }
                db.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return "";
        }

        private void kreiraj_tabelu_Click(object sender, EventArgs e)
        {
            string kreiranje_gosti = "create table gosti("+
	            "id int not null AUTO_INCREMENT PRIMARY KEY,"+
                "ime varchar(50) not null,"+
                "prezime varchar(50) not null,"+
                "starost int not null,"+
                 "mesto varchar(50) not null"+
                ");";

            string kreiranje_lokacije = "create table lokacije("+
	            "id int not null AUTO_INCREMENT PRIMARY KEY,"+
                "ime varchar(50) not null,"+
                "brojPoslovnice int not null"+
                ");";
        
            string kreiranje_radnici = "create table radnici("+
                "id int not null AUTO_INCREMENT PRIMARY KEY,"+
                "ime varchar(50) not null,"+
                "prezime varchar(50) not null,"+
                "vrstaRadnogMesta varchar(50) not null,"+
                "plata int not null,"+
                "lokacijeId int not null,"+
                "FOREIGN KEY(lokacijeId) REFERENCES lokacije(id)"+
                ");";
           
            string kreiranje_igre_na_stolu = "create table igreNaStolu("+
	                "id int not null AUTO_INCREMENT PRIMARY KEY,"+
                    "vrstaIgre varchar(50) not null,"+
                    "cenaIgre int not null"+
                    ");";

            string kreiranje_elektronske_igre =   "create table elektronskeIgre("+
	            "id int not null AUTO_INCREMENT PRIMARY KEY," +
                "vrstaIgre varchar(50) not null,"+
                "cenaIgre int not null"+
                ");";
            
            string kreiranje_dodatni_sadrzaj = "create table dodatniSadrzaj("+
	            "id int not null AUTO_INCREMENT PRIMARY KEY,"+
                "vrstaIgre varchar(50),"+
                "cena int not null"+
                ");";

            string kreiranje_jackpot_igre = "create table jackpotIgre(" +
                "id int not null AUTO_INCREMENT PRIMARY KEY," +
                "vrstaIgre varchar(50)," +
                "cenaIgre int not null" +
                ");";
            
            string kreiranje_uplate = "create table uplate("+
                "id int not null AUTO_INCREMENT PRIMARY KEY,"+
                "datum date not null,"+      
                "gostId int not null,"+ 
                "igreNaStoluId int,"+
                "elektronskeIgreId int,"+
                "dodatniSadrzajId int,"+
                "jackpotIgreId int,"+
                "lokacijeId int not null,"+               
                "FOREIGN KEY (gostID) REFERENCES gosti(id),"+
                "FOREIGN KEY(igreNaStoluId) REFERENCES igrenastolu(id),"+
                "FOREIGN KEY(elektronskeIgreId) REFERENCES elektronskeigre(id),"+
                "FOREIGN KEY(dodatniSadrzajId) REFERENCES dodatnisadrzaj(id),"+
                "FOREIGN KEY(jackpotIgreId) REFERENCES jackpotIgre(id),"+
                "FOREIGN KEY(lokacijeId) REFERENCES lokacije(id)"+
                ");";
                
            string kreiranje_isplate = "create table isplate("+
	            "id int not null AUTO_INCREMENT PRIMARY KEY,"+
                "datum date not null,"+
                "cenaIsplate int not null,"+
                "uplateId int not null,"+
                "FOREIGN KEY (uplateId) REFERENCES uplate(id)"+
                ");";
               
            

            string kreiranje_pice = "create table pice("+
	            "id int not null AUTO_INCREMENT PRIMARY KEY,"+
                "vrstaPica varchar(50) not null,"+
                "cena int not null,"+
                "godina date not null," +
                "kolicinaProdatog int not null" +
                ");";
            
         

            run(kreiranje_gosti);
            run(kreiranje_lokacije);
            run(kreiranje_radnici);
            run(kreiranje_igre_na_stolu);
            run(kreiranje_elektronske_igre);
            run(kreiranje_dodatni_sadrzaj);
            run(kreiranje_jackpot_igre);
            run(kreiranje_uplate);
            run(kreiranje_isplate);
            run(kreiranje_pice);
         


        }

        private void napuni_tabelu_Click(object sender, EventArgs e)
        {
            string[] napuni_goste = {"INSERT INTO gosti VALUES(0,'Teodora','Sakotic', 20, 'Republika Srbija');",
                    "INSERT INTO gosti VALUES(0,'Bogdan','Solomun', 30, 'Republika Srbija');",
                    "INSERT INTO gosti VALUES(0,'Kasija','Vukajlovic', 43, 'Republika Srbija');",
                    "INSERT INTO gosti VALUES(0,'Nikola','Peric', 33, 'Republika Srbija');",
                    "INSERT INTO gosti VALUES(0,'Pera','Pekic', 67, 'Republika Srbija');",
                    "INSERT INTO gosti VALUES(0,'Mia','Maric', 40, 'Republika Srbija');",
                    "INSERT INTO gosti VALUES(0,'Ivan','Cvetinovic', 25, 'Republika Srbija');",
                    "INSERT INTO gosti VALUES(0,'Jelena','Susnjevic', 19, 'Republika Srbija');",
                    "INSERT INTO gosti VALUES(0,'Ksenija','Nikolic', 54, 'Republika Srbija');",
                    "INSERT INTO gosti VALUES(0,'Jovan','Jovanovic', 21, 'Republika Srbija');",
                    "INSERT INTO gosti VALUES(0,'Petar','Petrovic', 60, 'Inostranstvo');",
                    "INSERT INTO gosti VALUES(0,'Nenad','Matic', 34, 'Inostranstvo');",
                    "INSERT INTO gosti VALUES(0,'Tijana','Tijanic', 51, 'Inostranstvo');",
                    "INSERT INTO gosti VALUES(0,'Milena','Jovic', 49, 'Inostranstvo');",
                    "INSERT INTO gosti VALUES(0,'Milan','Lazic', 25, 'Inostranstvo');",
                    "INSERT INTO gosti VALUES(0,'Vladimir','Atic', 48, 'Inostranstvo');",
                    "INSERT INTO gosti VALUES(0,'Strahinja','Milic', 22, 'Inostranstvo');",
                    "INSERT INTO gosti VALUES(0,'Nina','Milutinovic', 33, 'Inostranstvo');",
                    "INSERT INTO gosti VALUES(0,'Stefan','Cumpalovic', 42, 'Inostranstvo');",
                    "INSERT INTO gosti VALUES(0,'Aleksa','Ninic', 26, 'Inostranstvo');"
            };
            foreach(string x in napuni_goste)
            {
                run(x);
            }




             //za lokacije
            string[] napuni_lokacije = {"INSERT INTO lokacije VALUES(0,'Novi Sad',1);",
                "INSERT INTO lokacije VALUES(0,'Beograd',1);",
                "INSERT INTO lokacije VALUES(0,'Kragujevac',1);",
                "INSERT INTO lokacije VALUES(0,'Nis',1);",
                "INSERT INTO lokacije VALUES(0,'Zrenjanin',1);",
                "INSERT INTO lokacije VALUES(0,'Negotin',1);",
                "INSERT INTO lokacije VALUES(0,'Nis',2);",
                "INSERT INTO lokacije VALUES(0,'Nis',3);",
                "INSERT INTO lokacije VALUES(0,'Zrenjanin',2);",
                "INSERT INTO lokacije VALUES(0,'Zrenjanin',3);",
                "INSERT INTO lokacije VALUES(0,'Zrenjanin',4);",
                "INSERT INTO lokacije VALUES(0,'Novi Sad', 2);",
                "INSERT INTO lokacije VALUES(0,'Novi Sad', 3);",
                "INSERT INTO lokacije VALUES(0,'Novi Sad', 4);",
                "INSERT INTO lokacije VALUES(0,'Beograd', 2);",
                "INSERT INTO lokacije VALUES(0,'Beograd', 3);",
                "INSERT INTO lokacije VALUES(0,'Beograd', 4);",
                "INSERT INTO lokacije VALUES(0,'Beograd', 5);",
                "INSERT INTO lokacije VALUES(0,'Negotin',2);",
                "INSERT INTO lokacije VALUES(0,'Negotin',3);"
                
            };
            foreach(string x in napuni_lokacije){
                run(x);
            }







            //za radnike
            
            string[] napuni_radnike = {"INSERT INTO radnici VALUES(0,'Teodora','Cvetinovic','Konobar',40000,1);",
                    "INSERT INTO radnici VALUES(0,'Ivan','Maric','Radnik za stolom',50000,2);",
                    "INSERT INTO radnici VALUES(0,'Jovan','Jovic','Radnik za pultom',30000,3);",
                    "INSERT INTO radnici VALUES(0,'Nikola','Cvetic','konobar',45000,2);",
                    "INSERT INTO radnici VALUES(0,'Mila','Milinic','Radnik za stolom',36000,1);",
                    "INSERT INTO radnici VALUES(0,'Ana','Filipovic','Radnik za pultom',40000,5);",
                    "INSERT INTO radnici VALUES(0,'Mira','Babic','konobar',25000,5);",
                    "INSERT INTO radnici VALUES(0,'Vladimir','Dobric','Radnik za stolom',40000,4);",
                    "INSERT INTO radnici VALUES(0,'Jovana','Letic','Radnik za pultom',33000,4);",
                    "INSERT INTO radnici VALUES(0,'Maja','Marinkovic','konobar',29000,8);",
                    "INSERT INTO radnici VALUES(0,'Miljana','Miljanic','Radnik za stolom',35000,8);",
                    "INSERT INTO radnici VALUES(0,'Filip','Bozic','Radnik za pultom',35000,7);",
                    "INSERT INTO radnici VALUES(0,'Suzana','Suzic','konobar',41000,7);",
                    "INSERT INTO radnici VALUES(0,'Nikolina','Stojanovic','Radnik za stolom',40000,10);",
                    "INSERT INTO radnici VALUES(0,'Andrea','Andric','Radnik za pultom',36000,9);",
                    "INSERT INTO radnici VALUES(0,'Bojana','Miletic','konobar',41000,6);",
                    "INSERT INTO radnici VALUES(0,'Bogdan','Bogdanovic','Radnik za stolom',37000,6);",
                    "INSERT INTO radnici VALUES(0,'Mihailo','Jankov','Radnik za pultom',45000,11);",
                    "INSERT INTO radnici VALUES(0,'Nikola','Markovic','konobar',32000,11);",
                    "INSERT INTO radnici VALUES(0,'Jelena','Cvetkovic','Radnik za stolom',50000,11);",
                    "INSERT INTO radnici VALUES(0,'Tea','Tejic','konobar',39000,15);",
                    "INSERT INTO radnici VALUES(0,'Nemanja','Nedic','Radnik za pultom',40000,15);",
                    "INSERT INTO radnici VALUES(0,'Novica','Ljubic','konobar',31000,14);",
                    "INSERT INTO radnici VALUES(0,'Sladjan','Negovanovic','Radnik za pultom',44000,14);",
                    "INSERT INTO radnici VALUES(0,'Marija','Novakovic','konobar',25000,17);",
                    "INSERT INTO radnici VALUES(0,'Nenad','Banjac','konobar',30000,17);",
                    "INSERT INTO radnici VALUES(0,'Pavle','Djokic','konobar',27000,19);",
                    "INSERT INTO radnici VALUES(0,'Milorad','Bekic','Radnik za stolom',38000,19);"
            };
            foreach(string x in napuni_radnike){
                run(x);
            }
            



            //za igre na stolu
            string[] napuni_igre_na_stolu = {"INSERT INTO igreNaStolu VALUES(0,'Rulet',100);",
                "INSERT INTO igreNaStolu VALUES(0,'Rulet',200);",
                "INSERT INTO igreNaStolu VALUES(0,'Rulet',300);",
                "INSERT INTO igreNaStolu VALUES(0,'Rulet',500);",
                "INSERT INTO igreNaStolu VALUES(0,'Rulet',1000);",
                "INSERT INTO igreNaStolu VALUES(0,'Rulet',1500);",
                "INSERT INTO igreNaStolu VALUES(0,'Rulet',2000);",
                "INSERT INTO igreNaStolu VALUES(0,'Rulet',2500);",
                "INSERT INTO igreNaStolu VALUES(0,'Rulet',3000);",
                "INSERT INTO igreNaStolu VALUES(0,'Rulet',5000);",
                "INSERT INTO igreNaStolu VALUES(0,'Poker',100);",
                "INSERT INTO igreNaStolu VALUES(0,'Poker',200);",
                "INSERT INTO igreNaStolu VALUES(0,'Poker',300);",
                "INSERT INTO igreNaStolu VALUES(0,'Poker',500);",
                "INSERT INTO igreNaStolu VALUES(0,'Poker',1000);",
                "INSERT INTO igreNaStolu VALUES(0,'Poker',1500);",
                "INSERT INTO igreNaStolu VALUES(0,'Poker',2000);",
                "INSERT INTO igreNaStolu VALUES(0,'Poker',2500);",
                "INSERT INTO igreNaStolu VALUES(0,'Poker',3000);",
                "INSERT INTO igreNaStolu VALUES(0,'Poker',5000);"
            };
            foreach(string x in napuni_igre_na_stolu){
                run(x);
            }


            //za elektronske igre

            string[] napuni_elektronske_igre ={"INSERT INTO elektronskeIgre VALUES(0,'Tiket',50);",
                "INSERT INTO elektronskeIgre VALUES(0,'Tiket',100);",
                "INSERT INTO elektronskeIgre VALUES(0,'Tiket',200);",
                "INSERT INTO elektronskeIgre VALUES(0,'Tiket',300);",
                "INSERT INTO elektronskeIgre VALUES(0,'Tiket',400);",
                "INSERT INTO elektronskeIgre VALUES(0,'Tiket',500);",
                "INSERT INTO elektronskeIgre VALUES(0,'Tiket',700);",
                "INSERT INTO elektronskeIgre VALUES(0,'Tiket',1000);",
                "INSERT INTO elektronskeIgre VALUES(0,'LuckyNumbers',50);",
                "INSERT INTO elektronskeIgre VALUES(0,'LuckyNumbers',100);",
                "INSERT INTO elektronskeIgre VALUES(0,'LuckyNumbers',150);",
                "INSERT INTO elektronskeIgre VALUES(0,'LuckyNumbers',200);",
                "INSERT INTO elektronskeIgre VALUES(0,'LuckyNumbers',250);",
                "INSERT INTO elektronskeIgre VALUES(0,'LuckyNumbers',300);",
                "INSERT INTO elektronskeIgre VALUES(0,'LuckyNumbers',500);",
                "INSERT INTO elektronskeIgre VALUES(0,'Kino',50);",
                "INSERT INTO elektronskeIgre VALUES(0,'Kino',100);",
                "INSERT INTO elektronskeIgre VALUES(0,'Kino',150);",
                "INSERT INTO elektronskeIgre VALUES(0,'Kino',200);",
                "INSERT INTO elektronskeIgre VALUES(0,'Kino',250);",
            };
            foreach(string x in napuni_elektronske_igre){
                run(x);
            }


            // za dodatni sadrzaj

            string[] napuni_dodatni_sadrzaj = {"INSERT INTO dodatniSadrzaj VALUES(0,'Bilijar',50);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Pikado',50);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Slot Burbery Coast',100);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Slot Burbery Coast',200);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Slot Burbery Coast',500);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Slot Burbery Coast',1000);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Slot The Lost',100);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Slot The Lost',200);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Slot The Lost',500);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Slot The Lost',1000);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Slot Texas Hold em Poker',100);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Slot Texas Hold em Poker',200);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Slot Texas Hold em Poker',300);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Slot Texas Hold em Poker',500);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Slot Texas Hold em Poker',1000);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Slot Baccarat',100);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Slot Baccarat',200);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Slot Baccarat',300);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Slot Baccarat',500);",
                "INSERT INTO dodatniSadrzaj VALUES(0,'Slot Baccarat',1000);",
            };
             
            foreach(string x in napuni_dodatni_sadrzaj){
                run(x);
            }

            //za dodavanje jackop

            string[] napuni_jackpot_igre = {"INSERT INTO jackpotIgre VALUES(0,'Apollo', 210);",
                "INSERT INTO jackpotIgre VALUES(0,'Ali Baba', 500);",
                "INSERT INTO jackpotIgre VALUES(0,'Ozwin', 120);",
                "INSERT INTO jackpotIgre VALUES(0,'The Naked Gun', 450);",
                "INSERT INTO jackpotIgre VALUES(0,'Paws of Fury', 500);",
                "INSERT INTO jackpotIgre VALUES(0,'Dolphin Gold', 200);",
                "INSERT INTO jackpotIgre VALUES(0,'Medusa II', 390);",
                "INSERT INTO jackpotIgre VALUES(0,'Diamond', 200);",
                "INSERT INTO jackpotIgre VALUES(0,'Hi Lo Roller', 560);",
                "INSERT INTO jackpotIgre VALUES(0,'Super Multi', 600);",
                "INSERT INTO jackpotIgre VALUES(0,'Jackpotz', 310);",
                "INSERT INTO jackpotIgre VALUES(0,'Ten Elements', 400);",
                "INSERT INTO jackpotIgre VALUES(0,'Troll', 600);",
                "INSERT INTO jackpotIgre VALUES(0,'Top cat', 150);",
                "INSERT INTO jackpotIgre VALUES(0,'Cindrella', 370);",
                "INSERT INTO jackpotIgre VALUES(0,'Ra', 500);",
                "INSERT INTO jackpotIgre VALUES(0,'Treasure Mine', 650);",
                "INSERT INTO jackpotIgre VALUES(0,'Cleopatra', 400);",
                "INSERT INTO jackpotIgre VALUES(0,'Mega Fortune', 250);",
                "INSERT INTO jackpotIgre VALUES(0,'Wild Nords', 710);",
            };

            foreach (string x in napuni_jackpot_igre)
            {
                run(x);
            }






            //za pice
            string[] napuni_pice = {"INSERT INTO pice VALUES(0,'koka kola', 150,'2016-1-1', 550);",
                "INSERT INTO pice VALUES(0,'koka kola', 150,'2017-1-1', 290);",
                "INSERT INTO pice VALUES(0,'koka kola', 150,'2018-1-1', 650);",
                "INSERT INTO pice VALUES(0,'negazirana voda', 100,'2016-1-1', 200);",
                "INSERT INTO pice VALUES(0,'negazirana voda', 100,'2017-1-1', 590);",
                "INSERT INTO pice VALUES(0,'negazirana voda', 100,'2018-1-1', 610);",
                "INSERT INTO pice VALUES(0,'gazirana voda', 200,'2016-1-1', 490);",
                "INSERT INTO pice VALUES(0,'gazirana voda', 200,'2017-1-1', 300);",
                "INSERT INTO pice VALUES(0,'gazirana voda', 200,'2018-1-1', 855);",
                "INSERT INTO pice VALUES(0,'vodka', 130,'2016-1-1', 111);",
                "INSERT INTO pice VALUES(0,'vodka', 130,'2017-1-1', 600);",
                "INSERT INTO pice VALUES(0,'vodka', 130,'2018-1-1', 720);",
                "INSERT INTO pice VALUES(0,'pivo', 120,'2016-1-1', 826);",
                "INSERT INTO pice VALUES(0,'pivo', 120,'2017-1-1', 690);",
                "INSERT INTO pice VALUES(0,'pivo', 120,'2018-1-1', 800);",
                "INSERT INTO pice VALUES(0,'fanta', 100,'2016-1-1', 555);",
                "INSERT INTO pice VALUES(0,'fanta', 100,'2017-1-1', 340);",
                "INSERT INTO pice VALUES(0,'fanta', 100,'2018-1-1', 559);",
                "INSERT INTO pice VALUES(0,'dzek', 200,'2016-1-1', 200);",
                "INSERT INTO pice VALUES(0,'dzek', 200,'2017-1-1', 650);",
                "INSERT INTO pice VALUES(0,'dzek', 200,'2018-1-1', 720);",
                "INSERT INTO pice VALUES(0,'gusti sok', 140,'2016-1-1', 590);",
                "INSERT INTO pice VALUES(0,'gusti sok', 140,'2017-1-1', 877);",
                "INSERT INTO pice VALUES(0,'gusti sok', 140,'2018-1-1', 610);",
                "INSERT INTO pice VALUES(0,'bistri sok', 130,'2016-1-1', 750);",
                "INSERT INTO pice VALUES(0,'bistri sok', 130,'2017-1-1', 364);",
                "INSERT INTO pice VALUES(0,'bistri sok', 130,'2018-1-1', 854);",
                "INSERT INTO pice VALUES(0,'belo vino', 100,'2016-1-1', 680);",
                "INSERT INTO pice VALUES(0,'belo vino', 100,'2017-1-1', 280);",
                "INSERT INTO pice VALUES(0,'belo vino', 100,'2018-1-1', 600);",
                "INSERT INTO pice VALUES(0,'crno vino', 110,'2016-1-1', 782);",
                "INSERT INTO pice VALUES(0,'crno vino', 110,'2017-1-1', 456);",
                "INSERT INTO pice VALUES(0,'crno vino', 110,'2018-1-1', 321);",
                "INSERT INTO pice VALUES(0,'nes kafa', 120,'2016-1-1', 500);",
                "INSERT INTO pice VALUES(0,'nes kafa', 120,'2017-1-1', 745);",
                "INSERT INTO pice VALUES(0,'nes kafa', 120,'2018-1-1', 441);",
                "INSERT INTO pice VALUES(0,'domaca kafa', 100,'2016-1-1', 200);",
                "INSERT INTO pice VALUES(0,'domaca kafa', 100,'2017-1-1', 560);",
                "INSERT INTO pice VALUES(0,'domaca kafa', 100,'2018-1-1', 300);",
                "INSERT INTO pice VALUES(0,'stok', 200,'2016-1-1', 800);",
                "INSERT INTO pice VALUES(0,'stok', 200,'2017-1-1', 577);",
                "INSERT INTO pice VALUES(0,'stok', 200,'2018-1-1', 432);",
                "INSERT INTO pice VALUES(0,'rakija', 100,'2016-1-1', 700);",
                "INSERT INTO pice VALUES(0,'rakija', 100,'2017-1-1', 625);",
                "INSERT INTO pice VALUES(0,'rakija', 100,'2018-1-1', 897);",
                "INSERT INTO pice VALUES(0,'bambus', 190,'2016-1-1', 521);",
                "INSERT INTO pice VALUES(0,'bambus', 190,'2017-1-1', 679);",
                "INSERT INTO pice VALUES(0,'bambus', 190,'2018-1-1', 455);",
                "INSERT INTO pice VALUES(0,'koktel', 240,'2016-1-1', 570);",
                "INSERT INTO pice VALUES(0,'koktel', 240,'2017-1-1', 669);",
                "INSERT INTO pice VALUES(0,'koktel', 240,'2018-1-1', 852);",
                "INSERT INTO pice VALUES(0,'civas', 200,'2016-1-1', 646);",
                "INSERT INTO pice VALUES(0,'civas', 200,'2017-1-1', 800);",
                "INSERT INTO pice VALUES(0,'civas', 200,'2018-1-1', 720);",
                "INSERT INTO pice VALUES(0,'rum', 120,'2016-1-1', 830);",
                "INSERT INTO pice VALUES(0,'rum', 120,'2017-1-1', 657);",
                "INSERT INTO pice VALUES(0,'rum', 120,'2018-1-1', 871);",
                "INSERT INTO pice VALUES(0,'tekila', 120,'2016-1-1', 523);",
                "INSERT INTO pice VALUES(0,'tekila', 120,'2017-1-1', 543);",
                "INSERT INTO pice VALUES(0,'tekila', 120,'2018-1-1', 611);"
            };
            foreach (string x in napuni_pice){
                run(x);
            }


            // za uplate
           string[] napuni_uplate = {"INSERT INTO uplate VALUES(0,'2016-2-12', 3, 1, NULL, NULL,NULL, 10);",
                "INSERT INTO uplate VALUES(0,'2017-5-6', 20, NULL, NULL, NULL,5, 1);",
                "INSERT INTO uplate VALUES(0,'2017-2-2', 16, NULL, 6, NULL,NULL, 13);",
                "INSERT INTO uplate VALUES(0,'2018-1-8', 8, NULL, NULL, 19,NULL, 3);",
                "INSERT INTO uplate VALUES(0,'2018-1-5', 11, NULL, 17, NULL,NULL, 7);",
                "INSERT INTO uplate VALUES(0,'2016-1-1', 2, 4, NULL, NULL,NULL, 5);",
                "INSERT INTO uplate VALUES(0,'2016-2-5', 4, 10, NULL, NULL,NULL, 17);",
                "INSERT INTO uplate VALUES(0,'2018-6-1', 7, NULL, 4, NULL,NULL, 3);",
                "INSERT INTO uplate VALUES(0,'2017-8-22', 19, NULL, NULL, NULL,2, 1);",
                "INSERT INTO uplate VALUES(0,'2017-9-12', 9, NULL, NULL, NULL,17, 2);",
                "INSERT INTO uplate VALUES(0,'2018-6-17', 13, NULL, NULL, 8,NULL, 5);",
                "INSERT INTO uplate VALUES(0,'2018-11-9', 5, NULL, 15, NULL,NULL, 4);",
                "INSERT INTO uplate VALUES(0,'2016-5-19', 18, 12, NULL, NULL,NULL, 17);",
                "INSERT INTO uplate VALUES(0,'2016-10-31', 1, NULL, 9, NULL,NULL, 3);",
                "INSERT INTO uplate VALUES(0,'2018-12-30', 10, NULL, NULL, NULL,10, 2);",
                "INSERT INTO uplate VALUES(0,'2017-9-12', 2, NULL, NULL, 19,NULL, 6);",
                "INSERT INTO uplate VALUES(0,'2016-3-27', 6, NULL, 13, NULL,NULL, 3);",
                "INSERT INTO uplate VALUES(0,'2017-10-24', 12, 8, NULL, NULL,NULL, 6);",
                "INSERT INTO uplate VALUES(0,'2018-6-15', 14, NULL, NULL, 16,NULL, 1);",
                "INSERT INTO uplate VALUES(0,'2017-5-5', 17, NULL, NULL, 5,NULL, 6);",
                "INSERT INTO uplate VALUES(0,'2016-7-26', 9, NULL, 13, NULL,NULL, 2);",
                "INSERT INTO uplate VALUES(0,'2016-7-2', 1, NULL, NULL, 7,NULL, 12);",
                "INSERT INTO uplate VALUES(0,'2016-7-13', 13, NULL, NULL, NULL,1, 1);",
                "INSERT INTO uplate VALUES(0,'2016-8-1', 18, NULL, 5, NULL,NULL, 13);",
                "INSERT INTO uplate VALUES(0,'2016-8-15', 5, 18, NULL, NULL,NULL, 5);",
                "INSERT INTO uplate VALUES(0,'2016-8-8', 10, NULL, NULL, 11,NULL, 5);",
                "INSERT INTO uplate VALUES(0,'2017-7-27', 11, NULL, 6, NULL,NULL, 14);",
                "INSERT INTO uplate VALUES(0,'2017-7-21', 9, 18, NULL, NULL,NULL, 1);",
                "INSERT INTO uplate VALUES(0,'2017-7-1', 14, NULL, NULL, 8,NULL, 18);",
                "INSERT INTO uplate VALUES(0,'2017-8-17', 16, NULL, NULL, NULL,6, 4);",
                "INSERT INTO uplate VALUES(0,'2017-8-3', 2, 2, NULL, NULL,NULL, 3);",
                "INSERT INTO uplate VALUES(0,'2017-8-30', 4, NULL, NULL, 1,NULL, 19);",
                "INSERT INTO uplate VALUES(0,'2017-8-11', 19, NULL, 6, NULL,NULL, 5);",
                "INSERT INTO uplate VALUES(0,'2017-8-20', 8, 1, NULL, NULL,NULL, 6);",
                "INSERT INTO uplate VALUES(0,'2017-6-12', 5, 12, NULL, NULL,NULL, 7);",
                "INSERT INTO uplate VALUES(0,'2017-8-3', 17, NULL, NULL, 4,NULL, 1);",
                "INSERT INTO uplate VALUES(0,'2017-5-7', 8, NULL, 1, NULL,NULL, 11);",
                "INSERT INTO uplate VALUES(0,'2017-5-24', 10, NULL, NULL, NULL,10, 3);",
                "INSERT INTO uplate VALUES(0,'2017-5-15', 15, NULL, NULL, 6,NULL, 4);",
                "INSERT INTO uplate VALUES(0,'2017-5-27', 5, NULL, 4, NULL,NULL, 15);",
                "INSERT INTO uplate VALUES(0,'2017-5-24', 20, 20, NULL, NULL,NULL, 6);",
                "INSERT INTO uplate VALUES(0,'2017-5-15', 18, NULL, NULL, 12,NULL, 7);",
                "INSERT INTO uplate VALUES(0,'2018-6-17', 12, NULL, 3, NULL,NULL, 13);",
                "INSERT INTO uplate VALUES(0,'2018-6-2', 11, 14, NULL, NULL,NULL, 2);",
                "INSERT INTO uplate VALUES(0,'2018-6-5', 14, NULL, NULL, 2,NULL, 3);",
                "INSERT INTO uplate VALUES(0,'2018-6-12', 20, NULL, 11, NULL,NULL, 14);",
                "INSERT INTO uplate VALUES(0,'2018-6-2', 16, NULL, NULL, NULL,19, 5);",
                "INSERT INTO uplate VALUES(0,'2018-6-15', 3, NULL, NULL, 7,NULL, 6);",
                "INSERT INTO uplate VALUES(0,'2018-6-3', 17, 2, NULL, NULL,NULL, 7);"
                };
            foreach(string x in napuni_uplate){
                run(x);
            }






            //za isplate
            string[] napuni_isplate = {"INSERT INTO isplate VALUES(0,'2016-2-12',600,1);",
                "INSERT INTO isplate VALUES(0,'2017-5-6',1000,2);",
                "INSERT INTO isplate VALUES(0,'2017-2-24',500,3);",
                "INSERT INTO isplate VALUES(0,'2018-8-18',400,4);",
                "INSERT INTO isplate VALUES(0,'2018-1-5',800,5);",
                "INSERT INTO isplate VALUES(0,'2016-1-1',1000,6);",
                "INSERT INTO isplate VALUES(0,'2016-2-5',2000,7);",
                "INSERT INTO isplate VALUES(0,'2018-6-1',500,8);",
                "INSERT INTO isplate VALUES(0,'2017-8-22',700,9);",
                "INSERT INTO isplate VALUES(0,'2017-9-12',1200,10);",
                "INSERT INTO isplate VALUES(0,'2018-6-17',1600,11);",
                "INSERT INTO isplate VALUES(0,'2018-11-9',400,12);",
                "INSERT INTO isplate VALUES(0,'2016-5-19',5000,13);",
                "INSERT INTO isplate VALUES(0,'2016-10-31',1300,14);",
                "INSERT INTO isplate VALUES(0,'2018-12-30',6500,15);",
                "INSERT INTO isplate VALUES(0,'2017-9-12',700,16);",
                "INSERT INTO isplate VALUES(0,'2016-3-27',1400,17);",
                "INSERT INTO isplate VALUES(0,'2017-10-24',200,18);",
                "INSERT INTO isplate VALUES(0,'2018-6-15',800,19);",
                "INSERT INTO isplate VALUES(0,'2017-5-5',1500,20);"
            
            };
            foreach(string x in napuni_isplate){
                run(x);
            }

           


        }

        private void izvrsi_upit_Click(object sender, EventArgs e)
        {
            string upit = "";
            if(lista_upita.SelectedIndex == -1)
            {
                MessageBox.Show("odaberite neki upit");
                return;
            }

            if (lista_upita.SelectedIndex == 0)
            {
                upit = "SELECT lokacije.ime " +
                    "FROM uplate " +
                    "INNER JOIN lokacije on uplate.lokacijeId = lokacije.id " +
                    "WHERE datum > '2017-12-31' " +
                    "GROUP BY lokacije.id " +
                    "ORDER BY COUNT(*) DESC " +
                    "LIMIT 1";

                prikaz_upita.Text = run(upit) + " je lokacija na kojoj je bilo najvise uplata u 2018.-oj godini";
            }

            if(lista_upita.SelectedIndex == 1)
            {
                upit = "SELECT AVG(starost) "+
                    "FROM gosti "+
                    "WHERE mesto = 'Inostranstvo' ";

                prikaz_upita.Text = run(upit) + "je prosek godina gostiju iz inostranstva";

            }

            if(lista_upita.SelectedIndex == 2)
            {
                upit = "SELECT igrenastolu.vrstaIgre,COUNT(*) " +
                    "FROM uplate " +
                    "INNER JOIN igrenastolu on uplate.igreNaStoluId = igrenastolu.id " +
                    "GROUP BY igrenastolu.vrstaIgre " +
                    "ORDER BY COUNT(*) DESC " +
                    "LIMIT 1";
                prikaz_upita.Text = run(upit) ;
            }

            if(lista_upita.SelectedIndex == 3)
            {
                upit = "SELECT lokacije.ime ,SUM(case when igrenastolu.cenaIgre is null then 0 else igrenastolu.cenaIgre END + " +
                    "case when elektronskeigre.cenaIgre is null then 0  else elektronskeigre.cenaIgre end + case when dodatnisadrzaj.cena is null then 0 else dodatnisadrzaj.cena END + " +
                    "case when jackpotigre.cenaIgre is null then 0 else jackpotigre.cenaIgre END) as total " +
                    "FROM uplate " +
                    "INNER JOIN lokacije on uplate.lokacijeId = lokacije.id " +
                    "LEFT JOIN igrenastolu on uplate.igreNaStoluId = igrenastolu.id " +
                    "LEFT JOIN elektronskeigre on uplate.elektronskeIgreId = elektronskeigre.id " +
                    "LEFT JOIN dodatnisadrzaj on uplate.dodatniSadrzajId = dodatnisadrzaj.id " +
                    "LEFT JOIN jackpotigre on uplate.jackpotIgreId = jackpotigre.id " +
                    "WHERE datum BETWEEN '2016-1-1' AND '2016-12-31' AND lokacije.ime = 'Kragujevac' ";

                prikaz_upita.Text = run(upit);
            }

            if (lista_upita.SelectedIndex == 4)
            {
                upit = "SELECT igrenastolu.vrstaIgre ,SUM(igrenastolu.cenaIgre) "+
                    "FROM uplate "+
                    "INNER JOIN igrenastolu on uplate.igreNaStoluId = igrenastolu.id "+
                    "WHERE igrenastolu.vrstaIgre = 'Poker' ";

                prikaz_upita.Text = run(upit);
            }

            if(lista_upita.SelectedIndex == 5)
            {
                upit = "SELECT 'januar',YEAR(datum),SUM(cenaIsplate), '\r\n' " +
                    "FROM isplate " +
                    "WHERE datum BETWEEN '2016-02-01 00:00' AND '2016-02-29 23:59' " +
                    "OR datum BETWEEN '2017-2-1 00:00' AND '2017-2-28 23:59' " +
                    "GROUP BY MONTH(datum),YEAR(datum) " +
                    "ORDER BY datum DESC ";

                prikaz_upita.Text = run(upit);
            }

            if(lista_upita.SelectedIndex == 6)
            {
                upit = "SELECT YEAR(datum)" +
                    "FROM uplate " +
                    "GROUP BY YEAR(datum) " +
                    "ORDER BY datum DESC " +
                    "LIMIT 1 ";

                prikaz_upita.Text = run(upit) + "je godina sa najvise uplata";
            }

            if(lista_upita.SelectedIndex == 7)
            {
                upit = "SELECT  COUNT(*) "+
                    "FROM gosti " +
                    "WHERE mesto = 'Inostranstvo' and starost > 40";

                prikaz_upita.Text = run(upit);
            }

            if(lista_upita.SelectedIndex == 8)
            {
                upit = "SELECT YEAR(datum),sum(elektronskeigre.cenaIgre),'\r\n' " +
                    "FROM uplate " +
                    "INNER JOIN elektronskeigre on uplate.elektronskeIgreId = elektronskeigre.id " +
                    "GROUP BY YEAR(datum) ";

                prikaz_upita.Text = run(upit);
            }
            if (lista_upita.SelectedIndex == 9)
            {
                upit = "SELECT YEAR(datum),COUNT(*), '\r\n' " +
                    "from uplate " +
                    "INNER JOIN lokacije on uplate.lokacijeId = lokacije.id " +
                    "WHERE lokacije.ime = 'Nis' " +
                    "GROUP BY YEAR(datum) ";

                prikaz_upita.Text = run(upit);
            }

            if(lista_upita.SelectedIndex == 10)
            {
                upit = "SELECT elektronskeigre.vrstaIgre " +
                     "FROM uplate " +
                     "INNER JOIN elektronskeigre on uplate.elektronskeIgreId = elektronskeigre.id " +
                     "GROUP BY elektronskeigre.vrstaIgre " +
                     "ORDER BY COUNT(*) DESC " +
                     "LIMIT 1 ";
                prikaz_upita.Text = run(upit);
            }
            
            if(lista_upita.SelectedIndex == 11)
            {
                upit = "SELECT YEAR(datum) as 'godina',CONCAT(SUM(igrenastolu.cenaIgre), ' igre na stolu, '),CONCAT(SUM(elektronskeigre.cenaIgre), ' elektronske igre, ')," +
                    "CONCAT(SUM(dodatnisadrzaj.cena), ' dodatni sadrzaj, '),CONCAT(SUM(jackpotigre.cenaIgre), ' jackpot igre, '), '\r\n' " +
                    "FROM uplate " +
                    "LEFT JOIN igrenastolu on uplate.igreNaStoluId = igrenastolu.id " +
                    "LEFT JOIN elektronskeigre on uplate.elektronskeIgreId = elektronskeigre.id " +
                    "LEFT JOIN dodatnisadrzaj on uplate.dodatniSadrzajId = dodatnisadrzaj.id " +
                    "LEFT JOIN jackpotigre on uplate.jackpotIgreId = jackpotigre.id " +
                    "WHERE datum BETWEEN '2016-6-21' AND '2016-9-23' " +
                    "OR datum BETWEEN '2017-6-21' AND '2017-9-23' " +
                    "GROUP BY YEAR(datum)";

                prikaz_upita.Text = run(upit);
            }

            if(lista_upita.SelectedIndex == 12)
            {
                upit = "SELECT YEAR(datum),SUM(cenaIsplate), '\r\n' "+
                    "FROM isplate "+
                    "GROUP BY YEAR(datum)";

                prikaz_upita.Text = run(upit);
            }

            if(lista_upita.SelectedIndex == 13)
            {
                upit = "SELECT dodatnisadrzaj.vrstaIgre, COUNT(*), '\r\n' " +
                    "FROM uplate " +
                    "INNER JOIN dodatnisadrzaj on uplate.dodatniSadrzajId = dodatnisadrzaj.id " +
                    "GROUP BY dodatnisadrzaj.vrstaIgre ";
                prikaz_upita.Text = run(upit);
            }

            if(lista_upita.SelectedIndex == 14)
            {
                upit = "SELECT lokacije.ime,COUNT(*) "+
                    "FROM isplate "+
                    "INNER JOIN uplate on isplate.uplateId = uplate.id "+
                    "INNER JOIN lokacije on uplate.lokacijeId = lokacije.id "+
                    "GROUP BY lokacije.id "+
                    "ORDER BY COUNT(*) DESC "+
                    "LIMIT 1 ";

                prikaz_upita.Text = run(upit);
            }

            if(lista_upita.SelectedIndex == 15)
            {
                upit = "SELECT YEAR(godina),SUM(kolicinaProdatog * pice.cena), '\r\n'  "+
                    "FROM pice "+
                    "GROUP BY YEAR(godina) ";

                prikaz_upita.Text = run(upit);
            }
            if(lista_upita.SelectedIndex == 16)
            {
                upit = "SELECT YEAR(datum),COUNT(*), '\r\n' " +
                    "FROM uplate " +
                    "INNER JOIN lokacije on uplate.lokacijeId = lokacije.id " +
                    "WHERE lokacije.ime = 'Beograd' AND uplate.datum BETWEEN '2016-1-1' AND '2017-12-31' " +
                    "GROUP BY YEAR(datum) ";

                prikaz_upita.Text = run(upit);
            }

            if(lista_upita.SelectedIndex == 17)
            {
                upit = "SELECT SUM(elektronskeigre.cenaIgre) " +
                    "FROM uplate " +
                    "INNER JOIN elektronskeigre ON uplate.elektronskeIgreId = elektronskeigre.id ";

                prikaz_upita.Text = run(upit) + "je ukupno zaradjeno";
            }
            
            if(lista_upita.SelectedIndex == 18)
            {
                upit = "SELECT CONCAT(elektronskeigre.vrstaIgre,' ', COUNT(*)), '\r\n' "+
                    "FROM uplate "+
                    "INNER JOIN gosti on uplate.gostId = gosti.id "+
                    "INNER JOIN elektronskeigre ON uplate.elektronskeIgreId = elektronskeigre.id "+
                    "WHERE gosti.starost > 30 "+
                    "GROUP BY elektronskeigre.vrstaIgre "+
                    "ORDER BY COUNT(*) DESC ";

                prikaz_upita.Text = run(upit);
            }

            if(lista_upita.SelectedIndex == 19)
            {
                upit = "SELECT YEAR(datum),SUM(igrenastolu.cenaIgre), '\r\n' "+
                    "FROM uplate "+
                    "INNER JOIN igrenastolu on uplate.igreNaStoluId = igrenastolu.id "+
                    "GROUP BY YEAR(datum) ";

                prikaz_upita.Text = run(upit);
            }

            




        }

        private void lista_upita_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void prikaz_upita_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
