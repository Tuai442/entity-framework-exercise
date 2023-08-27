using System.Runtime.Serialization;

namespace ParkDataLayer.Exceptions
{
    [Serializable]
    internal class HuurderContractRepositoryException : Exception
    {
        public HuurderContractRepositoryException()
        {
        }

        public HuurderContractRepositoryException(string? message) : base(message)
        {
        }

        public HuurderContractRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected HuurderContractRepositoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}