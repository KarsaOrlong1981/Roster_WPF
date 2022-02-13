using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Roster_WPF.Models
{
    public class Roster
    {
        
        public int Id { get; set; }
        public string Day { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Color { get; set; }
     
        public Visibility Is_6_OClock { get; set; }
        
        public Visibility Is_7_OClock { get; set; }
        
        public Visibility Is_8_OClock { get; set; }
      
        public Visibility Is_9_OClock { get; set; }
        public Visibility Is_10_OClock { get; set; }

        public Visibility Is_11_OClock { get; set; }
       
        public Visibility Is_12_OClock { get; set; }
       
        public Visibility Is_13_OClock { get; set; }
       
        public Visibility Is_14_OClock { get; set; }
       
        public Visibility Is_15_OClock { get; set; }
        
        public Visibility Is_16_OClock { get; set; }
       
        public Visibility Is_17_OClock { get; set; }
       
        public Visibility Is_18_OClock { get; set; }
        public Visibility Is_19_OClock { get; set; }
        public Visibility Is_20_OClock { get; set; }
        public Visibility Is_21_OClock { get; set; }
        public Visibility Is_22_OClock { get; set; }
        public Visibility Is_23_OClock { get; set; }
        public Visibility Is_24_OClock { get; set; }

    }
}
