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
 *  Created 4/5/2021 6:04:01 PM
 *  Modified 4/5/2021 6:04:01 PM
 */

using EasySecuritiesManager.Domain.Models;
using System.Threading.Tasks;

namespace EasySecuritiesManager.Domain.Services.TransactionServices
{
    public interface IBuyStockService
    {
        Task<Account> BuyStock( Account buyer, string stock, int shares ) ; 
    }
}