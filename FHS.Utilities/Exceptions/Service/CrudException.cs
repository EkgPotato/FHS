using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using FHS.Resources.Exceptions;

namespace FHS.Utilities.Exceptions.Service
{
    public class ModelNullException : Exception
    {
        public ModelNullException() : base(CrudExceptionMessages.ModelNullException)
        { 
        }

        public ModelNullException(string? message) : base(message)
        {
        }

        public ModelNullException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ModelNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public class InvalidIdException : Exception
    {
        public InvalidIdException() : base(CrudExceptionMessages.InvalidIdException)
        {
        }

        public InvalidIdException(string? message) : base(message)
        {
        }

        public InvalidIdException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
