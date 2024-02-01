using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
    public class Flavour
    {
        private string type;
        private bool premium;

        public string Type { get; set; }
        public bool Premium { get; set; }

        public Flavour() { }

        public Flavour(string flavourType, bool isPremium)
        {
            Type = flavourType;
            Premium = isPremium;
        }

        public override string ToString()
        {
            return $"\tFlavour option: {Type}\tPremium flavour: {Premium}";
        }
    }
}
