using Problem03.Queue;
using Problem04.SinglyLinkedList;


SinglyLinkedList<int> singlyLinkedList = new SinglyLinkedList<int>();
singlyLinkedList.AddFirst(1);
singlyLinkedList.AddFirst(2);
singlyLinkedList.AddFirst(5);
singlyLinkedList.AddLast(15);

Console.WriteLine(singlyLinkedList.RemoveLast());
