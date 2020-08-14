using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsaNi.Models
{
    public class OperateHouseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "شماره")]
        public string Number { get; set; }

        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name = "متراژ")]
        public int Area { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Display(Name = "ملک شمالی")]
        public bool IsNorthern { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        [Display(Name = "نام مالک")]
        public int? OwnerId { get; set; }
        public OwnerViewModel Owner { get; set; }
    }
}
