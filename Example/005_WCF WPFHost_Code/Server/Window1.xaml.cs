using System;
using System.Windows;
using System.ServiceModel;

// ХОСТ.

namespace Server
{
    //Синглетный уровень – когда создается один сингелтон единственная его копия. 
    //Сингелтон поочереди обрабатывает сообщение разных консюмеров

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] //Екземпляр класса будет синглетным
    public partial class Window1 : Window, IContract
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
                    service = new ServiceHost(this);

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


        //***************************************************************
        // СЕРВИС.       

        public string Say(string input)
        {            
            textBox1.Text += "From Client:   " + input + Environment.NewLine;

            return "Вы сказали - " + input;
        }
        //***************************************************************
    }
}
