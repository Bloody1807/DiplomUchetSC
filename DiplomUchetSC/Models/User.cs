﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomUchetSC.Enums;

namespace DiplomUchetSC.Models
{
    [Table("user")]

    public class User
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

    }
}
