using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DiplomUchetSC.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Принят")]
        ACCEPTED,
        [Display(Name = "На диагностике")]
        DIAGNOSTIC,
        [Display(Name = "Ждет запчасть")]
        WAITING,
        [Display(Name = "В работе")]
        REPAIR,
        [Display(Name = "Готов")]
        FINISHED,
        [Display(Name = "Выдан")]
        ISSUED,
        [Display(Name = "Принят по гарантии")]
        GUARANTEE
    }



}
