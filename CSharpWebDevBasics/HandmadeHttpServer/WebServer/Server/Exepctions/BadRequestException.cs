﻿using System;
using System.Runtime.Serialization;

namespace WebServer.Server.Exepctions
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message) 
            : base(message)
        {
        }

        public BadRequestException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}