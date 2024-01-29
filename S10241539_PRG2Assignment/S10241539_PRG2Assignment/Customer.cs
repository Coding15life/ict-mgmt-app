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
        private PointCard rewards;
        public string Name { get; set; }
        public int MemberId { get; set; }
        public DateTime Dob { get; set; }
        public List<Order> OrderHistory = new List<Order>();
        public PointCard Rewards { get; set; }

        public Customer() 
        {
            OrderHistory = new List<Order>();
        }
        public Customer(string n, int m, DateTime d)
        {
            Name = n;
            MemberId = m;
            Dob = d;
        }
        public Order MakeOrder()
        {
            Order ord = new Order(MemberId, DateTime.Now);
            OrderHistory.Add(ord);
            return ord;
        }
        public bool IsBirthday()
        {
            if (Dob == DateTime.Today) 
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
            return $"Name: {Name}\nMember ID: {MemberId}\nDate of Birth: {Dob.ToString("dd/MM/yyyy")}";
        }
    }
}
