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
 *  Created 4/11/2021 7:14:33 AM
 *  Modified 4/11/2021 7:14:33 AM
 */

using EasySecuritiesManager.Domain.Models;
using EasySecuritiesManager.Domain.Services.AuthenticationServices;
using System;
using System.Threading.Tasks;

namespace EasySecuritiesManager.UI.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        Account CurrentUser { get ; }
        bool    IsLoggedIn { get ; }

        Task<RegistrationResult> Register( string email, string username, string passwork, string confirmPassword ) ;
        Task<bool> Login (string username, string password ) ;
        void Logout() ;
    }
}