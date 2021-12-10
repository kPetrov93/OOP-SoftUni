using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismRaiding
{
    public class Paladin : BaseHero
    {

        public Paladin(string name, int power) : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
