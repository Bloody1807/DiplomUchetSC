using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomUchetSC.Models
{
    [Table("client")]
    public class Client
    {
        public int Id { get; set; }
        public string Full_name { get; set; }
        public string Number_phone { get; set; }
        public bool Is_problematic { get; set; }
    }
}
