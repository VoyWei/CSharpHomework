﻿using System;

namespace Program1
{  
        public abstract class Shape
        {
            private string shapeId;

            public Shape(string s)
            {
                Id = s;
            }
            public string Id
            {
                get
                {
                    return shapeId;
                }
                set
                {
                    shapeId = value;
                }
            }

            public abstract double Area
            {
                get;
            }

            public override string ToString()
            {
                return Id + " area = " + string.Format("{0:F2}", Area);
            }
        }

        
        public class Square : Shape 
        {
            private int mSide;
            public Square(int side, string id) : base(id)
            {
                mSide = side;
            }

            public override double Area
            {
                get
                {
                    return mSide * mSide;
                }
            }
        }

        public class Circle : Shape 
        {
            private int mRadius;
            public Circle(int Radius, string id) : base(id)
            {
                mRadius = Radius;
            }

            public override double Area
            {
                get
                {
                    return System.Math.PI * mRadius * mRadius;
                }
            }
        }


        public class Rectangle : Shape 
        {
            private int mWidth;
            private int mHeight;
            public Rectangle(int width, int height, string id) : base(id)
            {
                mWidth = width;
                mHeight = height;
            }

            public override double Area
            {
                get
                {
                    return mWidth * mHeight;
                }
            }
        }

        public class Triangle : Shape 
        {
            private int mWidth;
            private int mHeight;
            public Triangle(int width, int height, string id) : base(id)
            {
                mWidth = width;
                mHeight = height;
            }

            public override double Area
            {
                get
                {
                    return 0.5 * mWidth * mHeight;
                }
            }
        }

    class Program
    {
        public static void Main()
        {
            Shape[] shapes =             
                {
                new Square(6, "Square"),
                new Circle(3, "Circle"),
                new Rectangle(4,7,"Rectangle"),
                new Triangle(3,4,"Triangle")
            };
            foreach (Shape s in shapes)
            {
                Console.WriteLine(s); ;
            }
        }
    }
}
