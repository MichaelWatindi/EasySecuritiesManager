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
 *  Created 4/5/2021 6:13:33 PM
 *  Modified 4/5/2021 6:13:33 PM
 */
using EasySecuritiesManager.Domain.Exceptions;
using EasySecuritiesManager.Domain.Models;
using System;
using System.Threading.Tasks;

namespace EasySecuritiesManager.Domain.Services.TransactionServices
{
    public class BuyStockService : IBuyStockService
    {
        private readonly IGetStockPriceService _getStockPriceService ;
        private readonly IDataService<Account> _accountService ;

        public BuyStockService( IGetStockPriceService stockPriceService, IDataService<Account> dataService )
        {
            _getStockPriceService  = stockPriceService;
            _accountService        = dataService;
        }

        public async Task<Account> BuyStock( Account buyer, string symbol, int sharesToBuy )
        {
            //  We get the price of the stock
            decimal stockPrice          = await _getStockPriceService.GetPrice( symbol ) ;
            decimal transactionPrice    = stockPrice * sharesToBuy ;

            //  Make sure the transaction is valid.
            if ( transactionPrice > buyer.Balance )  {
                throw new InsufficientFundsException( buyer.Balance, transactionPrice ) ;
            }

            //  We create the transaction
            AssetTransaction transaction = new AssetTransaction()
            {
                TheAccount  = buyer ,
                TheAsset    = new Asset()
                {
                    PricePerShare   = stockPrice ,
                    Symbol          = symbol
                } ,
                DateProcessed   = DateTime.Now,
                Shares          = sharesToBuy ,
                IsPurchase      = true                 
            } ;

            buyer.AssetTransactions.Add( transaction ) ;
            buyer.Balance -= stockPrice * sharesToBuy ;
            await _accountService.Update( buyer.Id , buyer ) ;

            return buyer ;
        }
    }
}
