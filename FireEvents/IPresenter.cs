using System;

namespace FireEvents
{
    public interface IPresenter
    {
        event EventHandler<FireEventArgs> FireEvent;
        void SetMessage(string message);
    }
}