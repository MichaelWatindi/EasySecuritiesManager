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
 *  Created 4/9/2021 7:14:05 PM
 *  Modified 4/9/2021 7:14:05 PM
 */

using EasySecuritiesManager.Domain.Models;
using System;
using System.Threading.Tasks;

namespace EasySecuritiesManager.Domain.Services
{
    public interface IAccountService : IDataService<Account>
    {
        Task<Account> GetByUserName( string username ) ;
        Task<Account> GetByEmail( string email ) ;
    }
}