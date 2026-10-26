
namespace Backend;
using System.Collections.Generic;

/// <summary>
/// Represents a generic doubly linked list.
/// </summary>
/// <typeparam name="T">The type of elements stored in the list.</typeparam>
public class DoublyLinkedList<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;

    /// <summary>
    /// Initializes a new instance of the DoublyLinkedList class.
    /// </summary>
    public DoublyLinkedList()
    {
        _head = null;
        _tail = null;
    }

    /// <summary>
    /// Inserts an element into the list in ascending order.
    /// </summary>
    /// <param name="data">The element to insert.</param>
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
    /// <summary>
    /// Returns the elements of the list from beginning to end.
    /// </summary>
    /// <returns>A string containing the elements in ascending order.</returns>
    public override string ToString()
    {
        var result = string.Empty;
        var current = _head;

        while (current != null)
        {
            if (result != string.Empty)
            {
                result += ", ";
            }

            result += current.Data;
            current = current.Next;
        }

        return result;
    }


    /// <summary>
    /// Returns the elements of the list from end to beginning.
    /// </summary>
    /// <returns>A string containing the elements in descending order.</returns>
    public string ToStringReverse()
    {
        var result = string.Empty;
        var current = _tail;

        while (current != null)
        {
            if (result != string.Empty)
            {
                result += ", ";
            }

            result += current.Data;
            current = current.Previous;
        }

        return result;
    }


    /// <summary>
    /// Determines whether the list contains a specific element.
    /// </summary>
    /// <param name="data">The element to search for.</param>
    /// <returns>True if the element exists; otherwise, false.</returns>
    public bool Contains(T data)
    {
        var current = _head;

        while (current != null)
        {
            if (Comparer<T>.Default.Compare(current.Data, data) == 0)
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }


    /// <summary>
    /// Removes the first occurrence of an element from the list.
    /// </summary>
    /// <param name="data">The element to remove.</param>
    /// <returns>True if an element was removed; otherwise, false.</returns>
    public bool Remove(T data)
    {
        var current = _head;

        while (current != null)
        {
            if (Comparer<T>.Default.Compare(current.Data, data) == 0)
            {
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    _head = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    _tail = current.Previous;
                }

                return true;
            }

            current = current.Next;
        }

        return false;
    }

    /// <summary>
    /// Removes all occurrences of an element from the list.
    /// </summary>
    /// <param name="data">The element to remove.</param>
    /// <returns>The number of elements removed.</returns>
    public int RemoveAll(T data)
    {
        var count = 0;

        while (Remove(data))
        {
            count++;
        }

        return count;
    }

    /// <summary>
    /// Gets all elements with the highest occurrence count.
    /// </summary>
    /// <returns>A list containing the mode or modes.</returns>
    public List<T> GetModes()
    {
        var modes = new List<T>();
        var maxCount = 0;
        var current = _head;

        while (current != null)
        {
            var count = 0;
            var item = _head;

            while (item != null)
            {
                if (Comparer<T>.Default.Compare(
                    current.Data, item.Data) == 0)
                {
                    count++;
                }

                item = item.Next;
            }

            if (count > maxCount)
            {
                maxCount = count;
                modes.Clear();
                modes.Add(current.Data);
            }
            else if (count == maxCount)
            {
                var exists = false;

                foreach (var mode in modes)
                {
                    if (Comparer<T>.Default.Compare(
                        mode, current.Data) == 0)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    modes.Add(current.Data);
                }
            }

            current = current.Next;
        }

        return modes;
    }

    /// <summary>
    /// Creates a graph showing the occurrences of each element.
    /// </summary>
    /// <returns>A string representing the occurrence graph.</returns>
    public string GetOccurrenceGraph()
    {
        var result = string.Empty;
        var processed = new List<T>();
        var current = _head;

        while (current != null)
        {
            var exists = false;

            foreach (var item in processed)
            {
                if (Comparer<T>.Default.Compare(
                    item, current.Data) == 0)
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                var count = 0;
                var item = _head;

                while (item != null)
                {
                    if (Comparer<T>.Default.Compare(
                        item.Data, current.Data) == 0)
                    {
                        count++;
                    }

                    item = item.Next;
                }

                result += $"{current.Data} {new string('*', count)}\n";
                processed.Add(current.Data);
            }

            current = current.Next;
        }

        return result;
    }

}