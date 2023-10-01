
using CarRacingGame;
using System.Reflection;

class Program
{
    static string[] finishLabels = { "первым", "вторым", "третьим", "четвертым" }; // Массив текстовых меток

    static void Main()
    {
        Car sportsCar = new Car { Model = "Спортивный автомобиль" };
        Car sedanCar = new Car { Model = "Легковой автомобиль" };
        Car truck = new Car { Model = "Грузовик" };
        Car bus = new Car { Model = "Автобус" };

        // Запуск движение каждого автомобиля параллельно
        Thread sportsCarThread = new Thread(sportsCar.Move);
        Thread sedanCarThread = new Thread(sedanCar.Move);
        Thread truckThread = new Thread(truck.Move);
        Thread busThread = new Thread(bus.Move);

        // Подписка на событие "Финиш" для каждого автомобиля после создания автомобилей
        sportsCar.Finish += (sender, e) =>
        {
            int order = ((Car)sender).FinishOrder;
            string label = finishLabels[order - 1];
            Console.WriteLine($"{((Car)sender).Model} пришел {label}!");
        };

        sedanCar.Finish += (sender, e) =>
        {
            int order = ((Car)sender).FinishOrder;
            string label = finishLabels[order - 1];
            Console.WriteLine($"{((Car)sender).Model} пришел {label}!");
        };

        truck.Finish += (sender, e) =>
        {
            int order = ((Car)sender).FinishOrder;
            string label = finishLabels[order - 1];
            Console.WriteLine($"{((Car)sender).Model} пришел {label}!");
        };

        bus.Finish += (sender, e) =>
        {
            int order = ((Car)sender).FinishOrder;
            string label = finishLabels[order - 1];
            Console.WriteLine($"{((Car)sender).Model} пришел {label}!");
        };

        sportsCarThread.Start();
        sedanCarThread.Start();
        truckThread.Start();
        busThread.Start();


        sportsCarThread.Join();
        sedanCarThread.Join();
        truckThread.Join();
        busThread.Join();
    }
}
