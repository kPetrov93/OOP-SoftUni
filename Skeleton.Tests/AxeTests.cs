using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLosesDurabilityAfterAtack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability doesn't change after attack.");

        }

        [Test]
        public void AttackingWithBrokenWeapon()
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            
        }


    }
}