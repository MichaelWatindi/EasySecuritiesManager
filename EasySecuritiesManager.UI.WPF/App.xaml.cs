﻿using EasySecuritiesManager.Domain.Models;
using EasySecuritiesManager.Domain.Services;
using EasySecuritiesManager.Domain.Services.AuthenticationServices;
using EasySecuritiesManager.Domain.Services.TransactionServices;
using EasySecuritiesManager.EntityFramework;
using EasySecuritiesManager.EntityFramework.Services;
using EasySecuritiesManager.FinancialModelingPrepApi.Services;
using EasySecuritiesManager.UI.WPF.State.Authenticators;
using EasySecuritiesManager.UI.WPF.State.Navigators;
using EasySecuritiesManager.UI.WPF.ViewModels;
using EasySecuritiesManager.UI.WPF.ViewModels.Factories;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
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
            //  Get configuration settings
            string apiKey = ConfigurationManager.AppSettings.Get( "financeApiKey" ) ;

            IServiceProvider serviceProvider = CreateServiceProvider() ;

            IAuthenticationService authenticationService = serviceProvider.GetRequiredService<IAuthenticationService>() ;
            authenticationService.Login(    "tindiMike",  
                                            "mypassword" ) ;
                               
            Window window = serviceProvider.GetRequiredService<MainWindow>() ;
            window.Show() ;            
            base.OnStartup( e ) ;
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection() ;

            //  Register our services (Singleton, transient, scoped)
            services.AddSingleton<EasySecuritiesManagerDbContextFactory>() ;
            services.AddSingleton<IDataService<Account>, AccountDataService>() ;
            services.AddSingleton<IAccountService, AccountDataService>() ;
            services.AddSingleton<IAuthenticationService, AuthenticationService>() ;
            services.AddSingleton<IGetStockPriceService, GetStockPriceService>() ;
            services.AddSingleton<IBuyStockService, BuyStockService>() ;

            services.AddSingleton<IPasswordHasher, PasswordHasher>() ;

            services.AddSingleton<IMajorIndexService, MajorIndexService>() ;

            services.AddSingleton<IEasySecuritiesRootManagerViewModelFactory, EasySecuritiesManagerRootViewModelFactory>() ;            
            services.AddSingleton<IEasySecuritiesManagerViewModelFactory<HomeViewModel>, HomeViewModelFactory>() ;
            services.AddSingleton<IEasySecuritiesManagerViewModelFactory<PortfolioViewModel>, PortfolioViewModelFactory>() ;
            services.AddSingleton<IEasySecuritiesManagerViewModelFactory<MajorIndexListingViewModel>, MajorIndexListingViewModelFactory>() ;
            services.AddSingleton<IEasySecuritiesManagerViewModelFactory<LoginViewModel>, LoginViewModelFactory>() ;

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<IAuthenticator, Authenticator>();

            services.AddScoped<MainViewModel>() ;
            services.AddScoped<BuyViewModel>() ;
            
            services.AddScoped<MainWindow>( s => new WPF.MainWindow( s.GetRequiredService<MainViewModel>() ) ) ;            

            return services.BuildServiceProvider() ;
        }
    }
}