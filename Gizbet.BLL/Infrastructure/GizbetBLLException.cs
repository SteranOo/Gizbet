using System;

namespace Gizbet.BLL.Infrastructure
{
    /// <summary>
    /// Common Gizbet Exception
    /// </summary>
    public class GizbetBLLException : Exception
    {
        public GizbetBLLException() { }
        public GizbetBLLException(string message) : base(message) {}
        public GizbetBLLException(string message, Exception exception) : base(message, exception) { }
    }
}
