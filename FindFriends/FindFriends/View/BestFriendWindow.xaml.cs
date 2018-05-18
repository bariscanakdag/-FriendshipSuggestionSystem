using FindFriends.Model;
using FindFriends.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FindFriends.View
{
    /// <summary>
    /// Interaction logic for BestFriendWindow.xaml
    /// </summary>

   
    public partial class BestFriendWindow : Window,IDisposable
    {
        public BestFriendViewModel BestFriendViewModel;
        public BestFriendWindow(List<StudentModel> student)
        {
            BestFriendViewModel = new BestFriendViewModel(student);
            InitializeComponent();
            DataContext = BestFriendViewModel;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }

   
    }
}
