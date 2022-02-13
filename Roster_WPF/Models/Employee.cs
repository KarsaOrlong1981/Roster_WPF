using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster_WPF.Models
{
    public class Employee
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Layer { get; set; }
        public string Color { get; set; }
        public int OperatingTime { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public double HoursNow { get; set; }
        public double HoursMonth { get; set; }
        public double MissingHours { get; set; }
        public string PhoneNumber { get; set; }
        public string HolidayStart { get; set; }
        public string HolidayEnd { get; set; }
        public string HealthInsuranceCert_Start { get; set; }
        public string HealthInsuranceCert_End { get; set; }
        public string Place { get; set; }
        
    }
}
