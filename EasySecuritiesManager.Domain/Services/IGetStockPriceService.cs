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
 *  Created 4/3/2021 11:12:39 PM
 *  Modified 4/3/2021 11:12:39 PM
 */

using System.Threading.Tasks ;
using EasySecuritiesManager.Domain.Exceptions ;

namespace EasySecuritiesManager.Domain.Services
{
    public interface IGetStockPriceService
    {
        /// <summary>
        /// Get the share price for a stock
        /// </summary>
        /// <param name="symbol">The symbol of the stock we want to buy</param>
        /// <returns>The current price of the stock.</returns>
        /// <exception cref="InvalidSymbolException">Thrown if the symbol does not exist.</exception>
        /// <exception cref="Exception">Thrown if getting the symbol fails.</exception>
        Task<decimal> GetPrice( string symbol );
    }
}