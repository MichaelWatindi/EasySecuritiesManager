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
using EasySecuritiesManager.Domain.Exceptions;
using System;
using System.Threading.Tasks;

namespace EasySecuritiesManager.Domain.Services.TransactionServices
{
    public interface IBuyStockService
    {
        /// <summary>
        /// Purchase a stock for an account
        /// </summary>
        /// <param name="buyer"></param>
        /// <param name="stock"></param>
        /// <param name="shares"></param>
        /// <returns>The updated account</returns>
        /// <exception cref="InsufficientFundsException">Thrown if the account has insufficient funds to make the purchase</exception>
        /// <exception cref="InvalidSymbolException">Thrown if the account has insufficient funds to make the purchase</exception>
        /// <exception cref="Exception">Thrown if the account has insufficient funds to make the purchase</exception>
        Task<Account> BuyStock( Account buyer, string stock, int shares ) ; 
    }
}