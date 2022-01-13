using System;
using System.Linq;
using System.Runtime.Serialization;

namespace pizza.delivery.Infrastructure.Exceptions
{
    public abstract class BaseException : Exception
    {
        public BaseException()
        { }

        public BaseException(string message)
            : base(message)
        { }

        public BaseException(string message, object[] args)
          : base(GetMessage(message, args))
        { }

        public BaseException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public BaseException(string message, object[] args, Exception innerException)
           : base(GetMessage(message, args), innerException)
        { }

        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        private static string GetMessage(string message, params object[] args)
        {
            if (string.IsNullOrWhiteSpace(message) || !(args?.Any() ?? false))
            {
                return message;
            }

            var formattedMessage = string.Format(message, args);

            return formattedMessage;
        }
    }
}
