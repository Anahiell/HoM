namespace SquareLib
{
    public class Square
    {
        //Calculate area of square use double
        public static double SquareAr(double side)
        {
            return side * side;
        }
        //calculate area of rectangle
        public static double RectangleAr(double sideA, double sideB)
        {
            return sideA * sideA;
        }
        //calculate area of triangle
        public static double TriangleAr(double baseT, double height)
        {
            return baseT * height * 0.5;
        }
    }
}