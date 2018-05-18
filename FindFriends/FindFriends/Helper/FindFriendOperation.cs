using FindFriends.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFriends.Helper
{
    public class FindFriendOperation
    {
        ExcelReader ExcelReader = new ExcelReader();
        FindFriendProvider FindFriendProvider = new FindFriendProvider();
        OgrenciProfilProvider OgrenciProfilProvider = new OgrenciProfilProvider();
        StudentModel BulunanOgrenci = new StudentModel();
        public List<StudentModel> BestTenFriend(string ArananOgrenci, ObservableCollection<OgrenciProfilModel> ProfilList)
        {
            var OgrenciVarmi = ExcelReader.OgrenciListesiOku();  //ogrencilistesi.xlsx dosyası okunur ve dosyadaki tüm
                                                                 //tüm veriler OgrenciVarmi listesine atılır.

            for (int i = 0; i < OgrenciVarmi.Count; i++) //tüm liste dolaşılır.
            {
                if (OgrenciVarmi[i].Adi == ArananOgrenci || OgrenciVarmi[i].No == ArananOgrenci) //Girilen numara veya isim excel'deki veriler ile 
                                                                                                 //aynı olması kontrol edilir.
                {

                    BulunanOgrenci.No = OgrenciVarmi[i].No; //isim veya numara eşleşirse numarayı bulunan öğrencinin numarasına atar.
                }


            }

            if (string.IsNullOrEmpty(BulunanOgrenci.No)) // Aradığımız öğrenci yok ise ekrana öğrenci yoktur diye mesaj verir
            {
                System.Windows.MessageBox.Show("Girdiğiniz öğrenci yoktur...");
            }
            else
            {
                var ogrenciArkadaslari = FindFriendProvider.ArkdaslariBul(BulunanOgrenci.No); //Aranan öğrencinin arkadaşları (Veritabanından)FindFriendProvider nesnesinin 
                                                                                              //   ArkdaslariBul metodu ile hepsi bulunur.

                BulunanOgrenci.No = null; //Başka bir öğrenci aramak için null'larız.
                if (string.IsNullOrEmpty(ogrenciArkadaslari[0])) //Veritabanında bir hata(olması gereken kaydın olmaması gibi) meydana gelirse mesaj çıkar.
                    System.Windows.MessageBox.Show("Veritabanında hatalı kayıt vardır.."+ogrenciArkadaslari[0]);
                else
                {
                    //Burada regresyona sokacağım anketList tanımladım.
                    List<AnketModel> anketList = new List<AnketModel>();
                    foreach (var item in ProfilList)
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            if (!string.IsNullOrEmpty(ogrenciArkadaslari[i])) //Aranan öğrencinin arkadaşlarını anketList'e attım arkadasmı alanına 1 verdim.
                            {
                                if (ogrenciArkadaslari[i] == item.Numarasi)
                                {
                                    AnketModel anket = new AnketModel();
                                    anket.Arkadasmi = 1;
                                    anket.ArkadaslikDegeri = 0;
                                    anket.ARKADAS = item.Numarasi;
                                    anket.A1 = item.A1;
                                    anket.A2 = item.A2;
                                    anket.A3 = item.A3;
                                    anket.A4 = item.A4;
                                    anket.A5 = item.A5;
                                    anket.A6 = item.A6;
                                    anket.A7 = item.A7;
                                    anket.A8 = item.A8;
                                    anket.A9 = item.A9;
                                    anket.A10 = item.A10;
                                    anket.A11 = item.A11;
                                    anket.A12 = item.A12;
                                    anket.A13 = item.A13;
                                    anket.A14 = item.A14;
                                    anket.A15 = item.A15;
                                    anketList.Add(anket);
                                }
                            }

                        }
                    }
                    List<OgrenciProfilModel> list = new List<OgrenciProfilModel>(); //yeni bir OgrenciProfilModel listesi tanımlıyorum.
                    list = OgrenciProfilProvider.ProfilOgrenciGetir(); //OgrenciProfil kayıtlarının hepsi çekilir.
                    OgrenciProfilModel ogrenci = new OgrenciProfilModel();
                    for (int i = 0; i < ogrenciArkadaslari.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(ogrenciArkadaslari[i])) //Boş değerler de geldiği için kontrol ettik.
                        {
                            ogrenci = list.FirstOrDefault(x => x.Numarasi == ogrenciArkadaslari[i]); //listenin içerisinden aranan öğrenci ve arkadaşlarını siler.
                            list.Remove(ogrenci);
                        }


                    }
                    for (int i = 0; i < list.Count / 2; i++) //Arkadaşı olmayanların yarısıda anketList'e atılır ve arkadasmi alanına 0 verilir.
                    {
                        AnketModel anket = new AnketModel();
                        anket.Arkadasmi = 0;
                        anket.ARKADAS = list[i].Numarasi;
                        anket.A1 = list[i].A1;
                        anket.A2 = list[i].A2;
                        anket.A3 = list[i].A3;
                        anket.A4 = list[i].A4;
                        anket.A5 = list[i].A5;
                        anket.A6 = list[i].A6;
                        anket.A7 = list[i].A7;
                        anket.A8 = list[i].A8;
                        anket.A9 = list[i].A9;
                        anket.A10 = list[i].A10;
                        anket.A11 = list[i].A11;
                        anket.A12 = list[i].A12;
                        anket.A13 = list[i].A13;
                        anket.A14 = list[i].A14;
                        anket.A15 = list[i].A15;
                        anket.ArkadaslikDegeri = 0;
                        anketList.Add(anket);

                    }
                    for (int i = 0; i < anketList.Count; i++) //listenin içersininden anketList'e olan tüm değerler silinir.
                                                               //Böylece elimizde hiç dokunmadığımız yarısı kalır(ortalama 40 kişi).
                    {
                        var sil = list.FirstOrDefault(x => x.Numarasi == anketList[i].ARKADAS);
                        list.Remove(sil);
                    }
                    List<AnketModel> aranacakList = new List<AnketModel>(); //Hiç dokunmadığımız 40 kişi 10 arkadaşın aranacağı aranacakList'e atılır.
                    for (int i = 0; i < list.Count; i++)
                    {
                        AnketModel anket = new AnketModel();
                        anket.Arkadasmi = 0;
                        anket.ARKADAS = list[i].Numarasi;
                        anket.A1 = list[i].A1;
                        anket.A2 = list[i].A2;
                        anket.A3 = list[i].A3;
                        anket.A4 = list[i].A4;
                        anket.A5 = list[i].A5;
                        anket.A6 = list[i].A6;
                        anket.A7 = list[i].A7;
                        anket.A8 = list[i].A8;
                        anket.A9 = list[i].A9;
                        anket.A10 = list[i].A10;
                        anket.A11 = list[i].A11;
                        anket.A12 = list[i].A12;
                        anket.A13 = list[i].A13;
                        anket.A14 = list[i].A14;
                        anket.A15 = list[i].A15;
                        anket.ArkadaslikDegeri = 0;
                        aranacakList.Add(anket);
                    }
                    var Best10Student = LogisticRegression(anketList, aranacakList); //LogisticRegression metoduna anketList(betaları bulmak için) 
                                                                                     //ve aranacakList(10 arkadaşı bulmak için) yollanır. 
                    return Best10Student;
                }
            }
            return null;
        }

        private List<StudentModel> LogisticRegression(List<AnketModel> anketList, List<AnketModel> aranacakList)
        {

            
            int maxLoop = 100; 
            double stepSize = 0.001;
            int N = anketList.Count; //betaların bulunacağı listenin eleman sayısı.
            double[] beta = new double[16];
            for (int i = 0; i < beta.Length; i++)
            {
                beta[i] = 1;   // betaların başlangıç değerleri veriliyor.
            }
            double[] newBeta = new double[16];
            double sum1 = 0.0;
            double sum2 = 0.0;

            for (int m = 0; m < maxLoop; m++)
            {
                sum1 = 0.0;
                for (int i = 0; i < N; i++) 
                {
                    int[] anket = anketDeger(anketList[i]); //Her defasında gelen kişinin anket değerleri anket dizisine atılır.
                    double hx = Math.Exp(-(beta[0] + beta[1] * anket[1] + beta[2] * anket[2] + beta[3] * anket[3] + beta[4] * anket[4] + beta[5] * anket[5] +
                    beta[6] * anket[6] + beta[7] * anket[7] + beta[8] * anket[8] + beta[9] * anket[9] + beta[10] * anket[10] + beta[11] * anket[11] + beta[12] * anket[12] +
                    beta[13] * anket[13] + beta[14] * anket[14] + beta[15] * anket[15]));
                    double hb = 1.0 / (1.0 + hx);
                    double y = anketList[i].Arkadasmi;
                   
                    sum1 += hb - y;
                }
                newBeta[0] = beta[0] - (stepSize * sum1 / N);

                for (int j = 0; j <= 15; j++)
                {
                    sum2 = 0.0;
                    for (int i = 0; i < N; i++)
                    {
                        int[] anket = anketDeger(anketList[i]);
                        double hb = 1.0 / (1.0 + Math.Exp(-(beta[0] + beta[1] * anket[1] + beta[2] * anket[2] + beta[3] * anket[3] + beta[4] * anket[4] + beta[5] * anket[5] +
                        beta[6] * anket[6] + beta[7] * anket[7] + beta[8] * anket[8] + beta[9] * anket[9] + beta[10] * anket[10] + beta[11] * anket[11] + beta[12] * anket[12] +
                        beta[13] * anket[13] + beta[14] * anket[14] + beta[15] * anket[15])));
                        double y = anketList[i].Arkadasmi;
                        sum2 += (hb - y) * anket[j];
                    }
                    newBeta[j] = beta[j] - (stepSize * sum2 / N);//
                }
                for (int i = 0; i < beta.Length; i++)
                {
                    beta[i] = newBeta[i];
                }

            }

            for (int i = 0; i < aranacakList.Count; i++) // en son bulduğumuz betalar ile aranacakList'teki her öğrencinin anket sonuçlarını
                                                         //çarparız ve  çıkan sonucu arkadaşının arkadaşlık değerine atarız.
                                                         //tüm arkadaşı olmayanlar için bu işlem yapılır.
            {
                int[] anket = anketDeger(aranacakList[i]);
                double hb = 1.0 / (1.0 + Math.Exp(-(beta[0] + beta[1] * anket[1] + beta[2] * anket[2] + beta[3] * anket[3] + beta[4] * anket[4] + beta[5] * anket[5] +
                beta[6] * anket[6] + beta[7] * anket[7] + beta[8] * anket[8] + beta[9] * anket[9] + beta[10] * anket[10] + beta[11] * anket[11] + beta[12] * anket[12] +
                 beta[13] * anket[13] + beta[14] * anket[14] + beta[15] * anket[15])));
                aranacakList[i].ArkadaslikDegeri = hb;
            }
            List<AnketModel> BestFriendList = (from x in aranacakList   
                                               orderby x.ArkadaslikDegeri descending
                                               select x).ToList(); // aranacakList'teki arkadaşlık değeri en yüksük'ten en düşüğe doğru sıralanır ve  BestFriendList atılır.


            var OgreciListesi = ExcelReader.OgrenciListesiOku(); //ogrencilistesi.xlsx tekrar okunur.
            List<StudentModel> BestFriends10 = new List<StudentModel>(); //En iyi 10 arkadaş listesi yaratırlır.

            for (int i = 0; i < BestFriendList.Count; i++)  
            {
                for (int j = 0; j < OgreciListesi.Count; j++)
                {
                    if (BestFriendList[i].ARKADAS == OgreciListesi[j].No)  // BestFriendList listesindeki ilk sıradaki arkadaşın numarası ile OgreciListesi'deki numara 
                                                                           //numara karşılaştırılır.Bulduğunda BestFriends10'a arkadaşın adını ve numarasını atar.Bu adım 10 kere devam eder.
                    {
                        if (BestFriends10.Count < 10)
                        {
                            BestFriends10.Add(OgreciListesi[j]);
                        }

                    }
                }
            }
            return BestFriends10; //En iyi 10 arkadaşı geri yollar.
        }

        /// <summary>
        /// Gelen AnketModel'anket alanlarını bir dizi şeklinde geri döner.
        /// </summary>
        /// <param name="anket">AnketModel</param>
        /// <returns>anket değerilerini taşıyan bir dizi</returns>
        private int[] anketDeger(AnketModel anket)
        {
            int[] parseAnket = new int[16];
            parseAnket[0] = 0;
            parseAnket[1] = anket.A1;
            parseAnket[2] = anket.A2;
            parseAnket[3] = anket.A3;
            parseAnket[4] = anket.A4;
            parseAnket[5] = anket.A5;
            parseAnket[6] = anket.A6;
            parseAnket[7] = anket.A7;
            parseAnket[8] = anket.A8;
            parseAnket[9] = anket.A9;
            parseAnket[10] = anket.A10;
            parseAnket[11] = anket.A11;
            parseAnket[12] = anket.A12;
            parseAnket[13] = anket.A13;
            parseAnket[14] = anket.A14;
            parseAnket[15] = anket.A15;

            return parseAnket;
        }
    }
}
