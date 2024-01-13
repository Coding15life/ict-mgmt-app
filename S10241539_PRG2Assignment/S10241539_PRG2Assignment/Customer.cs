using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10241539_PRG2Assignment
{
    internal class Customer
    {
        private string name;
        private int memberId;
        private DateTime dob;
        private Order currentOrder;
        private List<Order> orderHistory;
        private PointCard rewards;

        public string Name { get; set; }
        public int MemberId { get; set; }
        public DateTime Dob { get; set; }
        List<Order> OrderHistory = new List<Order>();
        public PointCard Rewards { get; set; }

        public Customer() { }
        public Customer(string n, int m, DateTime d)
        {
            Name = n;
            MemberId = m;
            Dob = d;
        }
        public Order MakeOrder()
        {
            Order ord = new Order(MemberId, DateTime.Now);
            return ord;
        }
        public bool IsBirthday()
        {
            if (Dob == DateTime.Now) 
            { 
                return true;
            }
            else 
            {
                return false; 
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
