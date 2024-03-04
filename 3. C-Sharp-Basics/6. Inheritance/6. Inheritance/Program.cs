

using _6._Inheritance.Entities;

class Program
{
    static void main(String[] args)
    {

        // What is a virtual Method
        List<Shape> shapes = new List<Shape>()
        {
            new Circle(),
            new Rectangle(),
            new Rectangle(),
            new Triangle()
        };

        foreach (Shape shape in shapes)
        {
            shape.Draw();
        }





    }
}