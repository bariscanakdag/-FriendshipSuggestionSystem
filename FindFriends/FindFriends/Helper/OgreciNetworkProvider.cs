using FindFriends.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFriends.Helper
{
    /// <summary>
    /// Metodların using içinde yazılmasının sebebi metodun işi bittiğinde using içinde tanımlanmış olan alanlar bellekten atılır.
    /// </summary>
    public class OgreciNetworkProvider : SQLiteBaseProvider
    {

        /// <summary>
        /// Gelen ogrencinetwork nesnesini veritabanına kaydeder.
        /// </summary>
        /// <param name="ogreci"></param>
        public void OgrenciNetworkEkle(OgreciNetworkModel ogreci)
        {
            using (SQLiteConnection con = DatabaseHelper.GetConnection())
            {
                string sqlCommand = "insert into ogrencinetwork(Kendisi,ark1,ark2,ark3,ark4,ark5,ark6,ark7,ark8,ark9,ark10) values(@adi,@ark1,@ark2,@ark3,@ark4,@ark5,@ark6,@ark7,@ark8,@ark9,@ark10)";
                SQLiteCommand cmd = new SQLiteCommand( con);
                cmd.CommandText = sqlCommand;
                cmd.Parameters.AddWithValue("@adi", ogreci.Numarasi);
                cmd.Parameters.AddWithValue("@ark1", ogreci.Ark1);
                cmd.Parameters.AddWithValue("@ark2", ogreci.Ark2);
                cmd.Parameters.AddWithValue("@ark3", ogreci.Ark3);
                cmd.Parameters.AddWithValue("@ark4", ogreci.Ark4);
                cmd.Parameters.AddWithValue("@ark5", ogreci.Ark5);
                cmd.Parameters.AddWithValue("@ark6", ogreci.Ark6);
                cmd.Parameters.AddWithValue("@ark7", ogreci.Ark7);
                cmd.Parameters.AddWithValue("@ark8", ogreci.Ark8);
                cmd.Parameters.AddWithValue("@ark9", ogreci.Ark9);
                cmd.Parameters.AddWithValue("@ark10", ogreci.Ark10);
                cmd.ExecuteNonQuery();
                con.Close();
            }
          
        }
       

        /// <summary>
        /// Veritabanından tüm kayıtları getirir.
        /// </summary>
        /// <returns>List(OgreciNetworkModel)</returns>
        public List<OgreciNetworkModel> OgrenciNetworkGetir()
        {
            using (SQLiteConnection con = DatabaseHelper.GetConnection())
            {
                List<OgreciNetworkModel> ogrecis = new List<OgreciNetworkModel>();
                string sqlCommand= "SELECT* FROM ogrencinetwork";
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = sqlCommand;
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    OgreciNetworkModel model = new OgreciNetworkModel();
                    model.NetworkID = dr.GetInt32(dr.GetOrdinal("ogrencinetworkID"));
                    model.Numarasi = dr.GetString(dr.GetOrdinal("Kendisi"));
                    model.Ark1 = dr.GetString(dr.GetOrdinal("ark1"));
                    model.Ark2 = dr.GetString(dr.GetOrdinal("ark2"));
                    model.Ark3 = dr.GetString(dr.GetOrdinal("ark3"));
                    model.Ark4 = dr.GetString(dr.GetOrdinal("ark4"));
                    model.Ark5 = dr.GetString(dr.GetOrdinal("ark5"));
                    model.Ark6 = dr.GetString(dr.GetOrdinal("ark6"));
                    model.Ark7 = dr.GetString(dr.GetOrdinal("ark7"));
                    model.Ark8 = dr.GetString(dr.GetOrdinal("ark8"));
                    model.Ark9 = dr.GetString(dr.GetOrdinal("ark9"));
                    model.Ark10 = dr.GetString(dr.GetOrdinal("ark10"));
                    ogrecis.Add(model);

                }
                con.Close();
                return ogrecis;
            }
          
           
        }


    }
}
