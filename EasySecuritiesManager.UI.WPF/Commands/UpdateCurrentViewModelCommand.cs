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
 *  Created 4/2/2021 7:34:33 PM
 *  Modified 4/2/2021 7:34:33 PM
 */
using EasySecuritiesManager.FinancialModelingPrepApi.Services;
using EasySecuritiesManager.UI.WPF.State.Navigators;
using EasySecuritiesManager.UI.WPF.ViewModels;
using EasySecuritiesManager.UI.WPF.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace EasySecuritiesManager.UI.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public  event    EventHandler    CanExecuteChanged;
        private readonly INavigator      _navigator ;
        private readonly IEasySecuritiesRootManagerViewModelFactory _viewModelFactory ;
            
        public UpdateCurrentViewModelCommand(INavigator navigator, 
                IEasySecuritiesRootManagerViewModelFactory viewModelFactory)
        {
            _navigator          = navigator;
            _viewModelFactory   = viewModelFactory;
        }

        public bool CanExecute( object parameter )
        {
            return true ;
        }

        public void Execute( object parameter )
        {
            if ( parameter is ViewType )
            {
                ViewType viewType = ( ViewType ) parameter ;

                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel( viewType ) ;
            }
        }
    }
}
