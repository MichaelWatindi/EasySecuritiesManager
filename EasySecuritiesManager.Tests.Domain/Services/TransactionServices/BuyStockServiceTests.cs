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
 *  Created 4/25/2021 5:16:32 AM
 *  Modified 4/25/2021 5:16:32 AM
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
    public class BuyStockServiceTests
    {
        private BuyStockService             _buyStockService ;
        private Mock<IGetStockPriceService> _mockGetStockPriceService ;
        private Mock<IDataService<Account>> _mockAccountDataService ;

        [SetUp]
        public void SetUp()
        {
            _mockGetStockPriceService   = new Mock<IGetStockPriceService>() ;
            _mockAccountDataService     = new Mock<IDataService<Account>>() ;
            _buyStockService            = new BuyStockService(  _mockGetStockPriceService.Object, 
                                                                _mockAccountDataService.Object ) ;
        }

        [Test]
        public void BuyStock_WithInvalidSymbol_ThrowsInvalidSymbolExceptionForSymbol()
        {
            string expectedInvalidSymbol = "bad_symbol" ;
            _mockGetStockPriceService.Setup( s => s.GetPrice( expectedInvalidSymbol)).ThrowsAsync( new InvalidSymbolException( expectedInvalidSymbol )) ;

            Assert.ThrowsAsync<InvalidSymbolException>( () => _buyStockService.BuyStock( It.IsAny<Account>(), expectedInvalidSymbol, It.IsAny<int>())) ;
        }

        [Test]
        public void BuyStock_WithGetPriceFailure_ThrowsException()
        {
            _mockGetStockPriceService.Setup( s => s.GetPrice(It.IsAny<string>())).ThrowsAsync( new Exception() ) ;

            Assert.ThrowsAsync<Exception>( () => _buyStockService.BuyStock( It.IsAny<Account>(), It.IsAny<string>(), It.IsAny<int>() )) ;
        }

        [Test]
        public void BuyStock_WithInsufficientFunds_ThrowsInsufficientFundsExceptionForBalance()
        {
            decimal expectedAccountBalance   = 0 ;
            double  expectedRequiredBalance  = 100 ;
            Account buyer                    = CreateAccount( expectedAccountBalance ) ;

            _mockGetStockPriceService.Setup( s => s.GetPrice(It.IsAny<string>()) ).ThrowsAsync( new Exception() ) ;

            Assert.ThrowsAsync<Exception>( () => _buyStockService.BuyStock( It.IsAny<Account>(), It.IsAny<string>(), It.IsAny<int>() )) ;
        }

        [Test]
        public void BuyStock_WithAccountUpdateFailure_ThrowsException()
        {
            Account buyer = CreateAccount( 1000 ) ;
            
            _mockGetStockPriceService.Setup( s => s.GetPrice( It.IsAny<string>() )).ReturnsAsync( 100 ) ;
            _mockAccountDataService.Setup( s => s.Update( It.IsAny<int>(), It.IsAny<Account>() )).Throws( new Exception() ) ;

            Assert.ThrowsAsync<Exception>( () => _buyStockService.BuyStock( buyer, It.IsAny<string>(), 1 )) ;
        }

        [Test]
        public async Task BuyStock_WithSuccessfulPurchase_ReturnsAccountWithNewTransaction()
        {
            int expectedTransactionCount    = 1 ;
            Account buyer                   = CreateAccount( 1000 ) ;
            _mockGetStockPriceService.Setup( s => s.GetPrice( It.IsAny<string>())).ReturnsAsync( 100 ) ;

            buyer = await _buyStockService.BuyStock( buyer, It.IsAny<string>(), 1 ) ;
            int actuatTransactionCount = buyer.AssetTransactions.Count ;

            Assert.AreEqual( expectedTransactionCount, actuatTransactionCount ) ;
        }

        [Test]
        public async Task BuyStock_WithSuccessfulPurchase_ReturnsAccountWithNewBalance()
        {
            decimal expectedBalance = 0 ;
            Account buyer           = CreateAccount( 100 ) ;
            _mockGetStockPriceService.Setup( s => s.GetPrice( It.IsAny<string>()) ).ReturnsAsync( 50 ) ;

            buyer                   = await _buyStockService.BuyStock( buyer, It.IsAny<string>(), 2 ) ;
            decimal actualBalance   = buyer.Balance ;

            Assert.AreEqual( expectedBalance, actualBalance ) ;
        }

        private Account CreateAccount( decimal balance )
        {
            return new Account()
            {
                Balance = balance ,
                AssetTransactions = new List<AssetTransaction>() 
            } ;
        }
    }
}
