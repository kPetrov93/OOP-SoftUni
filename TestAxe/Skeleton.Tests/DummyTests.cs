using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthWhenAttacked()
        {
            Axe axe = new Axe(5, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(dummy.Health, Is.EqualTo(5), "Dummy healt points doesn't change.");
        }

        
    }
}