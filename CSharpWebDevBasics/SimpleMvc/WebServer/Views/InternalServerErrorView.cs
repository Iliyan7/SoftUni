using System;
using WebServer.Contracts;

namespace WebServer.Views
{
    internal class InternalServerErrorView : IView
    {
        private Exception exception;

        public InternalServerErrorView(Exception exception)
        {
            this.exception = exception;
        }

        public string View()
        {
            return $"<h1>{this.exception.Message}</h1><h2>{this.exception.StackTrace}</h2>";
        }
    }
}