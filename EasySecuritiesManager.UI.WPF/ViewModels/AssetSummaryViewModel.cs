using EasySecuritiesManager.UI.WPF.State.Assets;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EasySecuritiesManager.UI.WPF.ViewModels
{
    public class AssetSummaryViewModel : ViewModelBase
    {
        private readonly    AssetStore                              _assetStore ;
        private readonly    ObservableCollection<AssetViewModel>    _assets ;

        //  Public properties
        public  decimal                     AccountBalance  => _assetStore.AccountBalance ;
        public IEnumerable<AssetViewModel>  Assets          => _assets ;

        public AssetSummaryViewModel( AssetStore assetStore )
        {
            _assetStore = assetStore;
            _assets     = new ObservableCollection<AssetViewModel>() ;
            _assetStore.StateChanged += AssetStore_StateChanged ;
            ResetAssets() ;
        }

        private void AssetStore_StateChanged()
        {
            OnPropertyChanged( nameof( AccountBalance )) ;
            ResetAssets() ;
        }

        private void ResetAssets()
        {
            IEnumerable<AssetViewModel> assetViewModels = 
                _assetStore.AssetTransactions
                        .GroupBy( t => t.TheAsset.Symbol )
                        .Select( g => new AssetViewModel( g.Key, g.Sum( a => a.IsPurchase?  a.Shares : a.Shares )));
            _assets.Clear() ;

            foreach( AssetViewModel viewModel in assetViewModels )
            {
                _assets.Add( viewModel ) ;
            }
                                                            
        }
    }
}
