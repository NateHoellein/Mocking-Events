using NUnit.Framework;
using Rhino.Mocks;

namespace MockingEvents
{
    [TestFixture]
    public class ControllerTests
    {
        [SetUp]
        public void Setup()
        {
            var mocks = new MockRepository();
            var mocks = new MockRepository();
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

    public interface IPresenter
    {
    }
}