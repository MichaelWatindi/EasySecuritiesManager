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
 *  Created 4/11/2021 7:46:21 AM
 *  Modified 4/11/2021 7:46:21 AM
 */
using EasySecuritiesManager.UI.WPF.Commands;
using EasySecuritiesManager.UI.WPF.State.Authenticators;
using EasySecuritiesManager.UI.WPF.State.Navigators;
using System;
using System.Windows.Input;

namespace EasySecuritiesManager.UI.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username ;

        public string Username
        {
            get => _username ; 
            set { 
                _username = value ; 
                OnPropertyChanged( nameof( Username )) ;
            }
        }

        public ICommand LoginCommand { get ; }

        public LoginViewModel( IAuthenticator authenticator, IRenavigator renavigator ) : base() 
        {
            LoginCommand = new LoginCommand( this, authenticator, renavigator ) ;
        }

    }
}
