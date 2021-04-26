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
 *  Created 4/25/2021 3:01:01 AM
 *  Modified 4/25/2021 3:01:01 AM
 */

using EasySecuritiesManager.Domain.Models;
using System;
using System.Threading.Tasks;

namespace EasySecuritiesManager.Domain.Services.TransactionServices
{
    public interface ISellStockService
    {
        Task<Account> SellStock(    Account seller, 
                                            string  symbol, 
                                            int     shares ) ;
    }
}