using AquaShop.Core.Contracts;
using AquaShop.Models;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
                aquariums.Add(aquarium);
                return $"Successfully added {aquariumType}.";
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
                aquariums.Add(aquarium);
                return $"Successfully added {aquariumType}.";
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
                decorations.Add(decoration);
                return $"Successfully added {decorationType}.";
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
                decorations.Add(decoration);
                return $"Successfully added {decorationType}.";
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            
        }

        public string CalculateValue(string aquariumName)
        {
            throw new NotImplementedException();
        }

        public string FeedFish(string aquariumName)
        {
            throw new NotImplementedException();
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var dec = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            if (dec == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            else
            {
                dec.AddDecoration(this.AddDecoration(decorationType));
                
                return $"Successfully added {decorationType} to {aquariumName}.";
            }
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
