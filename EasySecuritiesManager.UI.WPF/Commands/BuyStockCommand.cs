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
 *  Created 4/8/2021 7:13:59 PM
 *  Modified 4/8/2021 7:13:59 PM
 */
using EasySecuritiesManager.Domain.Models;
using EasySecuritiesManager.Domain.Services.TransactionServices;
using EasySecuritiesManager.UI.WPF.State.Accounts;
using EasySecuritiesManager.UI.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace EasySecuritiesManager.UI.WPF.Commands
{
    public class BuyStockCommand : ICommand
    {
        public  event       EventHandler        CanExecuteChanged;
        private readonly    BuyViewModel        _buyViewModel ;
        private readonly    IBuyStockService    _buyStockService ;
        private readonly    IAccountStore       _accountStore;

        public BuyStockCommand( BuyViewModel        buyViewModel, 
                                IBuyStockService    buyStockService,
                                IAccountStore       accountStore )
        {
            _buyViewModel       = buyViewModel;
            _buyStockService    = buyStockService;
            _accountStore       = accountStore;
        }

        public bool CanExecute( object parameter ) => true ; 
      
        public async void Execute( object parameter )
        {
            try {
                Account account = await _buyStockService.BuyStock(  _accountStore.CurrentAccount,  
                                                                    _buyViewModel.Symbol, 
                                                                    _buyViewModel.SharesToBuy ) ;
                _accountStore.CurrentAccount = account ;
            }
            catch ( Exception e )  {
                MessageBox.Show( e.Message ) ;
            }
        }
    }
}
