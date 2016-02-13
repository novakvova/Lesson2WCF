using System;
using System.Linq;
using System.Windows;
using System.ServiceModel;

// ХОСТ.

namespace Server
{
    public partial class Window1
    {
        // Указание, где ожидать входящие сообщения.
        Uri address = new Uri("http://localhost:4000/IContract");

        // Указание, как обмениваться сообщениями.
        BasicHttpBinding binding = new BasicHttpBinding();

        // Ссылка на экзкмпляр ServiceHost.
        ServiceHost service;

        // Конструктор.
        public Window1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (service == null)
                {
                    // Создание экзкмпляра ServiceHost.
                    service = new ServiceHost(typeof(Service));

                    // Добавление "Конечной Точки".
                    service.AddServiceEndpoint(typeof(IContract), binding, address);

                    // Начало ожидания прихода сообщений.
                    service.Open();

                    textBox1.Text += "Сервер запущен.         " + DateTime.Now + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (service != null)
                {
                    // Завершение ожидания прихода сообщений.
                    service.Close();
                    service = null;

                    textBox1.Text += "Сервер остановлен.    " + DateTime.Now + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
 
    // Сервис
    class Service : IContract
    {
        public string Say(string input)
        {
            UiConnection.UpdateText("From Client:   " + input + Environment.NewLine);

            return "Вы сказали - " + input;
        }
    }

    internal static class UiConnection
    {
        // Получаем ссылку на текущую форму
        static readonly Window1 Window1 = 
            Application.Current.Windows
            .Cast<Window>()
            .FirstOrDefault(window => window is Window1) as Window1; 

        // Изменяем состояние контрола
        internal static void UpdateText(string @string)
        {
            Window1.textBox1.Text += Environment.NewLine + @string;
        }
    }
}
