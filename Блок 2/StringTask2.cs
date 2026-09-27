using System.Text.RegularExpressions;

namespace AlgorithmicConstructions.Strings
{
    /// <summary>
    /// Задание 2 (Среднее).
    /// Методы для работы с телефонными номерами.
    /// </summary>
    public static class StringTask2
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Задание 2 (Строки): Телефонные номера ===");

            // Тест 1: Форматирование
            string[] testPhones = {
                "89123456789",
                "8(912)345-67-89",
                "+7 912 345 67 89",
                "9123456789",
                "123"
            };

            Console.WriteLine("\n--- Форматирование ---");
            foreach (string phone in testPhones)
            {
                Console.WriteLine($"{phone,-22} -> {FormatPhoneNumber(phone)}");
            }

            // Тест 2: Валидация
            Console.WriteLine("\n--- Валидация ---");
            foreach (string phone in testPhones)
            {
                Console.WriteLine($"{phone,-22} -> {(ValidatePhoneNumber(phone) ? "валидный" : "невалидный")}");
            }

            // Тест 3: Извлечение из текста
            Console.WriteLine("\n--- Извлечение из текста ---");
            string[] texts = {
                "Позвоните мне по номеру 89123456789",
                "Мой номер: +7 (912) 345-67-89, звоните",
                "Никаких номеров тут нет"
            };

            foreach (string text in texts)
            {
                string? extracted = ExtractPhoneNumber(text);
                Console.WriteLine($"\"{text}\"");
                Console.WriteLine($"  -> {(extracted ?? "не найдено")}");
            }
        }

        /// <summary>
        /// Форматирует номер в вид +7 (XXX) XXX-XX-XX.
        /// </summary>
        public static string FormatPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return phone;

            // Оставляем только цифры
            string digits = Regex.Replace(phone, @"\D", "");

            // Приводим к 10 цифрам (без 8 и без 7 в начале)
            if (digits.Length == 11 && (digits[0] == '8' || digits[0] == '7'))
            {
                digits = digits.Substring(1);
            }

            if (digits.Length != 10)
                return phone; // Не удалось отформатировать

            return $"+7 ({digits.Substring(0, 3)}) {digits.Substring(3, 3)}-{digits.Substring(6, 2)}-{digits.Substring(8, 2)}";
        }

        /// <summary>
        /// Проверяет, является ли строка валидным российским номером.
        /// </summary>
        public static bool ValidatePhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            string digits = Regex.Replace(phone, @"\D", "");

            // Допускаем 10 или 11 цифр (с 8 или 7 в начале)
            if (digits.Length == 10) return true;
            if (digits.Length == 11 && (digits[0] == '8' || digits[0] == '7')) return true;

            return false;
        }

        /// <summary>
        /// Извлекает первый телефонный номер из текста.
        /// </summary>
        public static string? ExtractPhoneNumber(string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            // Ищем последовательности, похожие на телефон
            string pattern = @"(?:\+?7|8)?[\s\-\(\)]*\d{3}[\s\-\(\)]*\d{3}[\s\-]*\d{2}[\s\-]*\d{2}";
            Match match = Regex.Match(text, pattern);

            return match.Success ? match.Value : null;
        }
    }
}