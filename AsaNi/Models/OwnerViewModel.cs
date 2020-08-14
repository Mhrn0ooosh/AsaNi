using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsaNi.Models
{
    public class OwnerViewModel
    {
        public OwnerViewModel()
        {
            FullName = FirstName + " " + LastName;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
    }
}
