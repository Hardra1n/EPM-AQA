using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAAutomationLab.CoreLayer.APIElement
{
    public class ErrorMessage
    {
        public int Status { get; set; }

        public Dictionary<string, string> Error { get; set; }
    }
}
