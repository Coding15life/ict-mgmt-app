using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return base.ToString() + $"\tTopping: {Type}";
        }
    }
}
