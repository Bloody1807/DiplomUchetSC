using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomUchetSC.Enums
{
    public enum Guarantee
    {
        [Display(Name = "14 Дней")]
        FOURTEENDAYS,
        [Display(Name = "30 Дней")]
        THIRTYDAYS,
        [Display(Name = "60 Дней")]
        SIXTYDAYS,
        [Display(Name = "90 Дней")]
        NINETYDAYS
    }


}
