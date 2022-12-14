namespace task;

public partial class Form1 : Form
{
    /// <summary>
    ///     Написать игру, смысл которой состоит в следующем. На игровом
    ///     поле имеются 16 кнопок, список, счётчик и индикатор. При запуске
    ///     игры (кнопка «Новая игра») на кнопки помещаются 16 случайных
    ///     чисел из диапазона от 0 до 100. Задача состоит в том, чтобы за
    ///     указанное время успеть (пока не заполнится весь индикатор)
    ///     щелкнуть по всем кнопкам в порядке возрастания чисел. При нажатии
    ///     на кнопку число должно добавляться в список только в том случае,
    ///     если это число является следующим по возрастанию.
    /// </summary>

    // Ссылка на класс реализующий логику игры.
    private readonly Game _game;

    // Конструтор формы.
    public Form1()
    {
        InitializeComponent();

        // Перед игрой отключаем поле с кнопками.
        // Будет включено только после нажатия кнопки "Начать игру".
        gameField_button1.Enabled = false;
        gameField_button2.Enabled = false;
        gameField_button3.Enabled = false;
        gameField_button4.Enabled = false;
        gameField_button5.Enabled = false;
        gameField_button6.Enabled = false;
        gameField_button7.Enabled = false;
        gameField_button8.Enabled = false;
        gameField_button9.Enabled = false;
        gameField_button10.Enabled = false;
        gameField_button11.Enabled = false;
        gameField_button12.Enabled = false;
        gameField_button13.Enabled = false;
        gameField_button14.Enabled = false;
        gameField_button15.Enabled = false;
        gameField_button16.Enabled = false;
        listBox1.Enabled = false;

        _game = new Game();
    }

    // Обработчик кнопки "Новая игра".
    private void NewGame_button17_Click(object sender, EventArgs e)
    {
        // Включаем игровое поле.
        gameField_button1.Enabled = true;
        gameField_button2.Enabled = true;
        gameField_button3.Enabled = true;
        gameField_button4.Enabled = true;
        gameField_button5.Enabled = true;
        gameField_button6.Enabled = true;
        gameField_button7.Enabled = true;
        gameField_button8.Enabled = true;
        gameField_button9.Enabled = true;
        gameField_button10.Enabled = true;
        gameField_button11.Enabled = true;
        gameField_button12.Enabled = true;
        gameField_button13.Enabled = true;
        gameField_button14.Enabled = true;
        gameField_button15.Enabled = true;
        gameField_button16.Enabled = true;
        listBox1.Enabled = true;

        // Заполняет кнопки на игровом поле случайными числами от 0 до 100 и выставляет их в текст.
        _game.SetAllButtonsTextFromArr(Controls);

        // Секунд осталось до конца игры.
        _game.TimeLeft = Convert.ToInt32(GameTime_numericUpDown1.Value);

        // Запускаем таймер на обратный отсчет. 
        timer1.Start();

        // Выставление верхнего предела прогресс бара.
        progressBar1.Maximum = _game.TimeLeft;
    }

    // Тик таймера.
    private void CountdownStart_timer1_Tick(object sender, EventArgs e)
    {
        // Достаточно ли времени для игры.
        if (_game.CurrPressedFields == 16)
        {
            // Остановка таймера.
            timer1.Stop();
            // Если досрочная победа.
            _game.EarlyVictory();
            // Сыграем еще ?.
            _game.AskPlayMore();
            return;
        }

        if (_game.TimeLeft == 0)
        {
            // Остановка таймера.
            timer1.Stop();
            // Подводим итог по игре.
            _game.SummarizingInfoForLosers();
            // Сыграем еще ?.
            _game.AskPlayMore();
            return;
        }

        // Вывод в хедер остатка секунд на игру.
        Text = _game.TimeLeft + " секунд осталось ! ";
        _game.TimeLeft -= 1;

        // Изменение прогрес бара за тик таймера.
        progressBar1.Value += 1;
    }

