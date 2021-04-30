/**
 *  Tindi Systems Inc
 *  $specifiedsolutionname$ $projectname$
 *  See Copyright file at the top of the source tree.
 *
 *  This product includes software developed by the 
 *  Tindi Systems
 *
 *  @file $filename$
 *
 *  @brief
 *
 *  @author Michael Watindi
 *  See contact information in the license file at the top of the source tree.
 *
 *  Copyright (c) 2021 Tindi Systems Inc.
 *  All Rights Reserved.
 *  
 *  Created 4/25/2021 12:25:56 AM
 *  Modified 4/25/2021 12:25:56 AM
 */
using EasySecuritiesManager.Domain.Models;
using EasySecuritiesManager.UI.WPF.State.Assets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EasySecuritiesManager.UI.WPF.ViewModels
{
    public class AssetListingViewModel : ViewModelBase
    {
        private readonly AssetStore                                                     _assetStore;
        private readonly Func<IEnumerable<AssetViewModel>, IEnumerable<AssetViewModel>> _filterAssets;
        private readonly ObservableCollection<AssetViewModel>                           _assets;
        public IEnumerable<AssetViewModel> Assets => _assets ;

        public AssetListingViewModel(   AssetStore                                                      assetStore, 
                                        Func<IEnumerable<AssetViewModel>, IEnumerable<AssetViewModel>>  filterAssets )
        {
            _assetStore     = assetStore;
            _filterAssets   = filterAssets;
            _assets         = new ObservableCollection<AssetViewModel>();

            _assetStore.StateChanged += AssetStore_StateChanged;
            ResetAssets();
        }
        ~AssetListingViewModel()
        {

        }

        public AssetListingViewModel( AssetStore assetStore ) : this( assetStore, assets => assets ) { }

        private void ResetAssets()
        {
            IEnumerable<AssetViewModel> assetViewModels = _assetStore.AssetTransactions
                .GroupBy( t => t.TheAsset.Symbol )
                .Select( g => new AssetViewModel( g.Key, g.Sum(a => a.IsPurchase ? a.Shares : -a.Shares )))
                .Where( a => a.Shares > 0 )
                .OrderByDescending( a => a.Shares ) ;

            assetViewModels = _filterAssets( assetViewModels ) ;

            _assets.Clear();

            foreach ( AssetViewModel viewModel in assetViewModels )
            {
                _assets.Add( viewModel );
            }
        }

        private void AssetStore_StateChanged() =>  ResetAssets();

        public override void Dispose()
        {
            // _assetStore.StateChanged -= AssetStore_StateChanged ;
            base.Dispose();
        }


    }
}
