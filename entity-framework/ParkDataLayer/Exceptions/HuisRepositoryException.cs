using System.Runtime.Serialization;

namespace ParkDataLayer.Exceptions
{
    [Serializable]
    internal class HuisRepositoryException : Exception
    {
        public HuisRepositoryException()
        {
        }

        public HuisRepositoryException(string? message) : base(message)
        {
        }

        public HuisRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected HuisRepositoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}