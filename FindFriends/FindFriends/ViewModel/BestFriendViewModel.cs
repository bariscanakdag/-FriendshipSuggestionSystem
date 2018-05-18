using FindFriends.Helper;
using FindFriends.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FindFriends.ViewModel
{
    public class BestFriendViewModel
    {
        #region Members

        private ObservableCollection<StudentModel> studentList;

        #endregion

        #region ICommands
        private ICommand closeCommand;

        #endregion

        #region Commands
        public ICommand CloseCommand //Kapat butonu'na basıldığında burası tetiklenir.
        {
            get
            {
                if (closeCommand == null)
                    closeCommand = new RelayCommand(Close);
                return closeCommand;
            }
        }
        #endregion

        #region Properties
        public ObservableCollection<StudentModel> StudentList
        {
            get { return studentList; }
            set { studentList = value; }
        }

        public BestFriendViewModel(List<StudentModel> student)
        {
            StudentList = new ObservableCollection<StudentModel>(student);
        }

        #endregion

        #region EventHandlers

        public event EventHandler CloseWindow;

        #endregion

        #region Methods

        private void Close()
        {
            CloseWindow?.Invoke(null, null); //metod çalıştığında anda CloseWindow eventi aktif olur.
        }
        #endregion

    }
}
