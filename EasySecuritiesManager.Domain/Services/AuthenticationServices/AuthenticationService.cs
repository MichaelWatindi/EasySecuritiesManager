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
 *  Created 4/9/2021 6:35:17 PM
 *  Modified 4/9/2021 6:35:17 PM
 */
using EasySecuritiesManager.Domain.Exceptions;
using EasySecuritiesManager.Domain.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace EasySecuritiesManager.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService ;
        private readonly IPasswordHasher _passwordHasher ;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher )
        {
            _accountService = accountService ;
            _passwordHasher = passwordHasher ;
        }

        public async Task<Account> Login( string usernameOrEmail, string password )
        {
            Account storedUserAcc   = await _accountService.GetByUserName( usernameOrEmail ) ;
            // Account storedEmailAcc  = await _accountService.GetByEmail( usernameOrEmail ) ;

            if ( storedUserAcc == null ) { throw new UserNotFoundException( usernameOrEmail ) ; }
            /*
            PasswordVerificationResult passwordResult = 
                _passwordHasher.VerifyHashedPassword( storedUserAcc.AccountHolder.PasswordHash, password ) ; 

            if( passwordResult != PasswordVerificationResult.Success ) { 
                throw new InvalidUsernameOrPasswordException( usernameOrEmail, password )  ;  
            }
            */
            return storedUserAcc ;
        }

        public async Task<RegistrationResult> Register(   string email,  
                                            string username, 
                                            string password, 
                                            string confirmPassword)
        {
            if ( password != confirmPassword ) { return RegistrationResult.PasswordsDoNotMatch ; }

            Account emailAccount = await _accountService.GetByEmail( email ) ;
            if ( emailAccount != null ) { return RegistrationResult.EmailAlreadyExists ;  }

            Account userlAccount = await _accountService.GetByUserName( username );
            if ( userlAccount != null ) { return RegistrationResult.UsernameAlreadyExists; ; }

            IPasswordHasher hasher  = new PasswordHasher() ;
            string hashedPassword   = _passwordHasher.HashPassword( password ) ;

            User user = new User()
            {
                Email           = email,
                Username        = username,
                PasswordHash    = hashedPassword
            } ;

            Account account = new Account()
            {
                AccountHolder = user ,
            } ;

            try 
            {
                await _accountService.CreateAsync( account ) ;
                return RegistrationResult.Success ;
            } catch ( Exception e ) {
                Console.WriteLine( e.Message ) ;
                return RegistrationResult.Failed ;
            }
        }
    }
}
