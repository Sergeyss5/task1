using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main()
    {

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        const int listSize = 100000;
        const int insertions = 1000;
        Random rand = new Random();

        // Створення списків
        ArrayList arrayList = new ArrayList();
        LinkedList<int> linkedList = new LinkedList<int>();

        // 1. Заповнення списків даними
        FillListWithRandomNumbers(arrayList, listSize, rand);
        FillListWithRandomNumbers(linkedList, listSize, rand);

        // 2. Випадковий доступ (ArrayList)
        MeasureTime(() => AccessRandomArrayList(arrayList, listSize, rand), "Випадковий доступ ArrayList");

        // 2. Випадковий доступ (LinkedList)
        MeasureTime(() => AccessRandomLinkedList(linkedList, listSize, rand), "Випадковий доступ LinkedList");

        // 3. Послідовний доступ (ArrayList)
        MeasureTime(() => AccessSequentialArrayList(arrayList), "Послідовний доступ ArrayList");

        // 3. Послідовний доступ (LinkedList)
        MeasureTime(() => AccessSequentialLinkedList(linkedList), "Послідовний доступ LinkedList");

        // 4. Вставка на початок
        MeasureTime(() => InsertAtBeginning(arrayList, insertions), "Вставка на початок ArrayList");
        MeasureTime(() => InsertAtBeginning(linkedList, insertions), "Вставка на початок LinkedList");

        // 5. Вставка в кінець
        MeasureTime(() => InsertAtEnd(arrayList, insertions), "Вставка в кінець ArrayList");
        MeasureTime(() => InsertAtEnd(linkedList, insertions), "Вставка в кінець LinkedList");

        // 6. Вставка в середину
        MeasureTime(() => InsertInMiddle(arrayList, insertions), "Вставка в середину ArrayList");
        MeasureTime(() => InsertInMiddle(linkedList, insertions), "Вставка в середину LinkedList");
    }

    // Метод для заповнення ArrayList
    static void FillListWithRandomNumbers(ArrayList list, int size, Random rand)
    {
        for (int i = 0; i < size; i++)
        {
            list.Add(rand.Next());
        }
    }

    // Метод для заповнення LinkedList
    static void FillListWithRandomNumbers(LinkedList<int> list, int size, Random rand)
    {
        for (int i = 0; i < size; i++)
        {
            list.AddLast(rand.Next());
        }
    }

    // Випадковий доступ до елементів ArrayList
    static void AccessRandomArrayList(ArrayList list, int size, Random rand)
    {
        for (int i = 0; i < size; i++)
        {
            var value = list[rand.Next(size)];
        }
    }

    // Випадковий доступ до елементів LinkedList
    static void AccessRandomLinkedList(LinkedList<int> list, int size, Random rand)
    {
        for (int i = 0; i < size; i++)
        {
            var node = GetNodeAt(list, rand.Next(size));
        }
    }

    // Послідовний доступ до елементів ArrayList
    static void AccessSequentialArrayList(ArrayList list)
    {
        foreach (var item in list) { }
    }

    // Послідовний доступ до елементів LinkedList
    static void AccessSequentialLinkedList(LinkedList<int> list)
    {
        foreach (var item in list) { }
    }

    // Вставка на початок ArrayList
    static void InsertAtBeginning(ArrayList list, int count)
    {
        for (int i = 0; i < count; i++)
        {
            list.Insert(0, i);
        }
    }

    // Вставка на початок LinkedList
    static void InsertAtBeginning(LinkedList<int> list, int count)
    {
        for (int i = 0; i < count; i++)
        {
            list.AddFirst(i);
        }
    }

    // Вставка в кінець ArrayList
    static void InsertAtEnd(ArrayList list, int count)
    {
        for (int i = 0; i < count; i++)
        {
            list.Add(i);
        }
    }

    // Вставка в кінець LinkedList
    static void InsertAtEnd(LinkedList<int> list, int count)
    {
        for (int i = 0; i < count; i++)
        {
            list.AddLast(i);
        }
    }

    // Вставка в середину ArrayList
    static void InsertInMiddle(ArrayList list, int count)
    {
        int middle = list.Count / 2;
        for (int i = 0; i < count; i++)
        {
            list.Insert(middle, i);
        }
    }

    // Вставка в середину LinkedList
    static void InsertInMiddle(LinkedList<int> list, int count)
    {
        LinkedListNode<int> middleNode = GetNodeAt(list, list.Count / 2);
        for (int i = 0; i < count; i++)
        {
            list.AddBefore(middleNode, i);
        }
    }

    // Отримання вузла на певній позиції у LinkedList
    static LinkedListNode<int> GetNodeAt(LinkedList<int> list, int index)
    {
        LinkedListNode<int> node = list.First;
        for (int i = 0; i < index; i++)
        {
            node = node.Next;
        }
        return node;
    }

    // Метод для вимірювання часу виконання
    static void MeasureTime(Action action, string description)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        action();
        stopwatch.Stop();
        Console.WriteLine($"{description}: {stopwatch.ElapsedMilliseconds} ms");
    }
}

