
namespace Backend;

/// <summary>
/// Represents a node in a doubly linked list.
/// </summary>
/// <typeparam name="T">The type of data stored in the node.</typeparam>
public class DoubleNode<T>
{
    public T Data { get; set; }

    public DoubleNode<T>? Previous { get; set; }

    public DoubleNode<T>? Next { get; set; }

    public DoubleNode(T data)
    {
        Data = data;
        Previous = null;
        Next = null;
    }
}
