﻿using System.Windows.Forms;

namespace task
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Написать игру, смысл которой состоит в следующем. На игровом
        /// поле имеются 16 кнопок, список, счётчик и индикатор. При запуске
        /// игры (кнопка «Новая игра») на кнопки помещаются 16 случайных
        /// чисел из диапазона от 0 до 100. Задача состоит в том, чтобы за
        /// указанное время успеть (пока не заполнится весь индикатор) 
        /// щелкнуть по всем кнопкам в порядке возрастания чисел. При нажатии
        /// на кнопку число должно добавляться в список только в том случае, 
        /// если это число является следующим по возрастанию
        /// </summary>

        // Ссылка на класс реализующий логику игры.
        private Game _game = null;

        // Конструтор формы.
        public Form1()
        {
            InitializeComponent();

            // Перед игрой отключаем поле с кнопками.
            // Будет включено только после нажатия кнопки "Начать игру".
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;
            button16.Enabled = false;
            listBox1.Enabled = false;

            _game = new Game();
        }

        // Обработчик кнопки "Новая игра".
        private void NewGame_button17_Click(object sender, EventArgs e)
        {
            // Включаем игровое поле.
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;

            // Заполняем игровое поле случайными числами от 0 до 100.
            _game.SetAllButtonsTextFromArr(Controls);

            // todo:вставить метод заполнения и выведения на поле из Game
            //Random random = new Random();
            //foreach (Control control in Controls)
            //    if (control is Button && (control as Button).Text != "Новая игра")
            //        (control as Button).Text = random.Next(0, 101).ToString();

            // Секунд осталось до конца игры.
            _game.TimeLeft = Convert.ToInt32(GameTime_numericUpDown1.Value);

            // Запускаем таймер на обратный отсчет. 
            timer1.Start();

        }

        // Вывод в хедер остатка секунд на игру.
        private void CountdownStart_timer1_Tick(object sender, EventArgs e)
        {
            Text = _game.TimeLeft + " секунд осталось ! ";
            _game.TimeLeft -= 1;
        }

        // Нажатие на кнопку игрового поля.
        private void GameField_buttons_Click(object sender, EventArgs e)
        {
            // Выбранное игроком число отправляем в класс Game.
            _game.SelectedNumberIs = Convert.ToInt32(((Button)sender).Text);

            // todo:Проверяем, является ли выбранное число следующим по возрастанию.
            if (_game.IsMinNumber())
            {
                // Если да, то добавляем его в список.
                listBox1.Items.Add(_game.SelectedNumberIs);
                // Удаляем кнопку с игрового поля.
                ((Button)sender).Enabled = false;
            }
            else
            {
                // Если нет, то выводим сообщение об ошибке.
                MessageBox.Show("Неверный порядок чисел!");
            }


            // Блокируем нажатую кнопку до конца игры.
            ((Button)sender).Enabled = false;

            // Обнуляем поле с выбранным числом.
            _game.SelectedNumberIs = 0;

        }
    }

    // Класс реализующий логику программы.
    internal class Game
    {
        // Выбранное пользователем число.
        public int SelectedNumberIs { get; set; }

        // Секунд осталось до конца игры.
        public int TimeLeft { get; set; }

        // Массив значений игрового поля.
        private readonly int[] _arr;
        //public string this[int i, int j]
        //{
        //    get => _arr[i];
        //    set => _arr[i] = value;
        //}

        // Конструктор класса.
        internal Game()
        {
            SelectedNumberIs = -1;
            TimeLeft = -1;
            _arr = new int[16];
            FillArrRandomNumbers();
        }

        // Принимает Controll из формы, и каждой кнопке назначает сооветствующее число из массива.
        public void SetAllButtonsTextFromArr(Control.ControlCollection control)
        {
            int i = 1;
            do
            {
                foreach (var obj in control)
                    if (obj is Button)
                        if (((Button)obj).Name =="button" + i)
                            ((Button)obj).Text = _arr[i].ToString();
                i--;
            } while (i>0);
        }



        // Метод заполнения массива случайными уникальными числами и сортирует массив.
        private void FillArrRandomNumbers()
        {
            Random random = new Random();
            for (var j = 0; j < 16; j++)
            {
                _arr[j] = random.Next(1, 101);
                for (var i = 0; i < j; i++)
                {
                    if (_arr[i] == _arr[j])
                    {
                        j--;
                        break;
                    }
                }
            }
            Array.Sort(_arr);
        }

        // Возвращает true, если выбрано минимальное число.
        public bool IsMinNumber()
        {
            return SelectedNumberIs == _arr[0];
        }








    }
}