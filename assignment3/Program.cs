using System;
using System.Security.Principal;

namespace Shape_Factory{
    public abstract class Shape{
        public abstract double Area();
        public abstract bool IsValid();
        public abstract string Get_Shape();
    }
    public class Rectangle : Shape{
        private double width, length;
        public Rectangle(double width, double length){
            this.width = width;
            this.length = length;
        }
        public override double Area(){
            return width * length;
        }
        public override bool IsValid(){
            return width > 0 && length > 0;
        }
        public override string Get_Shape(){
            return "Rectangle";
        }
    }
    public class Square : Shape{
        private double side;
        public Square(double side){
            this.side = side;
        }
        public override double Area(){
            return side * side;
        }
        public override bool IsValid(){
            return side > 0;
        }
        public override string Get_Shape(){
            return "Square";
        }
    }
    public class Triangle : Shape{
        private double a, b, c;
        public Triangle(double a, double b, double c){
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override double Area(){
            double p = (a + b + c)/2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        public override bool IsValid(){
            return a > 0 && b > 0 && c > 0 && (a + b > c) && (a + c > b) && (b + c > a);
        }
        public override string Get_Shape(){
            return "Triangle";
        }
    }
    public static class Shape_Factory{
        private static Random rand = new Random();
        public static Shape CreateRandomShape(){
            int type = rand.Next(3);
            switch(type){
                case 0:
                    return new Rectangle(rand.Next(1, 10), rand.Next(1, 10));
                case 1:
                    return new Square(rand.Next(1, 10));
                case 2:
                    return new Triangle(rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10));
                default:
                    throw new Exception("Invalid shape type!");
            }
        }
    }
    class Program{
        static void Main(string[] args){
            List<Shape> shapes = new List<Shape> ();
            double totalArea = 0;
            for(int i = 0; i < 10; i++){
                Shape s = Shape_Factory.CreateRandomShape();
                shapes.Add(s);
                if(s.IsValid()){
                    double area = s.Area();
                    totalArea += area;
                    Console.WriteLine($"Shape {i + 1}: {s.Get_Shape()}, Area: {area}");
                }
                else{
                    Console.WriteLine($"Shape {i + 1}: {s.Get_Shape()} (Invalid)");
                }
            }
            Console.WriteLine($"\nTotal Area of Valid Shapes: {totalArea}");
        }
    }
}