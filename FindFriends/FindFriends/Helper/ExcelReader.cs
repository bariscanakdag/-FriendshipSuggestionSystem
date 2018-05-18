using FindFriends.Model;
using FindFriends.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
namespace FindFriends.Helper
{
    public class ExcelReader
    {
        #region Members

        OgreciNetworkProvider OgreciNetworkProvider;

        OgrenciProfilProvider OgrenciProfilProvider;

        #endregion

        /// <summary>
        /// İlk olarak hangi dosya seçildiği belirlenir.Seçilen dosya belirlendikten sonra
        /// csv dosyası okunur. Her bir satır diziye atılır.
        /// dizinin elemanı split edilir ve gerekli alanlar modele atılır.
        /// her kayıt veritabına doğru sıra ile eklenir.
        /// </summary>
        /// <param name="openFileSafeFileName">Açılan dosyanın ismi</param>
        /// <param name="openFileFileName">Dosyanın tam yolu</param>
        public void ExelRead(string openFileSafeFileName, string openFileFileName)
        {
            OgreciNetworkProvider = new OgreciNetworkProvider();

            OgrenciProfilProvider = new OgrenciProfilProvider();

            if (openFileSafeFileName == "ogrenciNetwork.csv")
            {
                string[] allLinesnetwork = File.ReadAllLines(openFileFileName);

                for (int i = 0; i < allLinesnetwork.Length; i++)
                {
                    OgreciNetworkModel ogreciNetworkModel = new OgreciNetworkModel();
                    string[] ogrenci = allLinesnetwork[i].Split(',');
                    ogreciNetworkModel.Numarasi = ogrenci[0];
                    ogreciNetworkModel.Ark1 = ogrenci[1];
                    ogreciNetworkModel.Ark2 = ogrenci[2];
                    ogreciNetworkModel.Ark3 = ogrenci[3];
                    ogreciNetworkModel.Ark4 = ogrenci[4];
                    ogreciNetworkModel.Ark5 = ogrenci[5];
                    ogreciNetworkModel.Ark6 = ogrenci[6];
                    ogreciNetworkModel.Ark7 = ogrenci[7];
                    ogreciNetworkModel.Ark8 = ogrenci[8];
                    ogreciNetworkModel.Ark9 = ogrenci[9];
                    ogreciNetworkModel.Ark10 = ogrenci[10];
                    OgreciNetworkProvider.OgrenciNetworkEkle(ogreciNetworkModel);

                }
            }

            if (openFileSafeFileName == "ogrenciProfil.csv")
            {

                string[] allLineprofil = File.ReadAllLines(openFileFileName);
                for (int i = 0; i < allLineprofil.Length; i++)
                {
                    OgrenciProfilModel ogrenciProfil = new OgrenciProfilModel();
                    string[] profil = allLineprofil[i].Split(',');
                    ogrenciProfil.Numarasi = profil[0];
                    ogrenciProfil.A1 = Convert.ToInt32(profil[1]);
                    ogrenciProfil.A2 = Convert.ToInt32(profil[2]);
                    ogrenciProfil.A3 = Convert.ToInt32(profil[3]);
                    ogrenciProfil.A4 = Convert.ToInt32(profil[4]);
                    ogrenciProfil.A5 = Convert.ToInt32(profil[5]);
                    ogrenciProfil.A6 = Convert.ToInt32(profil[6]);
                    ogrenciProfil.A7 = Convert.ToInt32(profil[7]); ;
                    ogrenciProfil.A8 = Convert.ToInt32(profil[8]);
                    ogrenciProfil.A9 = Convert.ToInt32(profil[9]);
                    ogrenciProfil.A10 = Convert.ToInt32(profil[10]);
                    ogrenciProfil.A11 = Convert.ToInt32(profil[11]);
                    ogrenciProfil.A12 = Convert.ToInt32(profil[12]);
                    ogrenciProfil.A13 = Convert.ToInt32(profil[13]);
                    ogrenciProfil.A14 = Convert.ToInt32(profil[14]);
                    ogrenciProfil.A15 = Convert.ToInt32(profil[15]);
                    OgrenciProfilProvider.OgrenciProfilKaydet(ogrenciProfil);

                }

            }
        }

        /// <summary>
        /// Bir öğrenci listesi oluşturulur. ogrencilistesi.xlsx dosyası açılıur.
        /// Açılan dosyanın satır sayısı kadar for döner .
        /// i'yi 2 den başlattım çünkü 1. satırda açıklama var .
        /// Her okunan satır öğrenci listesine eklenir.
        /// </summary>
        /// <returns>StudentModel tipinde öğrenci listesi döndürür.</returns>

        public List<StudentModel> OgrenciListesiOku()
        {

            List<StudentModel> students = new List<StudentModel>();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\asus\Desktop\Mühendislik 4.Proje\FindFriends\FindFriends\RequiredFiles\ogrencilistesi.xlsx");
            Excel._Worksheet xlWorksheet = (Excel._Worksheet)xlWorkbook.Sheets[1];
            for (int i = 2; i <= xlWorksheet.UsedRange.Rows.Count; i++)
            {
                StudentModel student = new StudentModel();
                student.No = (xlWorksheet.Cells[i, 1] as Range)?.Value2?.ToString();
                student.Adi = (xlWorksheet.Cells[i, 2] as Range)?.Value2?.ToString();
                students.Add(student);
            }
            xlWorkbook.Close();
            return students;
        }
    }

}

