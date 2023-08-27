using System.Runtime.Serialization;

namespace ParkDataLayer.Exceptions
{
    [Serializable]
    internal class HuurderRepositoryException : Exception
    {
        public HuurderRepositoryException()
        {
        }

        public HuurderRepositoryException(string? message) : base(message)
        {
        }

        public HuurderRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected HuurderRepositoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}