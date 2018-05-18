using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFriends.Helper
{
    public abstract class SQLiteBaseProvider
    {
        private DatabaseHelper databaseHelper;

        /// <summary>
        /// Factory design pattern kullanılmıştır.Veritabanı işlemlerinde bir nesne üretimine gerek kalınmıyacaktır.
        /// Nesne hazır olarak kullanıcıya sunulacaktır.
        /// </summary>
        public DatabaseHelper DatabaseHelper
        {
            get
            {
                if (databaseHelper == null)
                    databaseHelper = new DatabaseHelper();
                return databaseHelper;
            }
        }
    }
}
