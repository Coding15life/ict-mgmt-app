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
        public int PunchCards { get; set; }
        public string Tier { get; set; }

        public PointCard() { }
        public PointCard(int points,  int punchCard)
        {
            Points = points;
            PunchCards = punchCard;
        }
        public void AddPoints(int p)
        {
            double earned_points = p * 0.72;
            points += p;
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
            PunchCards++;
            if (PunchCards == 11)
            {
                Console.WriteLine("Congratulations! You've earned a free ice cream.");
                PunchCards = 0;
            }
        }
    }
}
