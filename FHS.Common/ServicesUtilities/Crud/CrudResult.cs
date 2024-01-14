using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHS.Utilities.ServicesUtilities.Crud
{
    public sealed class CrudResult
    {
        public List<string> Messages { get; set; }
        public List<string> ValidationMessages { get; set; }
        public CrudResult() 
        {
            Messages = new List<string>();
            ValidationMessages = new List<string>();
        }
        
        public bool Succeed()
        {
            return Messages.Count == 0;
        }
    }
}
