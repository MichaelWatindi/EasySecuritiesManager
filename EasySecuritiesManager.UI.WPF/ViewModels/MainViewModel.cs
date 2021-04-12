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
 *  Created 4/2/2021 4:31:50 PM
 *  Modified 4/2/2021 4:31:50 PM
 */
using EasySecuritiesManager.UI.WPF.Commands;
using EasySecuritiesManager.UI.WPF.State.Authenticators;
using EasySecuritiesManager.UI.WPF.State.Navigators;
using EasySecuritiesManager.UI.WPF.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace EasySecuritiesManager.UI.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator       Navigator               { get; set ; }
        public IAuthenticator   Authenticator           { get; }
        public IEasySecuritiesRootManagerViewModelFactory ViewModelFactory { get; }
        public ICommand         UpdateCurrentViewModelCommand  { get;  }

        public MainViewModel( INavigator navigator, IAuthenticator authenticator, IEasySecuritiesRootManagerViewModelFactory viewModelFactory )
        {
            Navigator       = navigator ;
            Authenticator   = authenticator;
            ViewModelFactory = viewModelFactory;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand( navigator, viewModelFactory );
            UpdateCurrentViewModelCommand.Execute( ViewType.Login ) ;
        }       
    }
}
