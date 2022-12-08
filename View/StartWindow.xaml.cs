﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Controller;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            var controller = new StartWindowController();
            InitializeComponent();
        }

        private void LetsGoButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(PlayerNickTextBox.Text))
            {
                if (controller.IsPlayerByNickExist(PlayerNickTextBox.Text))
                    MessageBox.Show("С возвращением");
                else
                    MessageBox.Show("Добро пожаловать! Рады новым пользователям.");
                var form = new MenuWindow();
                form.ShowDialog();
            }
            else
                MessageBox.Show("Значение имени не может быть пустым.");
        }
        private StartWindowController controller;
    }
}
