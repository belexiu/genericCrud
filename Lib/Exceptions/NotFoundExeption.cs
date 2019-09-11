using System;

namespace Lib.Exceptions
{
    public class NotFoundExeption : Exception
    {
        public string Id { get; set; }

        public NotFoundExeption(string entityId, Exception innerException = null)
            : base($"Could not found entity with Id =\"{entityId}\"", innerException)
        {
            Id = entityId;
        }
    }
}
