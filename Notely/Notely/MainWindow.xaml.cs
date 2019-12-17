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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Notely.Domain.Users.Policies;
using Notely.Pages;
using Notely.SharedKernel.Application.Handlers;

namespace Notely
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICommandDispatcher _commandDispatcher;
        public MainWindow(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RegisterPage(_commandDispatcher));
        }
    }
}