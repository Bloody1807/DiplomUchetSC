using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomUchetSC.Enums;

namespace DiplomUchetSC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Issued_at { get; set; }
        public Client Client { get; set; }
        public DeviceType DeviceType { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string Fault { get; set; }
        public int Premilinary_cost { get; set; }
        public int Prepayment { get; set; }
        public int Final_cost { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Guarantee Guarantee { get; set; }
        public string? Comments { get; set; }
        public string Completed_work { get; set; }



    }
}
