
using Backend;

var list = new DoublyLinkedList<int>();

list.Insert(30);
list.Insert(10);
list.Insert(20);
list.Insert(5);
list.Insert(20);

Console.WriteLine("Doubly Linked List");
Console.WriteLine("------------------");
Console.WriteLine("Forward: " + list);
Console.WriteLine("Backward: " + list.ToStringReverse());
Console.WriteLine();
Console.WriteLine("Search tests:");
Console.WriteLine("Contains 20: " + list.Contains(20));
Console.WriteLine("Contains 99: " + list.Contains(99));
Console.WriteLine();
Console.WriteLine("Remove tests:");
Console.WriteLine("Remove 20: " + list.Remove(20));
Console.WriteLine("List after removal: " + list);
Console.WriteLine("Remove 99: " + list.Remove(99));
Console.WriteLine();
Console.WriteLine("Remove all tests:");
list.Insert(20);
list.Insert(20);
Console.WriteLine("List before RemoveAll: " + list);
Console.WriteLine("Removed occurrences of 20: " + list.RemoveAll(20));
Console.WriteLine("List after RemoveAll: " + list);


Console.WriteLine();
Console.WriteLine("Mode tests:");

var modeList = new DoublyLinkedList<int>();

modeList.Insert(1);
modeList.Insert(2);
modeList.Insert(3);
modeList.Insert(3);
modeList.Insert(2);
modeList.Insert(5);
modeList.Insert(6);
modeList.Insert(6);
modeList.Insert(6);
modeList.Insert(3);

Console.WriteLine("Test list: " + modeList);
Console.WriteLine("Modes: " + string.Join(", ", modeList.GetModes()));


Console.WriteLine();
Console.WriteLine("Occurrence graph:");
Console.WriteLine(modeList.GetOccurrenceGraph());


Console.WriteLine();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

