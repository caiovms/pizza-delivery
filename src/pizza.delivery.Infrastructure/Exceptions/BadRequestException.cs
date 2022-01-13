using System;
using System.Runtime.Serialization;

namespace pizza.delivery.Infrastructure.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException()
        { }

        public BadRequestException(string message)
            : base(message)
        { }

        public BadRequestException(string message, object[] args)
            : base(message, args)
        { }

        public BadRequestException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public BadRequestException(string message, object[] args, Exception innerException)
            : base(message, args, innerException)
        { }

        public BadRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}