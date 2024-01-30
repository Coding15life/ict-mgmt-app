using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//==========================================================
// Student Number : S10241539
// Student Name : Javier Lim
// Partner Name : Keshav P Chidambaram
//==========================================================

namespace S10241539_PRG2Assignment
{
    internal class PointCard
    {
        //Creating private points, punchcard and tier objects to ensure that the initialization code is only called when necessary
        private int points;
        private int punchCard;
        private string tier;

        //Initializing the public points, punchcard and tier objects to get inputs that can be used later in the class
        public int Points { get; set; }
        public int PunchCard { get; set; }
        public string Tier { get; set; }

        //Constructor
        public PointCard() { }
        public PointCard(int points,  int punchCard)
        {
            Points = points;
            PunchCard = punchCard;
        }

        //Creating a method AddPoints that adds points gained by a customer to their total amount of points
        public void AddPoints(int p)
        {
            double earned_points = p * 0.72;
            points += p;
            //To check if the customer has already reached gold before
            if (tier == "Gold")
            {
                tier = "Gold";
            }
            //To check if the customer has already reached silver before and if so to determine if they have enough total points to get to a new tier
            else if (tier == "Silver")
            {
                if (points >= 100)
                {
                    Tier = "Gold";
                }
                else
                {
                    tier = "Silver";
                }
            } 
            //To determine the tier of the customer based on their points
            else
            {
                if (points >= 50)
                {
                    Tier = "Silver";
                }
                else if (points >= 100)
                {
                    Tier = "Gold";
                }
                else
                {
                    Tier = "Ordinary";
                }
            }

            
        }

        //Creating a method RedeemPoints that allows the customer to Redeem their total points
        public void RedeemPoints(int p)
        {
            //Checking if the customer has enough balance points to successfully get through with their transaction
            if (Points > p)
            {
                Points -= p;
                Console.WriteLine($"Transaction Successful!\nPoints Balance: {Points}");
            }
            //Telling the customer they do not have enough points to continue the transaction
            else
            {
                Console.WriteLine($"Insufficient points to make this transaction!\nPoints Balance: {Points}");
            }
        }

        //Creating a method Punch that adds a punch to the customers' punchcard and checks if the customer can redeem a free ice cream
        public void Punch()
        {
            PunchCard++;
            //checks if has enough punches on their punch card to redeem a free ice cream
            if (PunchCard == 11)
            {
                Console.WriteLine("Congratulations! You've earned a free ice cream.");
                PunchCard = 0;
            }
        }
        //Prints out the details of a Cup object
        public override string ToString()
        {
            return $"Points: {Points}\nPunchs on Punch Card: {PunchCard}\nTier: {Tier}";
        }
    }
}
