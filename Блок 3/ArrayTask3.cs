namespace AlgorithmicConstructions.Arrays
{
    /// <summary>
    /// Задание 3 (Сложное).
    /// Метод возвращает новый массив только с уникальными элементами
    /// исходного массива (без LINQ).
    /// </summary>
    public static class ArrayTask3
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Задание 3 (Массивы): Уникальные элементы ===");

            int[] source = { 1, 2, 2, 3, 4, 4, 4, 5, 1, 6, 7, 7, 8 };

            Console.WriteLine("Исходный массив:");
            Console.WriteLine(string.Join(", ", source));

            int[] unique = GetUnique(source);

            Console.WriteLine("\nМассив без дубликатов:");
            Console.WriteLine(string.Join(", ", unique));
        }

        /// <summary>
        /// Возвращает новый массив только с уникальными элементами.
        /// Порядок элементов сохраняется (первое вхождение).
        /// Без использования LINQ.
        /// </summary>
        public static int[] GetUnique(int[] source)
        {
            if (source == null || source.Length == 0)
                return Array.Empty<int>();

            // Временный массив той же длины — максимум все элементы уникальны
            int[] temp = new int[source.Length];
            int uniqueCount = 0;

            for (int i = 0; i < source.Length; i++)
            {
                bool found = false;

                // Проверяем, встречался ли элемент ранее
                for (int j = 0; j < uniqueCount; j++)
                {
                    if (temp[j] == source[i])
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    temp[uniqueCount] = source[i];
                    uniqueCount++;
                }
            }

            // Обрезаем до реального размера
            int[] result = new int[uniqueCount];
            for (int i = 0; i < uniqueCount; i++)
            {
                result[i] = temp[i];
            }

            return result;
        }
    }
}