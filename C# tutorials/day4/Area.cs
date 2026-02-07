class Circle
{
    private double radius;

    public Circle(double r)
    {
        radius = r;
    }

    public double Area
    {
        get { return Math.PI * radius * radius; }
    }
}