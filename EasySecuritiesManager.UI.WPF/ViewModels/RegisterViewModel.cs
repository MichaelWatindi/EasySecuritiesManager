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
 *  Created 4/23/2021 8:37:57 PM
 *  Modified 4/23/2021 8:37:57 PM
 */
using EasySecuritiesManager.UI.WPF.Commands;
using EasySecuritiesManager.UI.WPF.State.Authenticators;
using EasySecuritiesManager.UI.WPF.State.Navigators;
using System.Windows.Input;

namespace EasySecuritiesManager.UI.WPF.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private string _email ;
        public string Email
        {
            get => _email ; 
            set { 
                _email = value;
                OnPropertyChanged( nameof( Email )) ;
            }
        }

        private string _username ;
        public string Username
        {
            get => _username; 
            set {
                _username = value;
                OnPropertyChanged( nameof( Username )) ;
            }
        }

        private string _password ;
        public string Password
        {
            get => _password; 
            set {
                _password = value;
                OnPropertyChanged( nameof( Password )) ;
            }
        }

        private string _confirmPassword ;
        public string ConfirmPassword
        {
            get => _confirmPassword; 
            set {
                _confirmPassword = value ;
                OnPropertyChanged( nameof( ConfirmPassword )) ;
            }
        }

        public ICommand pRegisterCommand     { get ; }
        public ICommand ViewLoginCommand    { get ; }

        public RegisterViewModel(   IAuthenticator  authenticator, 
                                    IRenavigator    registerRenavigator, 
                                    IRenavigator    loginRenavigator )
        {
            ErrorMessageViewModel   = new MessageViewModel() ;
            ViewLoginCommand        = new RenavigateCommand( loginRenavigator ) ;
            pRegisterCommand        = new RegisterCommand(this, authenticator, registerRenavigator ) ;
        }
    }
}
