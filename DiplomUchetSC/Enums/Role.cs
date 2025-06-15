using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomUchetSC.Enums
{
    public enum Role
    {
        [Display(Name = "Директор")]
        DIRECTOR,
        [Display(Name = "Администратор")]
        ADMIN,
        [Display(Name = "Мастер")]
        REPAIRMAN,
    }
}
