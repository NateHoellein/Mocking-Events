using System;

namespace FireEvents
{
    public class Controller
    {
        readonly IPresenter presenter;

        public Controller(IPresenter presenter)
        {
            this.presenter = presenter;
            presenter.FireEvent += PresenterFireEvent;
        }

        void PresenterFireEvent(object sender, FireEventArgs e)
        {
            presenter.SetMessage(e.Message + " Now I have been set");
        }
    }
}