namespace AquaShop.Models.Fishes.Contracts
{
    using System;

    public interface IFish
    {
        string Name { get; }

        string Species { get; }

        int Size { get; }

        decimal Price { get; }

        void Eat();
    }
}
