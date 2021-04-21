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
 *  Created 4/8/2021 5:58:33 PM
 *  Modified 4/8/2021 5:58:33 PM
 */
using EasySecuritiesManager.Domain.Exceptions;
using EasySecuritiesManager.Domain.Services;
using EasySecuritiesManager.UI.WPF.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace EasySecuritiesManager.UI.WPF.Commands
{
    class SearchSymbolCommand : ICommand
    {
        private readonly BuyViewModel           _viewModel;
        private readonly IGetStockPriceService  _stockPriceService;

        public event EventHandler CanExecuteChanged;
        public SearchSymbolCommand( BuyViewModel            viewModel, 
                                    IGetStockPriceService   stockPriceService )
        {
            _viewModel = viewModel;
            _stockPriceService = stockPriceService;
        }

        public bool CanExecute( object parameter ) => true ;

        public async void Execute( object parameter )
        {
            try {
                decimal stockPrice              = await _stockPriceService.GetPrice(_viewModel.Symbol);
                _viewModel.SearchResultSymbol   = _viewModel.Symbol.ToUpper() ;
                _viewModel.StockPrice           = stockPrice ;

            } catch ( InvalidSymbolException ) {
                _viewModel.ErrorMessageViewModel.Message = "Symbol does not exist" ;
            } catch ( Exception e )  {
                MessageBox.Show( e.Message ) ;
                _viewModel.ErrorMessageViewModel.Message = "Failed to get symbol information";
            }
        }
    }
}
