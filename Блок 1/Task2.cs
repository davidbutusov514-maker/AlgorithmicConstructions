namespace AlgorithmicConstructions.Tasks
{
    /// <summary>
    /// Задание 2 (Среднее).
    /// Игра «Угадай число» с подсказками, счётчиком попыток
    /// и возможностью перезапуска.
    /// </summary>
    public static class Task2
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Задание 2: Угадай число ===");

            Random rand = new Random();
            bool playAgain;

            do
            {
                int secretNumber = rand.Next(1, 101);
                int attempts = 0;
                int guess;

                Console.WriteLine("Компьютер загадал число от 1 до 100.");

                do
                {
                    Console.Write("Ваш вариант: ");

                    if (!int.TryParse(Console.ReadLine(), out guess))
                    {
                        Console.WriteLine("Введите целое число.");
                        continue;
                    }

                    attempts++;

                    if (guess < secretNumber)
                        Console.WriteLine("Загаданное число больше.");
                    else if (guess > secretNumber)
                        Console.WriteLine("Загаданное число меньше.");
                    else
                        Console.WriteLine($"Поздравляю! Вы угадали за {attempts} попыток!");

                } while (guess != secretNumber);

                Console.Write("Хотите сыграть ещё? (y/n): ");
                string? answer = Console.ReadLine()?.Trim().ToLower();
                playAgain = answer == "y" || answer == "yes" || answer == "д" || answer == "да";

            } while (playAgain);
        }
    }
}