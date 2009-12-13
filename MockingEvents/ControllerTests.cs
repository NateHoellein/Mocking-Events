using System;
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
            mocks = new MockRepository();
            presenter = mocks.StrictMock<IPresenter>();
        }

        [Test]
        public void ShouldMakeSureSomethingSubscribesToMyEvent()
        {
            Expect.Call(delegate { presenter.FireEvent += null; }).Constraints(Is.NotNull());
            mocks.ReplayAll();
            new Controller(presenter);
            mocks.VerifyAll();
        }

        [Test]
        public void ShouldSetTheMessageInEventOnPresenterSetMessage()
        {
            Expect.Call(delegate { presenter.FireEvent += null; }).Constraints(Is.NotNull());
            var raiser = LastCall.GetEventRaiser();
            Expect.Call(() => presenter.SetMessage(null)).Constraints(Is.NotNull());

            mocks.ReplayAll();
            new Controller(presenter);
            raiser.Raise(null, new FireEventArgs(""));
            mocks.VerifyAll();
        }

        [Test]
        public void ShouldVerifyTheMessageInFireEventGetsAppendedFromController()
        {
            Expect.Call(delegate { presenter.FireEvent += null; }).Constraints(Is.NotNull());
            var raiser = LastCall.GetEventRaiser();
            Predicate<string> isThisTheRightMessage = delegate(string m)
                                                          {
                                                              Assert.AreEqual("I have been fired! Now I have been set",
                                                                              m);
                                                              return true;
                                                          };
            Expect.Call(() => presenter.SetMessage(null)).Constraints(
                new PredicateConstraint<string>(isThisTheRightMessage));

            mocks.ReplayAll();
            new Controller(presenter);
            raiser.Raise(null, new FireEventArgs("I have been fired!"));
            mocks.VerifyAll();
        }
    }
}