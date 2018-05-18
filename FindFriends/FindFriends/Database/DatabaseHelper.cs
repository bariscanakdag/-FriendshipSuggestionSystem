using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFriends.Helper
{
    public class DatabaseHelper
    {

        public static string DatabasePath { get; set; }


        private string CreateTableOgrenciNetwrok = @"CREATE TABLE IF NOT EXISTS[ogrencinetwork] (
                                    [ogrencinetworkID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                    [Kendisi] TEXT  NULL,
                                    [ark1] TEXT  NULL,
                                    [ark2] TEXT  NULL,
                                    [ark3] TEXT  NULL,
                                    [ark4] TEXT  NULL,
                                    [ark5] TEXT  NULL,
                                    [ark6] TEXT  NULL,
                                    [ark7] TEXT  NULL,
                                    [ark8] TEXT  NULL,
                                    [ark9] TEXT  NULL,
                                    [ark10] TEXT  NULL  )";


        private string CreateTableOgrenciProfil = @"CREATE TABLE IF NOT EXISTS[ogrenciprofil] (
                                    [ogrenciprofilID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                    [Kendisi] TEXT  NULL,
                                    [A1] INTEGER  NULL,
                                    [A2] INTEGER  NULL,
                                    [A3] INTEGER  NULL,
                                    [A4] INTEGER  NULL,
                                    [A5] INTEGER  NULL,
                                    [A6] INTEGER  NULL,
                                    [A7] INTEGER  NULL,
                                    [A8] INTEGER  NULL,
                                    [A9] INTEGER  NULL,
                                    [A10] INTEGER  NULL,
                                    [A11] INTEGER  NULL,
                                    [A12] INTEGER  NULL,
                                    [A13] INTEGER  NULL,
                                    [A14] INTEGER  NULL,
                                    [A15] INTEGER  NULL)";

        /// <summary>
        ///İlk olarak  C:\Users\asus\AppData\Roaming altında Findfriends dosyası var mı diye bakar.
        ///Yoksa kendisi oluşturur.Sonra bu dosyanın içerisinde Ogrenci.db adında bir dosya var mı diye bakar 
        ///yok ise oluşturur.
        /// </summary>

        public void CheckDatabase()
        {
            string path = string.Format("{0}/{1}", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Findfriends");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            DatabasePath = string.Format("{0}/Ogrenci.db", path);

            if (!File.Exists(DatabasePath))
            {
                File.Create(DatabasePath).Close();
                using (SQLiteConnection sqliteConn = GetConnection())
                {
                  


                    using (SQLiteCommand cmd = new SQLiteCommand(sqliteConn))
                    {

                        cmd.CommandText = CreateTableOgrenciNetwrok;
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = CreateTableOgrenciProfil;
                        cmd.ExecuteNonQuery();

                        sqliteConn.Close();
                    }
                }
            }


        }
        public SQLiteConnection GetConnection()
        {

            SQLiteConnection con = new SQLiteConnection(string.Format("Data Source={0}", DatabasePath));

            con.Open();
            return con;
        }

    }
}


