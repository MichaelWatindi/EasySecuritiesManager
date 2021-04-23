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
 *  Created 4/11/2021 10:56:57 AM
 *  Modified 4/11/2021 10:56:57 AM
 */
using EasySecuritiesManager.UI.WPF.State.Authenticators;
using EasySecuritiesManager.UI.WPF.State.Navigators;
using EasySecuritiesManager.UI.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace EasySecuritiesManager.UI.WPF.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly IAuthenticator _authenticator ;
        private readonly IRenavigator   _reNavigator;
        private readonly LoginViewModel _loginViewModel ;

        public LoginCommand( LoginViewModel loginViewModel,
                             IAuthenticator authenticator, 
                             IRenavigator   navigator )
        {
            _authenticator  = authenticator ;
            _reNavigator    = navigator;
            _loginViewModel = loginViewModel ;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute( object parameter ) => true ;       

        public async void Execute( object parameter )
        {
            bool success = await _authenticator.Login( _loginViewModel.Username, parameter.ToString() ) ;

            if ( success ) { 
                _reNavigator.Renavigate() ; 
            } else {
                _loginViewModel.ErrorMessageViewModel.Message = "Login Failed. Invalid username or password." ;
            }
        }
    }
}
