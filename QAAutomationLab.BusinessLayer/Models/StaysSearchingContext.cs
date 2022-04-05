using System;

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

        public static StaysSearchingContext GetDefaultContext() 
        {
            return new StaysSearchingContext()
            {
                Destination = "Warsaw",
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now.AddDays(1),
                AdultsCount = 3,
                ChildrenCount = 1,
                RoomsCount = 2,
                ChildrenAge = new int[] { 13 }
            };
        }
    }
}
