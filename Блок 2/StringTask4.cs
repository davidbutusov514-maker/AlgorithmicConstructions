namespace AlgorithmicConstructions.Strings
{
    /// <summary>
    /// Задание 4 (Работа с исключениями).
    /// Парсинг строки формата "Имя:Значение" с обработкой исключений.
    /// </summary>
    public static class StringTask4
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Задание 4 (Строки): Парсинг \"Имя:Значение\" ===");
            Console.WriteLine("Введите строки в формате \"Имя:Значение\" (пустая строка — выход)\n");

            while (true)
            {
                Console.Write("> ");
                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input)) break;

                try
                {
                    var (key, value) = ParseKeyValue(input);
                    Console.WriteLine($"  Ключ:  \"{key}\"");
                    Console.WriteLine($"  Значение: \"{value}\"");
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"  ArgumentNullException: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"  ArgumentException: {ex.Message}");
                }
            }

            Console.WriteLine("Выход.");
        }

        /// <summary>
        /// Разбирает строку формата "Имя:Значение".
        /// </summary>
        public static (string key, string value) ParseKeyValue(string input)
        {
            if (input is null)
                throw new ArgumentNullException(nameof(input), "Строка не может быть null.");

            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Строка не может быть пустой или состоять из пробелов.", nameof(input));

            int colonCount = 0;
            foreach (char c in input)
            {
                if (c == ':') colonCount++;
            }

            if (colonCount == 0)
                throw new ArgumentException("Строка должна содержать двоеточие.", nameof(input));

            if (colonCount > 1)
                throw new ArgumentException("Строка должна содержать ровно одно двоеточие.", nameof(input));

            int colonIndex = input.IndexOf(':');
            string key = input.Substring(0, colonIndex).Trim();
            string value = input.Substring(colonIndex + 1).Trim();

            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Имя (ключ) не может быть пустым.", nameof(input));

            return (key, value);
        }
    }
}