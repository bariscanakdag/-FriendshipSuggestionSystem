using FindFriends.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFriends.Helper
{
    public class OgrenciProfilProvider : SQLiteBaseProvider
    {
        /// <summary>
        /// Ogrenci profil nesnesini veritabanına kaydeder.
        /// </summary>
        /// <param name="ogrenciProfil"></param>
        public void OgrenciProfilKaydet(OgrenciProfilModel ogrenciProfil)
        {

            using (SQLiteConnection con = DatabaseHelper.GetConnection())
            {
                string sqlCommand = "insert into ogrenciprofil(Kendisi,A1,A2,A3,A4,A5,A6,A7,A8,A9,A10,A11,A12,A13,A14,A15) values(@numara,@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10,@a11,@a12,@a13,@a14,@a15)";

                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = sqlCommand;
                cmd.Parameters.AddWithValue("@numara", ogrenciProfil.Numarasi);
                cmd.Parameters.AddWithValue("@a1", ogrenciProfil.A1);
                cmd.Parameters.AddWithValue("@a2", ogrenciProfil.A2);
                cmd.Parameters.AddWithValue("@a3", ogrenciProfil.A3);
                cmd.Parameters.AddWithValue("@a4", ogrenciProfil.A4);
                cmd.Parameters.AddWithValue("@a5", ogrenciProfil.A5);
                cmd.Parameters.AddWithValue("@a6", ogrenciProfil.A6);
                cmd.Parameters.AddWithValue("@a7", ogrenciProfil.A7);
                cmd.Parameters.AddWithValue("@a8", ogrenciProfil.A8);
                cmd.Parameters.AddWithValue("@a9", ogrenciProfil.A9);
                cmd.Parameters.AddWithValue("@a10", ogrenciProfil.A10);
                cmd.Parameters.AddWithValue("@a11", ogrenciProfil.A11);
                cmd.Parameters.AddWithValue("@a12", ogrenciProfil.A12);
                cmd.Parameters.AddWithValue("@a13", ogrenciProfil.A13);
                cmd.Parameters.AddWithValue("@a14", ogrenciProfil.A14);
                cmd.Parameters.AddWithValue("@a15", ogrenciProfil.A15);
                cmd.ExecuteNonQuery();
                con.Close();
            }
     


        }

   

        /// <summary>
        /// Ogreci profil'ini veritabanından getirir
        /// </summary>
        /// <returns>List(OgrenciProfilModel)</returns>
        public List<OgrenciProfilModel> ProfilOgrenciGetir()
        {
            using (SQLiteConnection con = DatabaseHelper.GetConnection())
            {
                List<OgrenciProfilModel> ogrencis = new List<OgrenciProfilModel>();
                string sqlCommand = "select * from ogrenciprofil";
;                SQLiteCommand cmd = new SQLiteCommand(con);
                    cmd.CommandText = sqlCommand;
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    OgrenciProfilModel ogrenciProfil = new OgrenciProfilModel();
                    ogrenciProfil.ProfilID = dr.GetInt32(dr.GetOrdinal("ogrenciprofilID"));
                    ogrenciProfil.Numarasi = dr.GetString(dr.GetOrdinal("Kendisi"));
                    ogrenciProfil.A1 = dr.GetInt32(dr.GetOrdinal("A1"));
                    ogrenciProfil.A2 = dr.GetInt32(dr.GetOrdinal("A2"));
                    ogrenciProfil.A3 = dr.GetInt32(dr.GetOrdinal("A3"));
                    ogrenciProfil.A4 = dr.GetInt32(dr.GetOrdinal("A4"));
                    ogrenciProfil.A5 = dr.GetInt32(dr.GetOrdinal("A5"));
                    ogrenciProfil.A6 = dr.GetInt32(dr.GetOrdinal("A6"));
                    ogrenciProfil.A7 = dr.GetInt32(dr.GetOrdinal("A7"));
                    ogrenciProfil.A8 = dr.GetInt32(dr.GetOrdinal("A8"));
                    ogrenciProfil.A9 = dr.GetInt32(dr.GetOrdinal("A9"));
                    ogrenciProfil.A10 = dr.GetInt32(dr.GetOrdinal("A10"));
                    ogrenciProfil.A11 = dr.GetInt32(dr.GetOrdinal("A11"));
                    ogrenciProfil.A12 = dr.GetInt32(dr.GetOrdinal("A12"));
                    ogrenciProfil.A13 = dr.GetInt32(dr.GetOrdinal("A13"));
                    ogrenciProfil.A14 = dr.GetInt32(dr.GetOrdinal("A14"));
                    ogrenciProfil.A15 = dr.GetInt32(dr.GetOrdinal("A15"));
                    ogrencis.Add(ogrenciProfil);
                }
                con.Close();
                return ogrencis;
            }
   
        }

    }

}
