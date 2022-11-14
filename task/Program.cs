namespace task
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        /// Написать игру, смысл которой состоит в следующем. На игровом
        /// поле имеются 16 кнопок, список, счётчик и индикатор. При запуске
        /// игры (кнопка «Новая игра») на кнопки помещаются 16 случайных
        /// чисел из диапазона от 0 до 100. Задача состоит в том, чтобы за
        /// указанное время успеть (пока не заполнится весь индикатор) 
        /// щелкнуть по всем кнопкам в порядке возрастания чисел. При нажатии
        /// на кнопку число должно добавляться в список только в том случае, 
        /// если это число является следующим по возрастанию.

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}