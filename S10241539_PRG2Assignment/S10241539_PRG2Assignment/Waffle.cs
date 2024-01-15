using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace S10241539_PRG2Assignment
{
    public class Waffle : IceCream
    {
        private string waffleFlavour;

        public string WaffleFlavour { get; set; }

        public Waffle() { }

        public Waffle(string servingOptions, int numOfScoops, List<Flavour> iceCreamFlavours, List<Topping> iceCreamToppings, string waffleChosen) : base(servingOptions, numOfScoops, iceCreamFlavours, iceCreamToppings)
        {
            WaffleFlavour = waffleChosen;
        }

        public override double CalculatePrice()
        {
            // Initial price.
            double iceCreamPrice = 0.00;

            // Determine the initial price based on scoops.
            if (Scoops == 1)
            {
                iceCreamPrice = 7.00;
            }
            else if (Scoops == 2)
            {
                iceCreamPrice = 8.50;
            }
            else
            {
                iceCreamPrice = 9.50;
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

            // Check if special flavour for waffle is selected.
            // If so, an additional cost should be added.
            if (WaffleFlavour == "Red velvet" || WaffleFlavour == "Charcoal" || WaffleFlavour == "Pandan")
            {
                iceCreamPrice += 3.00;
            }

            // Return the final price of the ice cream.
            return iceCreamPrice;
        }
    }
}
