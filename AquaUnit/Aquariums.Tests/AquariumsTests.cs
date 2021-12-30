namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void NameShouldThrow()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 10));
        }

        [Test]
        public void CapacityShouldThow()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Gosho", -10));
        }

        [Test]
        public void CountWorksProperly()
        {
            Aquarium aquarium = new Aquarium("Gosho", 10);
            var fish = new Fish("Pesho");
            aquarium.Add(fish);

            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void AddThrows()
        {
            Aquarium aquarium = new Aquarium("Gosho", 1);
            var fish = new Fish("Pesho");
            var fish2 = new Fish("Pesho2");
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish2));
        }

        [Test]
        public void RemoveThrows()
        {
            Aquarium aquarium = new Aquarium("Gosho", 1);
            var fish = new Fish("Pesho");
            var fish2 = new Fish("Pesho2");
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Pesho2"));
        }

        [Test]
        public void RemoveWorks()
        {
            Aquarium aquarium = new Aquarium("Gosho", 3);
            var fish = new Fish("Pesho");
            var fish2 = new Fish("Pesho2");
            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.RemoveFish("Pesho");

            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void SellThrows()
        {
            Aquarium aquarium = new Aquarium("Gosho", 1);
            var fish = new Fish("Pesho");
            var fish2 = new Fish("Pesho2");
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Pesho2"));
        }

        [Test]
        public void SellWorks()
        {
            Aquarium aquarium = new Aquarium("Gosho", 1);
            var fish = new Fish("Pesho");
            var fish2 = new Fish("Pesho2");
            aquarium.Add(fish);

            Assert.AreEqual(fish, aquarium.SellFish("Pesho"));
        }

        [Test]
        public void ReportWorks()
        {
            Aquarium aquarium = new Aquarium("Gosho", 1);
            var fish = new Fish("Pesho");
            aquarium.Add(fish);

            Assert.AreEqual("Fish available at Gosho: Pesho", aquarium.Report());
        }
    }
}
