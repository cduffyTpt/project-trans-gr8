using System.Runtime.Serialization;

namespace TransGr8_DD_Test
{
    internal class SpellNotFoundException : Exception
    {
        public SpellNotFoundException()
        {
        }

        public SpellNotFoundException(string message) : base(message)
        {
        }

        public SpellNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SpellNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
