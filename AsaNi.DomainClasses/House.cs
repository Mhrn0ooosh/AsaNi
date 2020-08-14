using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsaNi.DomainClasses
{
    public class House
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public int Area { get; set; }
        public string Address { get; set; }
        public bool IsNorthern { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        //FK
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual Owner Owner { get; set; }
    }
}
