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
 *  Created 4/2/2021 7:30:39 PM
 *  Modified 4/2/2021 7:30:39 PM
 */

using EasySecuritiesManager.UI.WPF.Commands;
using EasySecuritiesManager.UI.WPF.Models;
using EasySecuritiesManager.UI.WPF.ViewModels;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace EasySecuritiesManager.UI.WPF.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase   _currentViewModel ;
        public ICommand         UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand( this );

        public ViewModelBase    CurrentViewModel        
        { 
            get { return _currentViewModel ; } 
            set {
                _currentViewModel = value ;
                OnPropertyChanged( nameof( CurrentViewModel ) ) ;
            }
        }       
    }
}
