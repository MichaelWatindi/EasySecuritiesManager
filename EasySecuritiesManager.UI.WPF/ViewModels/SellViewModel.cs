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
 *  Created 4/2/2021 7:25:28 PM
 *  Modified 4/2/2021 7:25:28 PM
 */
using EasySecuritiesManager.Domain.Services;
using EasySecuritiesManager.UI.WPF.Commands;
using EasySecuritiesManager.UI.WPF.State.Assets;
using System;
using System.Windows.Input;

namespace EasySecuritiesManager.UI.WPF.ViewModels
{
    public class SellViewModel : ViewModelBase, ISearchSymbolViewModel
    {
        private AssetViewModel _selectedAsset;
        public  AssetListingViewModel   pAssetListingViewModel { get ; }        

        public AssetViewModel SelectedAsset
        {
            get => _selectedAsset ; 
            set { 
                _selectedAsset  = value ; 
                OnPropertyChanged( nameof( SelectedAsset )) ;
            }
        }

        public ICommand SearchSymbolCommand { get ; }
        public ICommand SellStockCommand    { get ; }

        private string _symbol;
        public string Symbol
        {
            get => _symbol;
            set
            {
                _symbol = value;
                OnPropertyChanged( nameof( Symbol ));
            }
        }

        private decimal _stockPrice;
        public decimal StockPrice
        {
            get => _stockPrice;
            set
            {
                _stockPrice = value;
                OnPropertyChanged( nameof( StockPrice )) ;
                OnPropertyChanged( nameof( TotalPrice )) ;
            }
        }

        private string _searchResultSymbol = string.Empty ;
        public string SearchResultSymbol
        {
            get => _searchResultSymbol;
            set
            {
                _searchResultSymbol = value;
                OnPropertyChanged( nameof( SearchResultSymbol )) ;
            }
        }

        private int _sharesToSell ;

        public int SharesToSell
        {
            get => _sharesToSell ; 
            set { 
                _sharesToSell  = value ;
                OnPropertyChanged( nameof( SharesToSell )) ;
                OnPropertyChanged( nameof( TotalPrice )) ;

            }
        }

        public decimal TotalPrice => SharesToSell * StockPrice ;

        public SellViewModel( AssetStore assetStore, IGetStockPriceService stockPriceService ) : base()
        {
            pAssetListingViewModel  = new AssetListingViewModel( assetStore ) ;
            SearchSymbolCommand     = new SearchSymbolCommand( this, stockPriceService ); 
        }
    }
}
