using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreOrderKue
{
    class Buyer
    {
        public string NickName { get; set; }
        public int Ammount { get; set; }
        public int Total { get; set; }

        public Buyer(string nickName, int ammount, int total)
        {
            NickName = nickName;
            Ammount = ammount;
            Total = total;
        }
    }
}
