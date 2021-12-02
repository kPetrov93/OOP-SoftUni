using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulationExercise
{
    public class Dough
    {
        private string type;

        private string technique;

        private double weight;

        Dictionary<string, double> flourType = new Dictionary<string, double>
        { 
            {"white" , 1.5},
            {"wholegrain" , 1}
        };

        Dictionary<string, double> bakingTechnique = new Dictionary<string, double> 
        {
            {"crispy" , 0.9},
            {"chewy" , 1.1},
            {"homemade" , 1.0}
        };

        public Dough(string type, string technique, double weight)
        {
            Type = type;
            Technique = technique;
            Weight = weight;
        }

        public string Type
        {
            get { return type; }
            private set 
            {
                if (!flourType.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                type = value; 
            }
        }

        public string Technique
        {
            get { return technique; }
            private set 
            {
                if (!bakingTechnique.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                technique = value; 
            }
        }

        public double Weight
        {
            get { return weight; }
            private set 
            {
                if (value<1 || value>200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                weight = value; 
            }
        }

        public double Calories => 2 * Weight * flourType[type.ToLower()] * bakingTechnique[technique.ToLower()];

    }
}
