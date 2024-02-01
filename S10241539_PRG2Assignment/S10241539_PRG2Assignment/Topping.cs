using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//==========================================================
// Student Number : S10241539
// Student Name : Javier Lim
// Partner Name : Keshav P Chidambaram
// Partner Number : S10257135
//==========================================================

namespace S10241539_PRG2Assignment
{
    public class Topping
    {
        private string type;

        public string Type { get; set; }

        public Topping() { }

        public Topping(string toppingType)
        {
            Type = toppingType;
        }

        public override string ToString()
        {
            return Type;
        }
    }
}
