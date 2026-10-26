
namespace Backend;
using System.Collections.Generic;

public class DoublyLinkedList<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;
    public DoublyLinkedList()
    {
        _head = null;
        _tail = null;
    }

    public void Insert(T data)
    {
        var newNode = new DoubleNode<T>(data);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        if (Comparer<T>.Default.Compare(data, _head.Data) <= 0)
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
            return;
        }

        if (Comparer<T>.Default.Compare(data, _tail!.Data) >= 0)
        {
            newNode.Previous = _tail;
            _tail.Next = newNode;
            _tail = newNode;
            return;
        }

        var current = _head;

        while (current != null &&
               Comparer<T>.Default.Compare(data, current.Data) > 0)
        {
            current = current.Next;
        }

        newNode.Next = current;
        newNode.Previous = current!.Previous;
        current.Previous!.Next = newNode;
        current.Previous = newNode;
    }
}
