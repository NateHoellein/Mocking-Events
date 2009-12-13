using FireEvents;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace MockingEvents
{
    [TestFixture]
    public class ControllerTests
    {
        MockRepository mocks;
        IPresenter presenter;

        [SetUp]
        public void Setup()
        {
            this.mocks = new MockRepository();
            this.presenter = mocks.StrictMock<IPresenter>();
        }

        [Test]
        public void ShouldMakeSureSomethingSubscribesToMyEvent()
        {
            Expect.Call(delegate { presenter.FireEvent += null; }).Constraints(Is.NotNull());
            mocks.ReplayAll();
            new Controller(presenter);
        }

        [Test]
        public void ShouldSetTheMessageInEventOnPresenterSetMessage()
        {
            Expect.Call(delegate { presenter.FireEvent += null; }).Constraints(Is.NotNull());
            var raiser = LastCall.GetEventRaiser();
            Expect.Call(() => presenter.SetMessage(null)).Constraints(Is.NotNull());

            mocks.ReplayAll();
            new Controller(presenter);
            raiser.Raise(null,new FireEventArgs());
        }

        [TearDown]
        public void Teardown()
        {
            mocks.VerifyAll();
        }
    }
}