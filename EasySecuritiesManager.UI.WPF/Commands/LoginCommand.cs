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
using System.ComponentModel;
using System.Threading.Tasks;

namespace EasySecuritiesManager.UI.WPF.Commands
{
    public class LoginCommand : AsyncCommandBase
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

            _loginViewModel.PropertyChanged += LoginViewModel_PropertyChanged ;
        }

        public override bool CanExecute(object parameter)
        {
            return _loginViewModel.CanLogin &&  base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync( object parameter )
        {
            _loginViewModel.ErrorMessageViewModel.Message = string.Empty ;
            bool success = await _authenticator.Login( _loginViewModel.Username, parameter.ToString() ) ;

            if ( success ) { 
                _reNavigator.Renavigate() ; 
            } 
            else {
                _loginViewModel.ErrorMessageViewModel.Message = "Login Failed. Invalid username or password." ;
            }
        }

        private void LoginViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.CanLogin)) { OnCanExecuteChanged(); }
        }
    }
}
