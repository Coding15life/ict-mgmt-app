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
    internal class Customer
    {
        //Creating private name, memberId, dob objects to ensure that the initialization code is only called when necessary
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
            Order ord = new Order();
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
