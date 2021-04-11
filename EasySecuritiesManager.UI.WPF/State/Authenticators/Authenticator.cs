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
 *  Created 4/11/2021 7:17:47 AM
 *  Modified 4/11/2021 7:17:47 AM
 */
using EasySecuritiesManager.Domain.Models;
using EasySecuritiesManager.Domain.Services.AuthenticationServices;
using EasySecuritiesManager.UI.WPF.Models;
using System;
using System.Threading.Tasks;

namespace EasySecuritiesManager.UI.WPF.State.Authenticators
{
    public class Authenticator : ObservableObject, IAuthenticator
    {
        private readonly    IAuthenticationService _authenticationService ;

        private Account     _currentUser ;
        public Account      CurrentUser 
        { 
            get => _currentUser ; 
            private set {
                _currentUser = value ;
                OnPropertyChanged( nameof( CurrentUser )) ;
                OnPropertyChanged( nameof( IsLoggedIn )) ;
            }
        }
        public bool         IsLoggedIn => CurrentUser != null;

        public Authenticator( IAuthenticationService authenticationService )
        {
            _authenticationService = authenticationService;
        }     

        public async Task<bool> Login( string username, string password )
        {
            try {
                CurrentUser = await _authenticationService.Login( username, password );
                return true ; 
            } catch ( Exception e ) {
                return false ; 
            }
        }

        public void Logout() => CurrentUser = null ;        

        public async Task<RegistrationResult> Register( string email, 
                                                        string username, 
                                                        string password, 
                                                        string confirmPassword )
        {
           return await _authenticationService.Register( email, username, password, confirmPassword ) ;
        }
    }
}
