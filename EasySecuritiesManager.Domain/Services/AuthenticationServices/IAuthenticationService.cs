/**
 *  Tindi Systems Inc
 *  $specifiedsolutionname$ $projectname$
 *  See Copyright file at the top of the source tree.
 *
 *  This product includes software developed by the 
 *  Tindi Systems
 *
 *  @file $filename
 *
 *  @brief
 *
 *  @author Michael Watindi
 *  See contact information in the license file at the top of the source tree.
 *
 *  Copyright (c) 2021 Tindi Systems Inc.
 *  All Rights Reserved.
 *  
 *  Created 4/9/2021 6:27:27 PM
 *  Modified 4/9/2021 6:27:27 PM
 */

using EasySecuritiesManager.Domain.Models;
using System;
using System.Threading.Tasks;

namespace EasySecuritiesManager.Domain.Services.AuthenticationServices
{
    public enum RegistrationResult  {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists,
        InvalidPassword,
        InvalidUsername,
        InvalidEmail,
        Failed                  // UnknownReason
    }

    public interface IAuthenticationService
    {
        Task<RegistrationResult> Register(  string email, 
                                            string username, 
                                            string password, 
                                            string confirmPassword ) ;
        Task<Account> Login( string username, string password ) ;
    }
}