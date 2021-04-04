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

using System.Threading.Tasks;

namespace EasySecuritiesManager.Domain.Services
{
    public interface IGetStockPriceService
    {
        Task<decimal> GetPrice( string symbol ) ;
    }
}