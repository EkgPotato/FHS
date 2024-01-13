using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using FHS.Resources.Exceptions;

namespace FHS.Utilities.Exceptions.Service
{
    public class CreateModelNullException : Exception
    {
        public CreateModelNullException() : base(CrudExceptionMessages.CreateModelNullException)
        { 
        }

        public CreateModelNullException(string? message) : base(message)
        {
        }

        public CreateModelNullException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CreateModelNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
