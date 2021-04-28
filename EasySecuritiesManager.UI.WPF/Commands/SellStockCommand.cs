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
 *  Created 4/28/2021 4:58:03 AM
 *  Modified 4/28/2021 4:58:03 AM
 */
using EasySecuritiesManager.Domain.Exceptions;
using EasySecuritiesManager.Domain.Models;
using EasySecuritiesManager.Domain.Services.TransactionServices;
using EasySecuritiesManager.UI.WPF.State.Accounts;
using EasySecuritiesManager.UI.WPF.ViewModels;
using System;
using System.Threading.Tasks;

namespace EasySecuritiesManager.UI.WPF.Commands
{
    public class SellStockCommand : AsyncCommandBase
    {
        private readonly SellViewModel      _sellViewModel ;
        private readonly ISellStockService  _sellStockService ;
        private readonly IAccountStore      _accountStore ;

        public SellStockCommand(    SellViewModel       viewModel, 
                                    ISellStockService   sellStockService, 
                                    IAccountStore       accountStore )
        {
            _sellViewModel      = viewModel;
            _sellStockService   = sellStockService;
            _accountStore       = accountStore;
        }

        public override async Task ExecuteAsync( object parameter )
        {
            _sellViewModel.ErrorMessageViewModel.Message     = string.Empty ;
            _sellViewModel.StatusMessageViewModel.Message    = string.Empty ;

            try
            {
                string symbol   = _sellViewModel.Symbol ;
                int shares      = _sellViewModel.SharesToSell ;
                Account account = await _sellStockService.SellStock(    _accountStore.CurrentAccount,  
                                                                        _sellViewModel.Symbol, 
                                                                        _sellViewModel.SharesToSell ) ;
                _accountStore.CurrentAccount                    = account ;
                _sellViewModel.SearchResultSymbol               = string.Empty ;
                _sellViewModel.StatusMessageViewModel.Message   = $"Successfully sold {shares} share(s) of {symbol}." ;
            }
            catch ( InsufficientSharesException ex ) {
                _sellViewModel.ErrorMessageViewModel.Message = $"Account has insufficient shares. You only have {ex.CurrentAccountShares} shares.";
            } 
            catch ( InvalidSymbolException  ) {
                _sellViewModel.ErrorMessageViewModel.Message = "Symbol could not be found.";
            } 
            catch ( Exception ) {
                _sellViewModel.ErrorMessageViewModel.Message = "Transaction Failed" ;
            }
            bool sold = _sellViewModel.ErrorMessageViewModel.HasMessage ;
        }
    }
}
