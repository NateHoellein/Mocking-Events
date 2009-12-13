using System;

namespace FireEvents
{
    public class FireEventArgs : EventArgs
    {
        public string Message { get; set; }

        public FireEventArgs(string message)
        {
            Message = message;
        }
    }
}