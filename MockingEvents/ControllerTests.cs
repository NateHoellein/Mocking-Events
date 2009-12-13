using FireEvents;
using NUnit.Framework;
using Rhino.Mocks;

namespace MockingEvents
{
    [TestFixture]
    public class ControllerTests
    {
        MockRepository mocks;

        [SetUp]
        public void Setup()
        {
            this.mocks = new MockRepository();
        }

        [Test]
        public void ShouldMakeSureSomethingSubscribesToMyEvent()
        {
            var presenter = mocks.StrictMock<IPresenter>();

            Expect.Call(delegate { presenter.FireEvent += null; }).IgnoreArguments();

            mocks.ReplayAll();

            new Controller(presenter);
        }

        [TearDown]
        public void Teardown()
        {
            mocks.VerifyAll();
        }
    }
}