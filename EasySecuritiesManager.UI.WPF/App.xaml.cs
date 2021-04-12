using EasySecuritiesManager.Domain.Models;
using EasySecuritiesManager.Domain.Services;
using EasySecuritiesManager.Domain.Services.AuthenticationServices;
using EasySecuritiesManager.Domain.Services.TransactionServices;
using EasySecuritiesManager.EntityFramework;
using EasySecuritiesManager.EntityFramework.Services;
using EasySecuritiesManager.FinancialModelingPrepApi.Services;
using EasySecuritiesManager.UI.WPF.State.Accounts;
using EasySecuritiesManager.UI.WPF.State.Assets;
using EasySecuritiesManager.UI.WPF.State.Authenticators;
using EasySecuritiesManager.UI.WPF.State.Navigators;
using EasySecuritiesManager.UI.WPF.ViewModels;
using EasySecuritiesManager.UI.WPF.ViewModels.Factories;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
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
            services.AddSingleton<IViewModelFactory, ViewModelFactory>() ;

            services.AddSingleton<BuyViewModel>() ;
            services.AddSingleton<PortfolioViewModel>() ;
            services.AddSingleton<AssetSummaryViewModel>() ;
            services.AddSingleton<HomeViewModel>( services => 
            { 
               return new HomeViewModel( MajorIndexListingViewModel.LoadMajorIndexViewModel( services.GetRequiredService<IMajorIndexService>() ), 
                                                                                             services.GetRequiredService<AssetSummaryViewModel>() ) ;
            }) ;
            

            services.AddSingleton<CreateViewModel<HomeViewModel>>( services =>
            {
                return () => services.GetRequiredService<HomeViewModel>();
            }) ;

            services.AddSingleton<CreateViewModel<BuyViewModel>>( services =>
            {
                return () => services.GetRequiredService<BuyViewModel>();
            });

            services.AddSingleton<CreateViewModel<PortfolioViewModel>>( services =>
            {
                return () => services.GetRequiredService<PortfolioViewModel>();
            });

            services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>() ;
            services.AddSingleton<CreateViewModel<LoginViewModel>>( services =>
            {
                return () => new LoginViewModel( services.GetRequiredService<IAuthenticator>(), 
                                                 services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>() );
            });

            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IAccountStore, AccountStore>() ;
            services.AddSingleton<AssetStore>() ;

            services.AddScoped<MainViewModel>() ;
            services.AddScoped<BuyViewModel>() ;
            
            services.AddScoped<MainWindow>( s => new WPF.MainWindow( s.GetRequiredService<MainViewModel>() ) ) ;            

            return services.BuildServiceProvider() ;
        }
    }
}