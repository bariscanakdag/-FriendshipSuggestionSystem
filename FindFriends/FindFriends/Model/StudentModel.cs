using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFriends.Model
{
    /// <summary>
    ///Öğrencinin Adını ve Numarasını tutar 
    /// </summary>

    public class StudentModel
    {
        private string adi;

        public string Adi
        {
            get { return adi; }
            set { adi = value; }
        }
        private string no;

        public string No
        {
            get { return no; }
            set { no = value; }
        }


    }
}
