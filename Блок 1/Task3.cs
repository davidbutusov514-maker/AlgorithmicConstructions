namespace AlgorithmicConstructions.Tasks
{
    /// <summary>
    /// Задание 3 (Сложное).
    /// Простой менеджер задач (To-Do List) на массиве строк (максимум 10 задач).
    /// Поддерживает добавление, просмотр, отметку выполнения и удаление.
    /// </summary>
    public static class Task3
    {
        private const int MAX_TASKS = 10;

        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Задание 3: Менеджер задач (To-Do List) ===");

            string[] tasks = new string[MAX_TASKS];
            bool[] completed = new bool[MAX_TASKS];
            int taskCount = 0;

            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Показать все задачи");
                Console.WriteLine("3. Отметить задачу как выполненную");
                Console.WriteLine("4. Удалить задачу");
                Console.WriteLine("5. Выход");
                Console.Write("Ваш выбор: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask(tasks, completed, ref taskCount);
                        break;
                    case "2":
                        ShowTasks(tasks, completed, taskCount);
                        break;
                    case "3":
                        MarkTask(tasks, completed, taskCount);
                        break;
                    case "4":
                        DeleteTask(tasks, completed, ref taskCount);
                        break;
                    case "5":
                        Console.WriteLine("Выход из менеджера задач.");
                        return;
                    default:
                        Console.WriteLine("Неверный пункт меню.");
                        break;
                }
            }
        }

        private static void AddTask(string[] tasks, bool[] completed, ref int taskCount)
        {
            if (taskCount >= MAX_TASKS)
            {
                Console.WriteLine("Список задач переполнен (максимум 10).");
                return;
            }

            Console.Write("Введите описание задачи: ");
            string? newTask = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newTask))
            {
                Console.WriteLine("Задача не может быть пустой.");
                return;
            }

            tasks[taskCount] = newTask;
            completed[taskCount] = false;
            taskCount++;
            Console.WriteLine("Задача добавлена.");
        }

        private static void ShowTasks(string[] tasks, bool[] completed, int taskCount)
        {
            if (taskCount == 0)
            {
                Console.WriteLine("Список задач пуст.");
                return;
            }

            Console.WriteLine("Ваши задачи:");
            for (int i = 0; i < taskCount; i++)
            {
                string status = completed[i] ? "[X]" : "[ ]";
                Console.WriteLine($"{i + 1}. {status} {tasks[i]}");
            }
        }

        private static void MarkTask(string[] tasks, bool[] completed, int taskCount)
        {
            if (taskCount == 0)
            {
                Console.WriteLine("Список задач пуст.");
                return;
            }

            Console.Write("Введите номер задачи для отметки: ");
            if (!int.TryParse(Console.ReadLine(), out int markIndex) ||
                markIndex < 1 || markIndex > taskCount)
            {
                Console.WriteLine("Неверный номер задачи.");
                return;
            }

            completed[markIndex - 1] = true;
            Console.WriteLine("Задача отмечена как выполненная.");
        }

        private static void DeleteTask(string[] tasks, bool[] completed, ref int taskCount)
        {
            if (taskCount == 0)
            {
                Console.WriteLine("Список задач пуст.");
                return;
            }

            Console.Write("Введите номер задачи для удаления: ");
            if (!int.TryParse(Console.ReadLine(), out int delIndex) ||
                delIndex < 1 || delIndex > taskCount)
            {
                Console.WriteLine("Неверный номер задачи.");
                return;
            }

            int indexToRemove = delIndex - 1;

            // Сдвигаем элементы влево
            for (int i = indexToRemove; i < taskCount - 1; i++)
            {
                tasks[i] = tasks[i + 1];
                completed[i] = completed[i + 1];
            }

            taskCount--;
            tasks[taskCount] = null!;
            completed[taskCount] = false;

            Console.WriteLine("Задача удалена.");
        }
    }
}