﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomUchetSC.Models
{
    [Table("brand")]
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
