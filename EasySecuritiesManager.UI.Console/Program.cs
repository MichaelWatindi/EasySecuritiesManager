using EasySecuritiesManager.Domain.Models;
using EasySecuritiesManager.Domain.Services;
using EasySecuritiesManager.EntityFramework;
using EasySecuritiesManager.EntityFramework.Services;
using EasySecuritiesManager.FinancialModelingPrepApi.Services;
using System;
using System.Linq;

namespace EasySecuritiesManager.UI.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            //IDataService<User> userService = new GenericDataService<User>(new EasySecuritiesManagerDbContextFactory() ) ;
            //// userService.CreateAsync( new User { Username = "Test", Email = "Test@gmail.com", PasswordHash = Guid.NewGuid().ToString() } ).Wait() ;
            //Console.WriteLine( userService.GetAllAsync().Result.Count() ) ;
            //Console.WriteLine( userService.GetAsync( 2 ).Result ) ;
            System.Console.WriteLine( "" ) ;
        }

        static void Test_FinancialModelingPrepApi()
        {
            new MajorIndexService().GetMajorIndex(Domain.Models.MajorIndexType.DowJones).ContinueWith((task) =>
            {
                var index = task.Result;
            });
        }
    }
}
