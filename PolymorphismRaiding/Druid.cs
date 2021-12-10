using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismRaiding
{
    public class Druid : BaseHero
    {

        public Druid(string name,int power) : base(name,power)
        {
        }


        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
