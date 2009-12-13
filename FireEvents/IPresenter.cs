using System;

namespace MockingEvents
{
    public interface IPresenter
    {
        event EventHandler<FireEventArgs> FireEvent;
    }
}