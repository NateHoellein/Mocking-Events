using System;

namespace FireEvents
{
    public class Controller
    {
        public Controller(IPresenter presenter)
        {
            presenter.FireEvent += delegate { };
        }
    }
}