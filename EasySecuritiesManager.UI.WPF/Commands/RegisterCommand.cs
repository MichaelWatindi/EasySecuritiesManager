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
 *  Created 4/24/2021 12:14:40 PM
 *  Modified 4/24/2021 12:14:40 PM
 */
using EasySecuritiesManager.Domain.Services.AuthenticationServices;
using EasySecuritiesManager.UI.WPF.State.Authenticators;
using EasySecuritiesManager.UI.WPF.State.Navigators;
using EasySecuritiesManager.UI.WPF.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace EasySecuritiesManager.UI.WPF.Commands
{
    public class RegisterCommand : AsyncCommandBase
    {
        private readonly RegisterViewModel  _registerViewModel ;
        private readonly IAuthenticator     _authenticator ;
        private readonly IRenavigator       _renavigator ;

        public RegisterCommand( RegisterViewModel   registerViewModel, 
                                IAuthenticator      authenticator, 
                                IRenavigator        renavigator )
        {
            _registerViewModel  = registerViewModel ;
            _authenticator      = authenticator ;
            _renavigator        = renavigator ;

            _registerViewModel.PropertyChanged += RegisterViewModel_PropertyChanged ;
        }

        private void RegisterViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof( RegisterViewModel.CanRegister )) { OnCanExecuteChanged() ; }
        }

        public override bool CanExecute(object parameter)
        {
            return _registerViewModel.CanRegister &&  base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync( object parameter )
        {
            _registerViewModel.ErrorMessageViewModel.Message = string.Empty ;
            try
            {
                RegistrationResult registrationResult = await _authenticator.Register(
                                                                    _registerViewModel.Email,
                                                                    _registerViewModel.Username,
                                                                    _registerViewModel.Password,
                                                                    _registerViewModel.ConfirmPassword
                        );

                switch ( registrationResult )
                {
                    case RegistrationResult.Success:
                        _renavigator.Renavigate();
                        break;
                    case RegistrationResult.PasswordsDoNotMatch:
                        _registerViewModel.ErrorMessageViewModel.Message = "Password and confirmation passwords do not match.";
                        break;
                    case RegistrationResult.EmailAlreadyExists:
                        _registerViewModel.ErrorMessageViewModel.Message = "An account with this email already exists.";
                        break;
                    case RegistrationResult.UsernameAlreadyExists:
                        _registerViewModel.ErrorMessageViewModel.Message = "An account with this username already exists.";
                        break;
                    case RegistrationResult.InvalidPassword:
                        _registerViewModel.ErrorMessageViewModel.Message = "The password used is not valid.";
                        break;
                    case RegistrationResult.InvalidUsername:
                        _registerViewModel.ErrorMessageViewModel.Message = "The username used is not valid.";
                        break;
                    case RegistrationResult.InvalidEmail:
                        _registerViewModel.ErrorMessageViewModel.Message = "The email used is not in a proper format.";
                        break;
                    case RegistrationResult.Failed:
                        _registerViewModel.ErrorMessageViewModel.Message = "Registration failed. Contact the software vendor for further instructions.";
                        break;
                    default:
                        _registerViewModel.ErrorMessageViewModel.Message = "Registration failed. Contact the software vendor for further instructions.";
                        break;
                }
            }
            catch ( Exception )  {
                _registerViewModel.ErrorMessageViewModel.Message = "Registration failed. Contact the software vendor for further instructions.";
            }
        }
    }
}
