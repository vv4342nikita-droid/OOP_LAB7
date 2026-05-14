using System;
using LinkedListTask;

/// <summary>
/// Головний клас програми для демонстрації роботи списку.
/// </summary>
class Program
{
    /// <summary>
    /// Точка входу в програму.
    /// </summary>
    static void Main(string[] args)
    {
        // Створюємо об'єкт нашої структури даних
        DoublyLinkedList list = new DoublyLinkedList();

        // Наповнюємо список початковими даними
        list.AddFirst(5.0);
        list.AddFirst(10.0);
        list.AddFirst(20.0); // Максимальний елемент
        list.AddFirst(15.0);
        list.AddFirst(3.0);

        
        // Використання foreach для виведення (вимога завдання)
        Console.Write("Початковий список (через foreach): ");
        foreach (double val in list) Console.Write($"{val}  ");
        Console.WriteLine("\n" + new string('-', 45));

        // Демонстрація індексації (вимога завдання)
        Console.WriteLine($"Елемент за індексом [2]: {list[2]}");
        
        // Видалення за номером (вимога завдання)
        Console.WriteLine("Видаляємо елемент №0 (число 3.0)");
        list.RemoveAt(0);
        Console.Write("Список після видалення: ");
        foreach (var v in list) Console.Write($"{v}  ");
        Console.WriteLine("\n" + new string('-', 45));

        Console.WriteLine("ВИКОНАННЯ ЗАВДАНЬ:");

        // Завдання 1: Перше входження меншого за середнє
        double? firstLess = list.FindFirstLessThanAverage();
        Console.WriteLine($"1. Перше число, менше за середнє: {firstLess}");

        // Завдання 2: Сума після максимального
        double sumAfter = list.SumAfterMax();
        Console.WriteLine($"2. Сума елементів після максимального: {sumAfter}");

        // Завдання 3: Новий список з елементів більших за 12.0
        double threshold = 12.0;
        DoublyLinkedList filteredList = list.GetElementsGreaterThan(threshold);
        Console.Write($"3. Елементи більші за {threshold} (новий список): ");
        foreach (var v in filteredList) Console.Write($"{v}  ");
        Console.WriteLine();

        // Завдання 4: Видалення до максимального
        Console.WriteLine("4. Видаляємо всі елементи до максимального...");
        list.RemoveBeforeMax();
        Console.Write("   Результат: ");
        foreach (var v in list) Console.Write($"{v}  ");
        Console.WriteLine("\n" + new string('=', 45));
    }
}