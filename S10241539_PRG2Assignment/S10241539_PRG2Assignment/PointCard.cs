using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10241539_PRG2Assignment
{
    internal class PointCard
    {
        private int points;
        private int punchCard;
        private string tier;

        public int Points { get; set; }
        public int PunchCard { get; set; }
        public string Tier { get; set; }

        public PointCard() { }
        public PointCard(int points,  int punchCard)
        {
            Points = points;
            PunchCard = punchCard;
        }
        public void AddPoints(int p)
        {
            double earned_points = p * 0.72;
            points += p;
            if (tier == "Gold")
            {
                tier = "Gold";
            } else if (tier == "Silver")
            {
                if (points >= 100)
                {
                    Tier = "Gold";
                }
                else
                {
                    tier = "Silver";
                }
            } else
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
        public void RedeemPoints(int p)
        {
            if (Points > p)
            {
                Points -= p;
                Console.WriteLine($"Points Balance: {Points}");
            }
            else
            {
                Console.WriteLine("Insufficient points to make this transaction");
            }
        }
        public void Punch()
        {
            PunchCard++;
            if (PunchCard == 11)
            {
                Console.WriteLine("Congratulations! You've earned a free ice cream.");
                PunchCard = 0;
            }
        }
        public override string ToString()
        {
            return $"Points: {Points}\nPunch Card: {PunchCard}\nTier: {Tier}";
        }
    }
}
