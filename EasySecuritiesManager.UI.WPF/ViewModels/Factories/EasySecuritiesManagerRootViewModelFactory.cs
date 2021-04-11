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
 *  Created 4/8/2021 5:16:40 AM
 *  Modified 4/8/2021 5:16:40 AM
 */
using EasySecuritiesManager.FinancialModelingPrepApi.Services;
using EasySecuritiesManager.UI.WPF.State.Navigators;
using System;

namespace EasySecuritiesManager.UI.WPF.ViewModels.Factories
{
    public class EasySecuritiesManagerRootViewModelFactory : IEasySecuritiesRootManagerViewModelFactory
    {
        private readonly IEasySecuritiesManagerViewModelFactory<HomeViewModel>      _homeViewModelFactory ;
        private readonly IEasySecuritiesManagerViewModelFactory<PortfolioViewModel> _portFolioViewModelFactory ;
        private readonly BuyViewModel                                               _buyViewModel;
        private readonly IEasySecuritiesManagerViewModelFactory<LoginViewModel>     _loginViewModelFactory;

        public EasySecuritiesManagerRootViewModelFactory(   IEasySecuritiesManagerViewModelFactory<HomeViewModel>       homeViewModelFactory ,
                                                            IEasySecuritiesManagerViewModelFactory<PortfolioViewModel>  portFolioViewModelFactory ,
                                                            BuyViewModel                                                buyViewModel , 
                                                            IEasySecuritiesManagerViewModelFactory<LoginViewModel>      loginViewModel )
        {
            _homeViewModelFactory       = homeViewModelFactory ;
            _portFolioViewModelFactory  = portFolioViewModelFactory ;
            _buyViewModel               = buyViewModel ;
            _loginViewModelFactory      = loginViewModel ;
        }

        public ViewModelBase CreateViewModel( ViewType viewType )
        {
            switch ( viewType )
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel() ;
                    
                case ViewType.Portfolio:
                    return _portFolioViewModelFactory.CreateViewModel() ;

                case ViewType.Buy:
                    return _buyViewModel ;

                case ViewType.Login:
                    return _loginViewModelFactory.CreateViewModel() ;

                default:
                    throw new ArgumentException( "The ViewType does not have a ViewModel.", "viewType" );
            }
        }
    }
}