    // Нажатие на кнопку игрового поля.
    private void GameField_buttons_Click(object sender, EventArgs e)
    {
        // Выбранное игроком число(кнопку с ним) отправляем в класс Game.
        _game.SelectedNumberIs = Convert.ToInt32(((Button)sender).Text);

        // todo:Проверяем, является ли выбранное число следующим по возрастанию.
        if (_game.IsMinNumber())
        {
            // Если да, то добавляем его в список.
            listBox1.Items.Add(_game.SelectedNumberIs);
            // Подсчет кол-ва добавленных кнопок.
            _game.CurrPressedFields++;
            // Блокируем нажатую кнопку до конца игры.
            ((Button)sender).Enabled = false;
        }
        else
        {
            // Если нет, то игнорируем.
            return;
        }

        // Обнуляем поле с выбранным числом.
        _game.SelectedNumberIs = 999;
    }
}

// Класс реализующий логику программы.
internal class Game
{
    // Массив значений игрового поля.
    private readonly int[] _arr;

    // Конструктор класса.
    internal Game()
    {
        CurrPressedFields = 0;
        SelectedNumberIs = -1;
        TimeLeft = -1;
        _arr = new int[16];
        FillArrRandomNumbers();
    }

    // Текущее количество уже нажатых полей.
    public int CurrPressedFields { get; set; }

    // Выбранное пользователем число.
    public int SelectedNumberIs { get; set; }

    // Секунд осталось до конца игры.
    public int TimeLeft { get; set; }

    // Принимает Controll из формы, и каждой кнопке назначает сооветствующее число из массива.
    public void SetAllButtonsTextFromArr(Control.ControlCollection control)
    {
        var i = 16;
        var arrIndex = 15;
        do
        {
            foreach (var obj in control)
                if (obj is Button && ((Button)obj).Name == "gameField_button" + i)
                    ((Button)obj).Text = _arr[arrIndex].ToString();
            i--;
            arrIndex--;
        } while (i > 0 && arrIndex > -1);
    }

    // Метод заполнения массива случайными уникальными числами.
    private void FillArrRandomNumbers()
    {
        var random = new Random();
        for (var j = 0; j < 16; j++)
        {
            _arr[j] = random.Next(0, 101);
            for (var i = 0; i < j; i++)
                if (_arr[i] == _arr[j])
                {
                    j--;
                    break;
                }
        }
    }

    // Возвращает true, если пользователем выбрано минимальное число.
    public bool IsMinNumber()
    {
        // Ищем минимальное число.
        var min = _arr[0];
        var posOfMin = 0;
        for (var i = 0; i < _arr.Length; i++)
            if (_arr[i] < min)
            {
                min = _arr[i];
                posOfMin = i;
            }

        // Сравниваем минимальное число с числом выбранным пользователем.
        // И если они одиаковы, то возвращаем true.
        if (min.ToString() == SelectedNumberIs.ToString())
        {
            // Замена использованного числа на число больше за верхнюю границу в игре.
            _arr[posOfMin] = 999;
            return true;
        }

        return false;
    }

    // Сыграем еще ?.
    public void AskPlayMore()
    {
        var result = MessageBox.Show("Сыграем еще ?", "Почти пятнашки !", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        if (result == DialogResult.No)
            Application.Exit();
        else if (result == DialogResult.Yes)
            Application.Restart();
    }

    // Подведение итогов.
    public void SummarizingInfoForLosers()
    {
        var wasPressed = 0;
        foreach (var i in _arr)
            if (i == 999)
                wasPressed++;
        MessageBox.Show("Вы не успели нажать " + (16 - wasPressed) + " кнопок.", "Почти пятнашки !",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    // Ай, молодец ! Вы справились за **** секунд.
    public void EarlyVictory()
    {
        MessageBox.Show("Ай, молодец ! Вы справились раньше и у вас еще осталось " + TimeLeft + " секунд.",
            "Почти пятнашки !", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }
}