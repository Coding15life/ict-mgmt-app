using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10241539_PRG2Assignment
{
    internal class Order
    {
        private int id;
        private DateTime timeReceived;
        private DateTime? timeFulfilled;

        public int Id { get; set; }
        public DateTime TimeReceived { get; set; }
        public DateTime? TimeFulfilled { get; set; }
        public List<IceCream> IceCreamList = new List<IceCream>();

        public Order() 
        {
            IceCreamList = new List<IceCream>();
        }
        public Order(int id, DateTime timeReceived)
        {
            Id = id;
            TimeReceived = timeReceived;
            TimeFulfilled = DateTime.Now;
        }

        public void ModifyIceCream(int i) 
        {
            if (i < IceCreamList.Count)
            {
                Console.WriteLine("Which ice cream do you want to remove?");
                for (int s = 0; s < IceCreamList.Count; s++)
                {
                    Console.Write($"[{s}] {IceCreamList[s].Scoops} Scoops");
                }
            }
            
        }
        public void AddIceCream(IceCream iceCream)
        {
            IceCreamList.Add(iceCream);
        }
        public void DeleteIceCream(int id)
        {
            IceCreamList.Remove(IceCreamList[id]);
        }
         public double CalculateTotal()
        {
            double total = 0;

            return total;
        }
        public override string ToString()
        {
            string l = "";
            l += ($"Id: {Id} Time Recieved: {TimeReceived} Time Fulfilled: {TimeFulfilled}\n");
            foreach (IceCream I in IceCreamList)
            {
                l += (I.ToString() + "\n");
            }
            return l;
        }


    }
}
