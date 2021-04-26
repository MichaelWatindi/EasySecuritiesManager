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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        private readonly IHost _host ;

        public App()
        {
            _host = CreateHostBuilder().Build()  ;
        }

        public static IHostBuilder CreateHostBuilder( string[] args = null )
        {
            return  Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration( c =>
                {
                    c.AddJsonFile( "appsettings.json" ) ;
                    c.AddEnvironmentVariables( ) ;
                })
                .ConfigureServices( (context, services) =>
                {
                    string connectionString = context.Configuration.GetConnectionString( "sqlite" ) ;
                    Action<DbContextOptionsBuilder> configureDBContext = o => o.UseSqlite( connectionString ) ;

                    services.AddDbContext<EasySecuritiesManagerDBContext>( configureDBContext ) ;
                    services.AddSingleton<EasySecuritiesManagerDbContextFactory>( new EasySecuritiesManagerDbContextFactory( configureDBContext ) );
                    services.AddSingleton<IDataService<Account>, AccountDataService>();
                    services.AddSingleton<IAccountService, AccountDataService>();
                    services.AddSingleton<IAuthenticationService, AuthenticationService>();
                    services.AddSingleton<IGetStockPriceService, GetStockPriceService>();
                    services.AddSingleton<IBuyStockService, BuyStockService>();
                    services.AddSingleton<ISellStockService, SellStockService>();

                    services.AddSingleton<IPasswordHasher, PasswordHasher>();

                    services.AddSingleton<IMajorIndexService, MajorIndexService>();
                    services.AddSingleton<IViewModelFactory, ViewModelFactory>();

                    services.AddSingleton<BuyViewModel>();
                    services.AddSingleton<PortfolioViewModel>();
                    services.AddSingleton<AssetSummaryViewModel>();
                    services.AddSingleton<HomeViewModel>(services =>
                    {
                        return new HomeViewModel(MajorIndexListingViewModel.LoadMajorIndexViewModel(
                            services.GetRequiredService<IMajorIndexService>()),
                            services.GetRequiredService<AssetSummaryViewModel>() );
                    });

                    services.AddSingleton<CreateViewModel<HomeViewModel>>( services =>
                    {
                        return () => services.GetRequiredService<HomeViewModel>() ;
                    });

                    services.AddSingleton<CreateViewModel<BuyViewModel>>( services =>
                    {
                        return () => services.GetRequiredService<BuyViewModel>();
                    });

                    services.AddSingleton<CreateViewModel<PortfolioViewModel>>( services =>
                    {
                        return () => services.GetRequiredService<PortfolioViewModel>();
                    });

                    services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>() ;
                    services.AddSingleton<CreateViewModel<RegisterViewModel>>( services =>
                    {
                        return() => new RegisterViewModel(
                            services.GetRequiredService<IAuthenticator>(),
                            services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                            services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>()
                            ) ;
                    }) ;

                    services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
                    services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();

                    services.AddSingleton<CreateViewModel<LoginViewModel>>( services =>
                    {
                        return () => new LoginViewModel( 
                            services.GetRequiredService<IAuthenticator>(),
                            services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>(),
                            services.GetRequiredService<ViewModelDelegateRenavigator<RegisterViewModel>>() );
                    });

                    services.AddSingleton<INavigator, Navigator>();
                    services.AddSingleton<IAuthenticator, Authenticator>();
                    services.AddSingleton<IAccountStore, AccountStore>();
                    services.AddSingleton<AssetStore>();

                    services.AddScoped<MainViewModel>();

                    services.AddScoped<MainWindow>( s => new WPF.MainWindow( s.GetRequiredService<MainViewModel>()));
                } ) ;
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            //  Get configuration settings
            string apiKey = ConfigurationManager.AppSettings.Get( "financeApiKey" ) ;
            _host.Start() ;

            EasySecuritiesManagerDbContextFactory contextFactory = _host.Services.GetRequiredService<EasySecuritiesManagerDbContextFactory>() ;
            using ( EasySecuritiesManagerDBContext context = contextFactory.CreateDbContext() )
            {
                context.Database.Migrate() ;
            }

            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show() ;            
            base.OnStartup( e ) ;
        }

        protected override async void OnExit( ExitEventArgs e )
        {
            await _host.StopAsync() ;
            _host.Dispose() ;
            base.OnExit(e);
        }
    }
}