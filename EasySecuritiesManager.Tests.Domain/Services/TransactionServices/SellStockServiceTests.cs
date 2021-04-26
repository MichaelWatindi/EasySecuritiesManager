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
 *  Created 4/25/2021 5:16:46 AM
 *  Modified 4/25/2021 5:16:46 AM
 */
using EasySecuritiesManager.Domain.Exceptions;
using EasySecuritiesManager.Domain.Models;
using EasySecuritiesManager.Domain.Services;
using EasySecuritiesManager.Domain.Services.TransactionServices;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasySecuritiesManager.Tests.Domain.Services.TransactionServices
{
    [TestFixture]
    public class SellStockServiceTests
    {
        private SellStockService            _sellStockService ;
        private Mock<IGetStockPriceService> _mockGetStockPriceService; 
        private Mock<IDataService<Account>> _mockAccountDataService; 

        [SetUp]
        public void SetUp()
        {
            _mockGetStockPriceService   = new Mock<IGetStockPriceService>() ;
            _mockAccountDataService     = new Mock<IDataService<Account>>() ;
            _sellStockService           = new SellStockService( _mockGetStockPriceService.Object, 
                                                                _mockAccountDataService.Object ) ;
        }

        [Test]
        public void SellStock_WithInssufficientShare_ThrowsInsufficientSharesException()
        {
            Account seller = CreateAccount( "T", 1 ) ;
            Assert.ThrowsAsync<InsufficientSharesException>(() => _sellStockService.SellStock( seller, "T", 3 )) ;
        }

        [Test]
        public void SellStock_WithInvalidSymbol_ThrowsInvalidSymbolExceptionForSymbol()
        {
            string expectedInvalidSymbol = "bad_symbol" ;
            Account seller = CreateAccount( expectedInvalidSymbol, 3 ) ;

            _mockGetStockPriceService.Setup( s => s.GetPrice( expectedInvalidSymbol )).ThrowsAsync( new InvalidSymbolException( expectedInvalidSymbol )) ;
            InvalidSymbolException exception = Assert.ThrowsAsync<InvalidSymbolException>( () => _sellStockService.SellStock( seller, expectedInvalidSymbol, 3 )) ;
            string actualInvalidSymbol = exception.Symbol ;

            Assert.AreEqual(expectedInvalidSymbol, actualInvalidSymbol) ;
        }

        [Test]
        public void SellStock_WithGetPriceFailure_ThrowException()
        {
            Account seller = CreateAccount( It.IsAny<string>(), 4 ) ;
            _mockGetStockPriceService.Setup( s => s.GetPrice( It.IsAny<string>())).ThrowsAsync( new Exception() ) ;

            Assert.ThrowsAsync<Exception>(() => _sellStockService.SellStock(seller, It.IsAny<string>(), 3 )) ;

        }

        [Test]
        public void SellStock_WithAccountUpdateFailure_ThrowsException()
        {
            Account seller = CreateAccount( It.IsAny<string>(), 4 );
            _mockAccountDataService.Setup( s => s.Update( It.IsAny<int>(), It.IsAny<Account>() )).ThrowsAsync( new Exception() ) ;

            Assert.ThrowsAsync<Exception>( () => _sellStockService.SellStock( seller, It.IsAny<string>(), 1 )) ;
        }
        
        [Test]
        public async Task SellStock_WithSuccessfullSell_ReturnAccountWithNewTransaction()
        {
            int expectedTransactionCount = 2 ;
            Account seller = CreateAccount( It.IsAny<string>(), 4 );
            seller = await _sellStockService.SellStock( seller, It.IsAny<string>(), 1 ) ;

            int actualTransactionCount = seller.AssetTransactions.Count ;
            Assert.AreEqual( expectedTransactionCount, actualTransactionCount ) ;
        }

        [Test]
        public async Task SellStock_WithSuccessfullSell_ReturnAccountWithNewBalance()
        {
            decimal expectedBalance = 100;
            Account seller = CreateAccount(It.IsAny<string>(), 4);
            _mockGetStockPriceService.Setup( s => s.GetPrice(It.IsAny<string>())).ReturnsAsync( 50 ) ;

            seller = await _sellStockService.SellStock( seller, It.IsAny<string>(), 2 ) ;
            decimal actualBalance = seller.Balance ;
            Assert.AreEqual( expectedBalance, actualBalance ) ;
        }

        private Account CreateAccount( string symbol, int shares )
        {
            return new Account()
            {
                AssetTransactions = new List<AssetTransaction>()
                {
                    new AssetTransaction()
                    {
                        TheAsset    = new Asset() { Symbol = symbol } ,
                        IsPurchase  = true,
                        Shares      = shares
                    }
                }
            };
        }
    }
}
