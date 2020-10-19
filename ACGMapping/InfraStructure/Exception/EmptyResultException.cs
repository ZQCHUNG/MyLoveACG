using System;
using System.Runtime.Serialization;

namespace ACGMapping.InfraStructure.Exception
{
    [Serializable]
    public class EmptyResultException : System.Exception
    {
        public EmptyResultException()
        {
        }

        public EmptyResultException(string message) : base(message)
        {
        }

        public EmptyResultException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected EmptyResultException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}