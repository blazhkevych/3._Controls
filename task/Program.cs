namespace task
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        /// �������� ����, ����� ������� ������� � ���������. �� �������
        /// ���� ������� 16 ������, ������, ������� � ���������. ��� �������
        /// ���� (������ ������ ����) �� ������ ���������� 16 ���������
        /// ����� �� ��������� �� 0 �� 100. ������ ������� � ���, ����� ��
        /// ��������� ����� ������ (���� �� ���������� ���� ���������) 
        /// �������� �� ���� ������� � ������� ����������� �����. ��� �������
        /// �� ������ ����� ������ ����������� � ������ ������ � ��� ������, 
        /// ���� ��� ����� �������� ��������� �� �����������.

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