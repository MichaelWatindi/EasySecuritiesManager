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
 *  Created 4/9/2021 9:02:01 PM
 *  Modified 4/9/2021 9:02:01 PM
 */

using EasySecuritiesManager.Domain.Models;
using EasySecuritiesManager.Domain.Services;
using EasySecuritiesManager.Domain.Services.AuthenticationServices;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework ;
using System;
using System.Threading.Tasks;

namespace EasySecuritiesManager.Tests.Domain.Services.AuthenticationServices
{
    [TestFixture]
    public class AuthenticationServiceTest
    {
        [SetUp]
        public void Setup()
        {

        }
        // function name, scenario, with parameter should return
        [Test]
        public async Task Login_WithCorrectPasswordForExistingUser_ReturnAccountForCorrectUsername()
        {
            // Arrange , act assert
            string expectedUsername = "testUser" ;
            string password         = "testPassword" ;
            Mock<IAccountService> mockAccountService = new Mock<IAccountService>() ;
            mockAccountService.Setup( s => s.GetByUserName( expectedUsername )).ReturnsAsync( new Account() { AccountHolder = new User() { Username = expectedUsername }}) ;

            Mock<IPasswordHasher> mockPasswordHasher = new Mock<IPasswordHasher>() ;
            mockPasswordHasher.Setup( s => s.VerifyHashedPassword( It.IsAny<string>(), password )).Returns( PasswordVerificationResult.Success );

            AuthenticationService authService = new AuthenticationService( mockAccountService.Object, mockPasswordHasher.Object ) ;
            Account account = await authService.Login( expectedUsername, password ) ;

            string actualUsername = account.AccountHolder.Username ;
            Assert.AreEqual( expectedUsername, actualUsername ) ;
        }

        [Test]
        public async Task Login_WithIncorrectPasswordForExistingUser_ThrowsInvalidPasswordException()
        {
            // Arrange , act assert
            string expectedUsername = "testUser";
            string password = "testPassword";
            Mock<IAccountService> mockAccountService = new Mock<IAccountService>();
            mockAccountService.Setup(s => s.GetByUserName(expectedUsername)).ReturnsAsync(new Account() { AccountHolder = new User() { Username = expectedUsername } });

            Mock<IPasswordHasher> mockPasswordHasher = new Mock<IPasswordHasher>();
            mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Success);

            AuthenticationService authService = new AuthenticationService(mockAccountService.Object, mockPasswordHasher.Object);
            Account account = await authService.Login(expectedUsername, password);

            string actualUsername = account.AccountHolder.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        [Test]
        public async Task Login_WithCorrectPasswordForExistingUser_ReturnAccountForCorrectUsername2()
        {
            // Arrange , act assert
            string expectedUsername = "testUser";
            string password = "testPassword";
            Mock<IAccountService> mockAccountService = new Mock<IAccountService>();
            mockAccountService.Setup(s => s.GetByUserName(expectedUsername)).ReturnsAsync(new Account() { AccountHolder = new User() { Username = expectedUsername } });

            Mock<IPasswordHasher> mockPasswordHasher = new Mock<IPasswordHasher>();
            mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Success);

            AuthenticationService authService = new AuthenticationService(mockAccountService.Object, mockPasswordHasher.Object);
            Account account = await authService.Login(expectedUsername, password);

            string actualUsername = account.AccountHolder.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        [Test]
        public async Task Login_WithCorrectPasswordForExistingUser_ReturnAccountForCorrectUsername3()
        {
            // Arrange , act assert
            string expectedUsername = "testUser";
            string password = "testPassword";
            Mock<IAccountService> mockAccountService = new Mock<IAccountService>();
            mockAccountService.Setup(s => s.GetByUserName(expectedUsername)).ReturnsAsync(new Account() { AccountHolder = new User() { Username = expectedUsername } });

            Mock<IPasswordHasher> mockPasswordHasher = new Mock<IPasswordHasher>();
            mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Success);

            AuthenticationService authService = new AuthenticationService(mockAccountService.Object, mockPasswordHasher.Object);
            Account account = await authService.Login(expectedUsername, password);

            string actualUsername = account.AccountHolder.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        [Test]
        public async Task Login_WithCorrectPasswordForExistingUser_ReturnAccountForCorrectUsername4()
        {
            // Arrange , act assert
            string expectedUsername = "testUser";
            string password = "testPassword";
            Mock<IAccountService> mockAccountService = new Mock<IAccountService>();
            mockAccountService.Setup(s => s.GetByUserName(expectedUsername)).ReturnsAsync(new Account() { AccountHolder = new User() { Username = expectedUsername } });

            Mock<IPasswordHasher> mockPasswordHasher = new Mock<IPasswordHasher>();
            mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Success);

            AuthenticationService authService = new AuthenticationService(mockAccountService.Object, mockPasswordHasher.Object);
            Account account = await authService.Login(expectedUsername, password);

            string actualUsername = account.AccountHolder.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }

    }
}
