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
 *  Created 4/11/2021 7:54:37 AM
 *  Modified 4/11/2021 7:54:37 AM
 */
using EasySecuritiesManager.UI.WPF.State.Authenticators;
using EasySecuritiesManager.UI.WPF.State.Navigators;

namespace EasySecuritiesManager.UI.WPF.ViewModels.Factories
{
    public class LoginViewModelFactory : IEasySecuritiesManagerViewModelFactory<LoginViewModel>
    {
        private readonly IAuthenticator _authenticator ;
        private readonly IRenavigator   _renavigator;

        public LoginViewModelFactory(   IAuthenticator  authenticator, 
                                        IRenavigator    renavigator )
        {
            _authenticator  = authenticator;
            _renavigator    = renavigator;
        }

        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel( _authenticator, _renavigator ) ;
        }
    }
}
