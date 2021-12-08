using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double width, double height)
        {
            Height = height;
            Width = width;
        }

        public double Height
        {
            get { return height; }
            private set { height = value; }
        }

        public double Width
        {
            get { return width; }
            private set { width = value; }
        }

        public override double CalculateArea()
        {
            return width*height; 
        }

       public override double CalculatePerimeter()
       {
            return 2*(width+height); 
       }

        public override string Draw()
        {
            return "Rectangle";
        }
    }
}
