using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

//==========================================================
// Student Number : S10241539
// Student Name : Javier Lim
// Partner Name : Keshav P Chidambaram
//==========================================================

namespace S10241539_PRG2Assignment
{
    public class Cone : IceCream
    {
        private bool dipped;

        public bool Dipped { get; set; }

        public Cone() { }

        public Cone(string servingOptions, int numOfScoops, List<Flavour> iceCreamFlavours, List<Topping> iceCreamToppings, bool isDipped) : base(servingOptions, numOfScoops, iceCreamFlavours, iceCreamToppings)
        {
            Dipped = isDipped;
        }

        public override double CalculatePrice()
        {
            // Initial price.
            double iceCreamPrice = 0.00;

            // Determine the initial price based on scoops.
            if (Scoops == 1)
            {
                iceCreamPrice = 4.00;
            }
            else if (Scoops == 2)
            {
                iceCreamPrice = 5.50;
            }
            else
            {
                iceCreamPrice = 6.50;
            }

            // Looping through "Flavours" list to calculate total price of premium flavours.
            foreach (Flavour flavourDetails in Flavours)
            {
                if (flavourDetails.Premium)
                {
                    iceCreamPrice += 2.00;
                } 
            }

            // Calculating the total price of toppings.
            iceCreamPrice += 1.00 * Toppings.Count;

            // Checking if dipped chocolate cone is selected.
            // If it is, additional price will be charged accordingly.
            if (Dipped)
            {
                iceCreamPrice += 2.00;
            }

            // Return the final price of the ice cream.
            return iceCreamPrice;
        }
    }
}
