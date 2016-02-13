﻿using System;
using System.Windows;
using System.ServiceModel;

namespace Server
{
    public partial class Window1 : Window
    { 
        // Ссылка на экзкмпляр ServiceHost.
        ServiceHost service = null;

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
                                        
                    // Начало ожидания прихода сообщений.
                    service.Open();

                    textBox1.Text += "Сервер запущен.         "  + DateTime.Now + Environment.NewLine;
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
}
