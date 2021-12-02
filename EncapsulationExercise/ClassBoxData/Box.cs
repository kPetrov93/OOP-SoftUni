using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;

        private double width;

        private double height;

        public Box(double height, double width, double length)
        {
            Height = height;
            Width = width;
            Length = length;
        }

        public double Height
        {
            get { return height; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                height = value; 
            }
        }


        public double Width
        {
            get { return width; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                width = value; 
            }
        }

        public double Length 
        {
            get { return length; }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                length = value; 
            }
        }

        public double SurfaceArea()
        {
            double result = (2 * length * width) + (2 * length * height) + (2 * width * height);
            return result;
        }

        public double LateralSurfaceArea()
        {
            double result = (2 * length * height) + (2 * width * height);
            return result;
        }

        public double Volume()
        {
            double result =length*height*width;
            return result;
        }
    }
}
