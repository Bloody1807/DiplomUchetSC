using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomUchetSC.Enums;

namespace DiplomUchetSC.Models
{
    [Table("personal")]
    public class Personal
    {
        public int Id { get; set; }
        public string Number_phone { get; set; }
        public string Email { get; set; }
        public string Second_name { get; set; }
        public string First_name { get; set; }
        public User User { get; set; }

    }
}
