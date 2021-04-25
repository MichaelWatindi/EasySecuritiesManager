using EasySecuritiesManager.UI.WPF.State.Assets;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EasySecuritiesManager.UI.WPF.ViewModels
{
    public class AssetSummaryViewModel : ViewModelBase
    {
        private readonly    AssetStore                              _assetStore ;
        //  Public properties
        public  decimal                 AccountBalance          => _assetStore.AccountBalance ;
        public AssetListingViewModel    pAssetSummaryViewModel  { get ; }

        public AssetSummaryViewModel( AssetStore assetStore ) : base()
        {
            pAssetSummaryViewModel      = new AssetListingViewModel( assetStore, assets => assets.Take( 5 ) ) ;
            _assetStore                 = assetStore;
            _assetStore.StateChanged    += AssetStore_StateChanged ;
        }

        private void AssetStore_StateChanged()
        {
            OnPropertyChanged( nameof( AccountBalance )) ;
        }

        
    }
}
