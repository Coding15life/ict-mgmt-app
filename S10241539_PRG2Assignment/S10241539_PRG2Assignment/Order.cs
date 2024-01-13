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
        private List<IceCream> iceCreamList;

        public int Id { get; set; }
        public DateTime TimeReceived { get; set; }
        public DateTime? TimeFulfilled { get; set; }
        List<IceCream> IceCreamList = new List<IceCream>();

        public Order() { }
        public Order(int id, DateTime timeReceived)
        {
            Id = id;
            TimeReceived = timeReceived;
        }

        public void ModifyIceCream(int i) 
        {
            
        }
        public void AddIceCream(IceCream iceCream)
        {
            IceCreamList.Add(iceCream);
        }
        public void DeleteIceCream(int id)
        {
            if (IceCreamList.Count > 0)
            {
                IceCreamList.RemoveAt(id);
            }
        }
         public double CalculateTotal()
        {
            double total = 0;

            return total;
        }


    }
}
