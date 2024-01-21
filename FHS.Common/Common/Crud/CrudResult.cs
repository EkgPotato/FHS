using FHS.Interfaces.Common.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHS.Utilities.Common.Crud
{
    public sealed class CrudResult : ICrudResult
    {
        public List<string> Messages { get; set; }
        public CrudResult()
        {
            Messages = new List<string>();
        }

        public bool Succeed()
        {
            return Messages.Count == 0;
        }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }
    }
}
