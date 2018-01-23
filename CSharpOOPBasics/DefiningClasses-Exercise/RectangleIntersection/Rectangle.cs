namespace RectangleIntersection
{
    public class Rectangle
    {
        private double width;
        private double height;
        private double[] coords;

        public Rectangle(double width, double height, double[] coords)
        {
            this.width = width;
            this.height = height;
            this.coords = coords;
        }

        public string IntersectsWith(Rectangle rectangle)
        {
            var r1x1 = this.coords[0];
            var r1x2 = this.coords[0] + width;
            var r1y1 = this.coords[1];
            var r1y2 = this.coords[1] + height;

            var r2x1 = rectangle.coords[0];
            var r2x2 = rectangle.coords[0] + width;
            var r2y1 = rectangle.coords[1];
            var r2y2 = rectangle.coords[1] + height;

            //if ((r2x2 >= r1x1 && r2x1 <= r1x2) && (r2y2 >= r1y1 && r2y1 <= r1y2))
            if (!(r1x1 > r2x2 || r1x2 < r2x1 || r1y1 > r2y2 || r1y2 < r2y1))
                return "true";

            return "false";
        }
    }
}
