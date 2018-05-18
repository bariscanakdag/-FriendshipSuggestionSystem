using FindFriends.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFriends.Helper
{
    public class FindFriendProvider : SQLiteBaseProvider
    {

        /// <summary>
        /// Gelen numaraya göre o numaraya sahib kişiyi ve tüm arkadaşlarını getirir.
        /// </summary>
        /// <param name="no">Aranan öğrencinin numarası</param>
        /// <returns>Aranan öğrenci ve arkadaşları</returns>
        public string[] ArkdaslariBul(string no)
        {

            using (SQLiteConnection con = DatabaseHelper.GetConnection())
            {
                string[] arkadasDizi = new string[11];
                string sqlCommand = "SELECT * FROM ogrencinetwork WHERE Kendisi=@no";
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = sqlCommand;
                cmd.Parameters.AddWithValue("@no", no);
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    arkadasDizi[0] = dr.GetString(dr.GetOrdinal("Kendisi"));
                    arkadasDizi[1] = dr.GetString(dr.GetOrdinal("ark1"));
                    arkadasDizi[2] = dr.GetString(dr.GetOrdinal("ark2"));
                    arkadasDizi[3] = dr.GetString(dr.GetOrdinal("ark3"));
                    arkadasDizi[4] = dr.GetString(dr.GetOrdinal("ark4"));
                    arkadasDizi[5] = dr.GetString(dr.GetOrdinal("ark5"));
                    arkadasDizi[6] = dr.GetString(dr.GetOrdinal("ark6"));
                    arkadasDizi[7] = dr.GetString(dr.GetOrdinal("ark7"));
                    arkadasDizi[8] = dr.GetString(dr.GetOrdinal("ark8"));
                    arkadasDizi[9] = dr.GetString(dr.GetOrdinal("ark9"));
                    arkadasDizi[10] = dr.GetString(dr.GetOrdinal("ark10"));

                }
                con.Close();
                return arkadasDizi;
            }

        }

    }
}
