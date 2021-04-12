using EasySecuritiesManager.Domain.Models;
using EasySecuritiesManager.UI.WPF.State.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySecuritiesManager.UI.WPF.State.Assets
{
    public class AssetStore 
    {
        private readonly IAccountStore _accountStore ;

        //  Public properties
        public decimal                          AccountBalance      => _accountStore.CurrentAccount?.Balance ?? 0;
        public IEnumerable<AssetTransaction>    AssetTransactions   => _accountStore.CurrentAccount?.AssetTransactions ?? new List<AssetTransaction>();

        //  Event
        public event Action StateChanged ;

        public AssetStore( IAccountStore accountStore )
        {
            _accountStore = accountStore;
            _accountStore.StateChanged += OnStateChanged ;
        }

        private void OnStateChanged()
        {
            StateChanged?.Invoke() ;
        }
    }
}
