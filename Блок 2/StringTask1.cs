namespace AlgorithmicConstructions.Strings
{
    /// <summary>
    /// Задание 1 (Базовое).
    /// Запрашивает строку и выводит: длину, первый и последний символ,
    /// верхний и нижний регистр, количество пробелов, количество гласных.
    /// </summary>
    public static class StringTask1
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Задание 1 (Строки): Базовая информация о строке ===");
            Console.Write("Введите строку: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Строка пустая или null.");
                return;
            }

            Console.WriteLine($"\nДлина строки: {input.Length}");
            Console.WriteLine($"Первый символ: '{input[0]}'");
            Console.WriteLine($"Последний символ: '{input[input.Length - 1]}'");
            Console.WriteLine($"В верхнем регистре: {input.ToUpper()}");
            Console.WriteLine($"В нижнем регистре: {input.ToLower()}");

            // Подсчёт пробелов
            int spaceCount = 0;
            foreach (char c in input)
            {
                if (c == ' ') spaceCount++;
            }
            Console.WriteLine($"Количество пробелов: {spaceCount}");

            // Подсчёт гласных (русские + латинские)
            string vowels = "аеёиоуыэюяaeiouy";
            int vowelCount = 0;
            foreach (char c in input.ToLower())
            {
                if (vowels.Contains(c)) vowelCount++;
            }
            Console.WriteLine($"Количество гласных: {vowelCount}");
        }
    }
}