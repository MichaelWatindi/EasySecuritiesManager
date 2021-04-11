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

using EasySecuritiesManager.Domain.Exceptions;
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
        private Mock<IAccountService> _mockAccountService ;
        private Mock<IPasswordHasher> _mockPasswordHasher ;
        private AuthenticationService _authenticationService ;
        
        [SetUp]
        public void Setup()
        {
            _mockAccountService     = new Mock<IAccountService>() ;
            _mockPasswordHasher     = new Mock<IPasswordHasher>() ;
            _authenticationService  = new AuthenticationService( _mockAccountService.Object, _mockPasswordHasher.Object ) ;
        }

        // function name, scenario, with parameter should return
        [Test]
        public async Task Login_WithCorrectPasswordForExistingUser_ReturnAccountForCorrectUsername()
        {
            // Arrange , act assert
            string expectedUsername = "testUser" ;
            string password         = "testPassword" ;

            _mockAccountService.Setup( s => s.GetByUserName( expectedUsername )).ReturnsAsync( new Account() { AccountHolder = new User() { Username = expectedUsername }}) ;
            _mockPasswordHasher.Setup( s => s.VerifyHashedPassword( It.IsAny<string>(), password )).Returns( PasswordVerificationResult.Success );

            Account account = await _authenticationService.Login( expectedUsername, password ) ;

            string actualUsername = account.AccountHolder.Username ;
            Assert.AreEqual( expectedUsername, actualUsername ) ;
        }

        [Test]
        public void Login_WithIncorrectPasswordForExistingUser_ThrowsInvalidPasswordException()
        {
            // Arrange , act assert
            string expectedUsername = "testUser" ;
            string password         = "testPassword" ;

            _mockAccountService.Setup( s => s.GetByUserName( expectedUsername )).ReturnsAsync( new Account() { AccountHolder = new User() { Username = expectedUsername }}) ;
            _mockPasswordHasher.Setup( s => s.VerifyHashedPassword( It.IsAny<string>(), password )).Returns( PasswordVerificationResult.Failed ) ;

            //  Act & Assert
            InvalidUsernameOrPasswordException invalidPassUsernameException = 
                Assert.ThrowsAsync<InvalidUsernameOrPasswordException>( () => _authenticationService.Login( expectedUsername, password )) ;

            string actualUsername = invalidPassUsernameException.Username ;
            Assert.AreEqual( expectedUsername, actualUsername ) ;
        }

        [Test]
        public void Login_WithNonExistentUsername_ThrowsInvalidUsernameOrPasswordException()
        {
            // Arrange , act assert
            string expectedUsername = "testUser" ;
            string password         = "testPassword" ;

            _mockPasswordHasher.Setup( s => s.VerifyHashedPassword( It.IsAny<string>(), password )).Returns( PasswordVerificationResult.Failed ) ;

            //  Act & Assert
            UserNotFoundException userNotFoundException = 
                Assert.ThrowsAsync<UserNotFoundException>( () => _authenticationService.Login( expectedUsername, password )) ;

            string actualUsername = userNotFoundException.Username ;
            Assert.AreEqual( expectedUsername, actualUsername ) ;
        }
        
        [Test]
        public async Task Register_WithPasswordsNotMatching_ReturnsPasswordsDoNotMatchResultEnum()
        {
            
            string password         = "testPassword" ;
            string confirmPassword  = "confirmPassword" ;

            RegistrationResult actual           = await _authenticationService.Register( It.IsAny<string>(), It.IsAny<string>(), password, confirmPassword ) ;
            RegistrationResult excpectedResult  = RegistrationResult.PasswordsDoNotMatch ;

            Assert.AreEqual( excpectedResult, actual ) ;
        }

        [Test]
        public async Task Register_WithAlreadyExistingEmail_ReturnsEmailAlreadyExistsResultEnum()
        {
            string email = "test@gmail.com" ;
            _mockAccountService.Setup( s => s.GetByEmail( email )).ReturnsAsync( new Account());
            RegistrationResult actual           = await _authenticationService.Register( email, It.IsAny<string>(), "test", "test" );
            RegistrationResult excpectedResult  = RegistrationResult.EmailAlreadyExists ;

            Assert.AreEqual( excpectedResult, actual ) ;
        }

        [Test]
        public async Task Register_WithAlreadyExistingUsername_ReturnsUsernameAlreadyExistsResultEnum()
        {
           string username = "test" ;
            _mockAccountService.Setup( s => s.GetByUserName( username )).ReturnsAsync( new Account() );
            RegistrationResult actual           = await _authenticationService.Register( It.IsAny<string>(), username,  "test", "test" );
            RegistrationResult excpectedResult  = RegistrationResult.UsernameAlreadyExists ;

            Assert.AreEqual( excpectedResult, actual ) ;
        }

        [Test]
        public async Task Register_WithNewUserValidCredentials_ReturnsSuccessResultEnum()
        {
            RegistrationResult actual           = await _authenticationService.Register( It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>() );
            RegistrationResult excpectedResult  = RegistrationResult.Success ;

            Assert.AreEqual( excpectedResult, actual );
        }
    }
}
