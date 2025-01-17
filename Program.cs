using System;

// Класс, представляющий Льва
public class Lion
{
    // Делегат для события "Лев голоден"
    public delegate void HungryEventHandler();

    // Событие "Лев голоден"
    public event HungryEventHandler OnHungry;

    private int _walkTime = 0;

    // Метод, имитирующий прогулку льва
    public void Walk()
    {
        Console.WriteLine("Лев гуляет...");
        _walkTime++;

        if (_walkTime >= 3)
        {
            Console.WriteLine("Лев устал и проголодался.");
            OnHungry?.Invoke(); // Вызываем событие "Лев голоден"
            _walkTime = 0; // Сбрасываем счетчик времени прогулки
        }
    }
}

// Класс, представляющий работника зоопарка
public class ZooKeeper
{
    // Метод, реагирующий на событие "Лев голоден"
    public void FeedLion(Lion lion)
    {
        Console.WriteLine("Работник зоопарка кормит льва.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var lion = new Lion();
        var zooKeeper = new ZooKeeper();

        // Подписываемся на событие "Лев голоден" с использованием лямбда-выражения
        lion.OnHungry += () => zooKeeper.FeedLion(lion);

        for (int hour = 1; hour <= 12; hour++)
        {
            Console.WriteLine($"День льва: {hour} часов");
            lion.Walk();
        }
    }
}