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
using EasySecuritiesManager.UI.WPF.State.Accounts;
using System;
using System.Threading.Tasks;

namespace EasySecuritiesManager.UI.WPF.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly    IAuthenticationService _authenticationService ;
        private readonly    IAccountStore          _accountStore;
        
        public Account      CurrentAccount 
        { 
            get => _accountStore.CurrentAccount ; 
            private set { 
                _accountStore.CurrentAccount = value ;
                StateChanged?.Invoke() ;
            }
            
        }
        public bool         IsLoggedIn => CurrentAccount != null;

        public event Action StateChanged;

        public Authenticator(   IAuthenticationService  authenticationService, 
                                IAccountStore           accountStore )
        {
            _authenticationService  = authenticationService ;
            _accountStore           = accountStore ;
        }     

        public async Task<bool> Login( string username, string password )
        {
            try {
                CurrentAccount = await _authenticationService.Login( username, password );
                return true ; 
            } catch ( Exception e ) {
                string i = e.Message;
                return false ; 
            }
        }

        public void Logout() => CurrentAccount = null ;        

        public async Task<RegistrationResult> Register( string email, 
                                                        string username, 
                                                        string password, 
                                                        string confirmPassword )
        {
           return await _authenticationService.Register( email, username, password, confirmPassword ) ;
        }
    }
}
