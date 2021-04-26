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
 *  Created 4/25/2021 4:13:00 AM
 *  Modified 4/25/2021 4:13:00 AM
 */
using EasySecuritiesManager.Domain.Exceptions;
using EasySecuritiesManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasySecuritiesManager.Domain.Services.TransactionServices
{
    public class SellStockService : ISellStockService
    {
        private readonly IGetStockPriceService _getStockPriceService ;
        private readonly IDataService<Account> _dataService ;

        public SellStockService( IGetStockPriceService getStockPriceService, 
                                 IDataService<Account> dataService)
        {
            _getStockPriceService = getStockPriceService;
            _dataService = dataService;
        }

        public async Task<Account> SellStock(   Account seller , 
                                                string  symbol , 
                                                int     shares )
        {
            //  Validate Seller has Enough shares
            int accountShares = GetAccountSharesForSymbol( seller, symbol ) ;
            if( accountShares < shares ) { throw new InsufficientSharesException( symbol, accountShares, shares ) ; }

            decimal stockPrice = await _getStockPriceService.GetPrice( symbol ) ;

            seller.AssetTransactions.Add( new AssetTransaction()
            {
                TheAccount      = seller,
                TheAsset        = new Asset() 
                { 
                    PricePerShare   = stockPrice,
                    Symbol          = symbol,
                },
                DateProcessed   = DateTime.Now,
                IsPurchase      = false,
                Shares          = shares
            });

            seller.Balance += stockPrice * shares ;
            await _dataService.Update( seller.Id, seller ) ;

            return seller ;
        }

        private int GetAccountSharesForSymbol(Account seller, string symbol)
        {
            IEnumerable<AssetTransaction> accountTransactionsForSymbol = 
                seller.AssetTransactions.Where( a => a.TheAsset.Symbol == symbol ) ;

            return accountTransactionsForSymbol.Sum( a => a.IsPurchase ? a.Shares : -a.Shares ) ;
        }
    }
}
