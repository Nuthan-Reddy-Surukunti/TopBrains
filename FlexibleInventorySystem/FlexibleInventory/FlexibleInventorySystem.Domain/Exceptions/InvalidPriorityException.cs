using System;

namespace FlexibleInventorySystem.Domain.Exceptions
{
    public class InvalidPriorityException : Exception
    {
        public InvalidPriorityException(string message) : base(message) { }
    }
}