using FindFriends.Helper;
using FindFriends.View;

using System.Windows;

namespace FindFriends
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            new DatabaseHelper().CheckDatabase();
            FindFriendWindow window = new FindFriendWindow();
            window.Show();
        }
    }
}
