using System.Threading;
namespace CarRacingGame
{

    // Определение делегата для события "Финиш"
    public delegate void FinishEventHandler(object sender, EventArgs e);
    
    public class Car 
    {
        private static int finishCounter = 0;
        public string Model { get; set; }
        public int Speed { get; set; }
        public int FinishOrder { get; private set; } // Порядковый номер финишировавшего автомобиля

        public event FinishEventHandler Finish; // Событие, вызываемое при достижении финиша

        public void Move()
        {
            Random random = new Random();
            for (int distance = 0; distance <= 110; distance += Speed)
            {
                Console.WriteLine($"{Model} двигается. Пройдено {distance} км.");
                Thread.Sleep(100); // Задержка для визуализации движения

                if (distance >= 100)
                {
                                        FinishOrder = Interlocked.Increment(ref finishCounter); // Увеличиваем порядковый номер финишировавшего автомобиля
                    OnFinish(); // Вызываем событие при достижении финиша
                    break;
                }

                Speed = random.Next(5, 20); // Изменение скорости случайным образом
            }
        }

        protected virtual void OnFinish()
        {
            Finish?.Invoke(this, EventArgs.Empty); // Вызываем событие "Финиш"
        }
    }

}
