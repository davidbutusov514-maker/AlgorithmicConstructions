namespace AlgorithmicConstructions.Strings
{
    /// <summary>
    /// Задание 3 (Сложное).
    /// Простой анализатор текста: количество предложений, слов,
    /// самое длинное слово, самое частое слово, очистка от пунктуации.
    /// </summary>
    public static class StringTask3
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Задание 3 (Строки): Анализатор текста ===");
            Console.WriteLine("Введите текст (несколько предложений):");
            Console.WriteLine("(для завершения введите пустую строку)\n");

            string text = ReadMultilineInput();

            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Текст пустой.");
                return;
            }

            // Разбиваем на предложения
            char[] sentenceSeparators = { '.', '!', '?' };
            string[] sentences = text.Split(sentenceSeparators, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"\nКоличество предложений: {sentences.Length}");

            // Разбиваем на слова (без знаков препинания)
            char[] wordSeparators = { ' ', '.', ',', '!', '?', ';', ':', '-', '\n', '\r', '\t', '"', '\'', '(', ')' };
            string[] words = text.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Количество слов: {words.Length}");

            if (words.Length == 0) return;

            // Самое длинное слово
            string longest = words[0];
            foreach (string w in words)
            {
                if (w.Length > longest.Length) longest = w;
            }
            Console.WriteLine($"Самое длинное слово: \"{longest}\" ({longest.Length} символов)");

            // Самое частое слово (без учёта регистра)
            var wordCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (string w in words)
            {
                string key = w.ToLower();
                if (wordCount.ContainsKey(key))
                    wordCount[key]++;
                else
                    wordCount[key] = 1;
            }

            string mostFrequent = "";
            int maxCount = 0;
            foreach (var pair in wordCount)
            {
                if (pair.Value > maxCount)
                {
                    maxCount = pair.Value;
                    mostFrequent = pair.Key;
                }
            }
            Console.WriteLine($"Самое частое слово: \"{mostFrequent}\" (встречается {maxCount} раз)");

            // Очищенный текст
            string cleaned = text;
            foreach (char c in wordSeparators)
            {
                if (c != ' ') cleaned = cleaned.Replace(c, ' ');
            }
            cleaned = string.Join(" ", cleaned.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Console.WriteLine($"\nОчищенный текст:\n{cleaned}");
        }

        private static string ReadMultilineInput()
        {
            var lines = new List<string>();
            while (true)
            {
                string? line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;
                lines.Add(line);
            }
            return string.Join(" ", lines);
        }
    }
}