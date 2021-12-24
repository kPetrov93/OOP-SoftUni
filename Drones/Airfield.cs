using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> Drones;

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public double LandingStrip { get; set; }

        public int Count { get { return Drones.Count; } }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            else if (Count == Capacity)
            {
                return "Airfield is full.";
            }
            else
            {
                Drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";
            }
        }

        public bool RemoveDrone(string name)
        {
            var drone = Drones.FirstOrDefault(x => x.Name == name);
            return Drones.Remove(drone);
        }

        public int RemoveDroneByBrand(string brand)
        {
            int counter = 0;

            foreach (var item in Drones)
            {
                if (item.Brand == brand)
                {
                    counter++;
                }
            }

            Drones.RemoveAll(x => x.Brand == brand);

            return counter;
        }

        public Drone FlyDrone(string name)
        {
            var drone = Drones.FirstOrDefault(x => x.Name == name);
            if (drone == null)
            {
                return null;
            }
            else
            {
                drone.Available = false;
                return drone;
            }
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> drones = new List<Drone>();

            foreach (var item in Drones)
            {
                if (item.Range >= range)
                {
                    item.Available = false;
                    drones.Add(item);
                }
            }

            return drones;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");
            foreach (var item in Drones)
            {
                if (item.Available == true)
                {
                    sb.AppendLine($"{item}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
