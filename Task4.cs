namespace AlgorithmicConstructions.Tasks
{
    /// <summary>
    /// Задание 4 (Продвинутое).
    /// Сортировка выбором и пузырьковая сортировка массива из 20 случайных чисел.
    /// Подсчитывается количество сравнений и обменов.
    /// </summary>
    public static class Task4
    {
        private const int ARRAY_SIZE = 20;

        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Задание 4: Сортировка выбором и пузырьковая ===");

            int[] original = GenerateRandomArray(ARRAY_SIZE, 1, 101);

            Console.WriteLine("Исходный массив:");
            PrintArray(original);

            // Копии для двух сортировок
            int[] selectionArray = (int[])original.Clone();
            int[] bubbleArray = (int[])original.Clone();

            // Сортировка выбором
            int selectionComparisons = 0;
            int selectionSwaps = 0;
            SelectionSort(selectionArray, ref selectionComparisons, ref selectionSwaps);

            Console.WriteLine("\nОтсортированный массив (выбором):");
            PrintArray(selectionArray);
            Console.WriteLine($"Сравнений: {selectionComparisons}, Обменов: {selectionSwaps}");

            // Пузырьковая сортировка
            int bubbleComparisons = 0;
            int bubbleSwaps = 0;
            BubbleSort(bubbleArray, ref bubbleComparisons, ref bubbleSwaps);

            Console.WriteLine("\nОтсортированный массив (пузырьком):");
            PrintArray(bubbleArray);
            Console.WriteLine($"Сравнений: {bubbleComparisons}, Обменов: {bubbleSwaps}");

            // Сравнение
            Console.WriteLine("\nСравнение:");
            Console.WriteLine($"Выбором:   сравнений {selectionComparisons}, обменов {selectionSwaps}");
            Console.WriteLine($"Пузырьком: сравнений {bubbleComparisons}, обменов {bubbleSwaps}");
        }

        private static int[] GenerateRandomArray(int size, int min, int max)
        {
            Random rand = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(min, max);
            }
            return arr;
        }

        private static void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        private static void SelectionSort(int[] arr, ref int comparisons, ref int swaps)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    comparisons++;
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                    swaps++;
                }
            }
        }

        private static void BubbleSort(int[] arr, ref int comparisons, ref int swaps)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < n - 1 - i; j++)
                {
                    comparisons++;
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swaps++;
                        swapped = true;
                    }
                }

                if (!swapped) break;
            }
        }
    }
}