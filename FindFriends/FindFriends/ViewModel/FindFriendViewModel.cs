using FindFriends.Helper;
using FindFriends.Model;
using FindFriends.View;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
namespace FindFriends.ViewModel
{
    public class FindFriendViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gerekli olan değişken ve nesne tanımlamalarım.
        /// </summary>

        #region Members 

        private string arananOgrenci;

        private ObservableCollection<OgrenciProfilModel> profilList;

        private ObservableCollection<OgreciNetworkModel> networkList;

        private BestFriendWindow bestFriendWindow;

        private OgreciNetworkProvider OgreciNetworkProvider = new OgreciNetworkProvider();

        private OgrenciProfilProvider OgrenciProfilProvider = new OgrenciProfilProvider();

        private FindFriendOperation FindFriendOperation = new FindFriendOperation();

        private ExcelReader ExelReader = new ExcelReader();

        private FindFriendProvider FindFriendProvider = new FindFriendProvider();

        #endregion

        /// <summary>
        /// FindFriendWindow'ün  tanıyacağı bu class ile iletişime geçiceği  geçiceği alanlar 
        /// </summary>

        #region Properties

        public string ArananOgrenci
        {
            get { return arananOgrenci; }
            set
            {
                arananOgrenci = value;
                OnPropertyChanged(nameof(arananOgrenci));
            }
        }

        public ObservableCollection<OgrenciProfilModel> ProfilList
        {
            get { return profilList; }
            set
            {
                profilList = value;
                OnPropertyChanged(nameof(ProfilList));
            }
        }

        public ObservableCollection<OgreciNetworkModel> NetworkList
        {
            get { return networkList; }
            set
            {
                networkList = value;
                OnPropertyChanged(nameof(NetworkList));
            }
        }

        #endregion

        /// <summary>
        /// Buton'a tıklandığında etkileşime geçicek alanlar
        /// </summary>

        #region ICommands

        private ICommand arkadasBulCommand;

        private ICommand dosyaAcCommand;

        #endregion

        /// <summary>
        /// Butona tıklandığında metod tetikler.
        /// </summary>
        #region Commands

        public ICommand ArkadasBulCommand
        {
            get
            {
                if (arkadasBulCommand == null)
                    arkadasBulCommand = new RelayCommand(ArkadasBul);
                return arkadasBulCommand;
            }
        }

        public ICommand DosyaAcCommand
        {
            get
            {
                if (dosyaAcCommand == null)
                    dosyaAcCommand = new RelayCommand(DosyaAc);
                return dosyaAcCommand;
            }
        }

        #endregion

        /// <summary>
        /// Bu class'tan nesne üretildiğinde ilk çalışacak yerdir.
        /// </summary>
        #region Constructor

        public FindFriendViewModel()
        {
            NetworkList = new ObservableCollection<OgreciNetworkModel>(OgreciNetworkProvider.OgrenciNetworkGetir());
            ProfilList = new ObservableCollection<OgrenciProfilModel>(OgrenciProfilProvider.ProfilOgrenciGetir());
        }

        #endregion

        /// <summary>
        /// Metodların açıklaması içeride yazmaktatır.
        /// </summary>

        #region Methods

        ///FindFriendOperation nesnesinin BestTenFriend metodu çağırılır.
        ///Metoda aranan öğrencinin numarası veya adı yollanır.
        ///Eğer öğrenci var ise en iyi  10 öğrencinin olduğu bir liste çevirilir.
        ///Bu liste başka bir windowda gösterilme üzere BestFriendWindow'ün constructor'una yollanır.
        ///BestFriendWindow'da en iyi 10 arkadaş adı ve numarası ile gösterilir.

        private void ArkadasBul()
        {
            var BestFriends = FindFriendOperation.BestTenFriend(ArananOgrenci, ProfilList); //Gelen en iyi 10 arkadaş BestFriends atılır.
            if (BestFriends != null)          //Eğer BestFriends boş değilse bestFriendWindow açılır ve bizim en iyi 10 arkadaş window'a gönderilir.
                if (bestFriendWindow == null)
                {
                    bestFriendWindow = new BestFriendWindow(BestFriends); 
                    bestFriendWindow.BestFriendViewModel.CloseWindow += BestFriendViewModelCloseWindow; //burada yeni açılan penceredeki kapat butonuna basılması
                                                                                                        //dinlenir.Eğer basılırsa metod tetiklenir.
                    bestFriendWindow.Closing += BestFriendWindowClosing;
                    bestFriendWindow.Show();
                }
        }

        /// <summary>
        /// BestFriendWindow window'u kapatılırken event tetiklenir ve bu metod çalışır.
        /// window Dispose yardımı ile bellekten atılır ve window null'lanır.
        /// </summary>
        /// <param name="sender">window</param>
        /// <param name="e">null</param>

        private void BestFriendWindowClosing(object sender, CancelEventArgs e)
        {

            bestFriendWindow.Dispose();
            bestFriendWindow = null;
        }

        /// <summary>
        /// BestFriendWindow'daki kapat butonu dinler.Butona basıldığında BestFriendWindow' u kapatır.
        /// Window kapatıldığı için üsteki metod çalışır.Window bellejten atılır ve null'lanır.
        /// </summary>
        /// <param name="sender">null</param>
        /// <param name="e">null</param>
        private void BestFriendViewModelCloseWindow(object sender, EventArgs e)
        {
            bestFriendWindow.Close();
        }

        /// <summary>
        /// Csv dosyası seçildiğinde ilgili veritabanına 
        /// csv dosyasındaki verileri kayıt eder.
        /// Veritabanındaki   kayıtlar Grid'e basılır.
        /// </summary>

        private void DosyaAc()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = @"CSV files (*.csv)|*.csv|XML files (*.xml)|*.xml";
            openFile.DefaultExt = ".csv";
            openFile.ShowDialog();
            ExelReader.ExelRead(openFile.SafeFileName, openFile.FileName);
            if (ProfilList.Count != 90 || NetworkList.Count != 90) // Seçilen dosyadaki değerler direk olarak datagrid'e yansısın diye yazıldı.
            {
                ProfilList = new ObservableCollection<OgrenciProfilModel>(OgrenciProfilProvider.ProfilOgrenciGetir());
                NetworkList = new ObservableCollection<OgreciNetworkModel>(OgreciNetworkProvider.OgrenciNetworkGetir());
            }
        }

        #endregion

        /// <summary>
        /// Bir özellik değiştiğini bağlama bildirmek için kullanır.
        /// Örneğin ArananOgrenci değiştiği zaman  değişiklik ArananOgrenciye set edilir.
        /// </summary>
       
            #region  PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
