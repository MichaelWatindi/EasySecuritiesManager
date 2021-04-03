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
using EasySecuritiesManager.UI.WPF.State.Navigators;
using EasySecuritiesManager.UI.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace EasySecuritiesManager.UI.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event    EventHandler    CanExecuteChanged;
        private         INavigator      _navigator ;

        public UpdateCurrentViewModelCommand( INavigator navigator )
        {
            _navigator = navigator;
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

                switch ( viewType )
                {
                    case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel() ;
                        break;
                    case ViewType.Portfolio:
                        _navigator.CurrentViewModel = new PortfolioViewModel() ;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
