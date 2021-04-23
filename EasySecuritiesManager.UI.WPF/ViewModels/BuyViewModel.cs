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
 *  Created 4/2/2021 7:25:12 PM
 *  Modified 4/2/2021 7:25:12 PM
 */

using EasySecuritiesManager.Domain.Services;
using EasySecuritiesManager.Domain.Services.TransactionServices;
using EasySecuritiesManager.UI.WPF.Commands;
using EasySecuritiesManager.UI.WPF.State.Accounts;
using System.Windows.Input;

namespace EasySecuritiesManager.UI.WPF.ViewModels
{
    public class BuyViewModel : ViewModelBase
    {       
        public ICommand SearchSymbolCommand { get ; set ; }
        public ICommand BuyStockCommand     { get ; set ; }
         
        private string _symbol;
        public string Symbol
        {
            get => _symbol ; 
            set { 
                _symbol = value;
                OnPropertyChanged( nameof( Symbol )) ;
            }
        }

        private decimal _stockPrice;
        public decimal StockPrice
        {
            get => _stockPrice;
            set {
                _stockPrice = value;
                OnPropertyChanged( nameof( StockPrice )) ;
                OnPropertyChanged( nameof( TotalPrice )) ;
            }
        }

        private int _sharesToBuy ;
        public int SharesToBuy
        {
            get => _sharesToBuy;
            set {
                _sharesToBuy = value;
                OnPropertyChanged( nameof( SharesToBuy )) ;
                OnPropertyChanged( nameof( TotalPrice )) ;
            }
        }

        private string _searchResultSymbol = string.Empty ;
        public string SearchResultSymbol
        {
            get => _searchResultSymbol ;
            set {
                _searchResultSymbol = value ;
                OnPropertyChanged( nameof( SearchResultSymbol )) ;
            }
        }
        public decimal TotalPrice => SharesToBuy * StockPrice ;

        public BuyViewModel(    IGetStockPriceService   stockPriceService, 
                                IBuyStockService        buyStockService, 
                                IAccountStore           accountStore ) : base()
        {
            SearchSymbolCommand     = new SearchSymbolCommand( this, stockPriceService ) ;
            BuyStockCommand         = new BuyStockCommand( this, buyStockService, accountStore ) ;
            ErrorMessageViewModel   = new MessageViewModel() ;
            StatusMessageViewModel  = new MessageViewModel() ;
        }

    }
}
