using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster_WPF.Models
{
    public class Roster
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Day { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Color { get; set; }
        public bool Is_6_OClock { get; set; }
        public bool Is_7_OClock { get; set; }
        public bool Is_8_OClock { get; set; }
        public bool Is_9_OClock { get; set; }
        public bool Is_10_OClock { get; set; }
        public bool Is_11_OClock { get; set; }
        public bool Is_12_OClock { get; set; }
        public bool Is_13_OClock { get; set; }
        public bool Is_14_OClock { get; set; }
        public bool Is_15_OClock { get; set; }
        public bool Is_16_OClock { get; set; }
        public bool Is_17_OClock { get; set; }
        public bool Is_18_OClock { get; set; }
        public bool Is_19_OClock { get; set; }
        public bool Is_20_OClock { get; set; }
        public bool Is_21_OClock { get; set; }
        public bool Is_22_OClock { get; set; }
        public bool Is_23_OClock { get; set; }
        public bool Is_24_OClock { get; set; }

    }
}
