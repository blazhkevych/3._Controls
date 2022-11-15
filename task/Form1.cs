namespace task
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// �������� ����, ����� ������� ������� � ���������. �� �������
        /// ���� ������� 16 ������, ������, ������� � ���������. ��� �������
        /// ���� (������ ������ ����) �� ������ ���������� 16 ���������
        /// ����� �� ��������� �� 0 �� 100. ������ ������� � ���, ����� ��
        /// ��������� ����� ������ (���� �� ���������� ���� ���������) 
        /// �������� �� ���� ������� � ������� ����������� �����. ��� �������
        /// �� ������ ����� ������ ����������� � ������ ������ � ��� ������, 
        /// ���� ��� ����� �������� ��������� �� �����������
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // ����� ����� ��������� ���� � ��������.
            // ����� �������� ������ ����� ������� ������ "������ ����".
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

        }

        private void NewGame_button17_Click(object sender, EventArgs e)
        {
            // �������� ������� ����.
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

            // ��������� ������� ���� ���������� ������� �� 0 �� 100.
            Random random = new Random();
            foreach (Control control in Controls)
                if (control is Button && (control as Button).Text != "����� ����")
                    (control as Button).Text = random.Next(0, 101).ToString();

            // ��������� ������ �� �������� ������. 
            timer1.Start();


        }

        private void CountdownStart_timer1_Tick(object sender, EventArgs e)
        {
            this.Text = GameTime_numericUpDown1.Value.ToString();
        }
    }
}