using System;
using System.Windows;
using System.ServiceModel;

// КЛИЕНТ.

namespace Client
{    
    public partial class Window1 : Window
    {
        // Указание, где ожидать входящие сообщения.
        Uri address = new Uri("http://localhost:4000/Service");

        // Указание, как обмениваться сообщениями.
        BasicHttpBinding binding = new BasicHttpBinding();

        // Ссылка на экземпляр ChannelFactory<T>, где Т - Контракт.
        ChannelFactory<IContract> factory = null;

        // Ссылка на канал (прокси).
        IContract channel = null;

        // Конструктор.
        public Window1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (factory == null)
                {
                    // Создание экземпляра ChannelFactory<T>, где Т - Контракт.
                    factory = new ChannelFactory<IContract>(binding, new EndpointAddress(address));

                    // Использование factory для создания канала (прокси).
                    channel = factory.CreateChannel();
                }

                if (factory != null && channel != null)
                {
                    textBox1.Text += "From Me:  " + textBox2.Text + Environment.NewLine;

                    // Использование channel (прокси) для отправки сообщения получателю.
                    textBox1.Text += channel.Say(textBox2.Text) + Environment.NewLine;

                    textBox2.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Реакция на изменение textBox1.
        private void textBox1_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            textBox1.ScrollToEnd();
        }
    }
}
