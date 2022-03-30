using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAAutomationLab.BusinessLayer.Models
{
    public class StaysSearchingContext
    {
        public string Destination { get; set; }
        
        public DateTime DateFrom { get; set; }
        
        public DateTime DateTo { get; set; }

        public int AdultsCount { get; set; }

        public int ChildrenCount { get; set; }

        public int RoomsCount { get; set; }

        public int[] ChildrenAge { get; set; }
    }
}
