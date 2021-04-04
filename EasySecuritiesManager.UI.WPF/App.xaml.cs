﻿using EasySecuritiesManager.FinancialModelingPrepApi.Services;
using EasySecuritiesManager.UI.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EasySecuritiesManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            string apiKey = ConfigurationManager.AppSettings.Get( "financeApiKey" ) ;
            
            Window window = new MainWindow() ;
            window.Show() ;
            window.DataContext = new MainViewModel() ;
            
            base.OnStartup( e ) ;
        }
    }
}
