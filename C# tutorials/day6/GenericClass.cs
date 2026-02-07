// Define a generic class with a type parameter T
public class Box<T>
{
    private T _content; // Generic field

    // Constructor accepts a parameter of type T
    public Box(T content)
    {
        _content = content;
    }

    // Method returns a value of type T
    public T GetContent()
    {
        return _content;
    }
}
