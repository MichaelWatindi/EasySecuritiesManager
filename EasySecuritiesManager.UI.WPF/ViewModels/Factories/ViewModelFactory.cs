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
using EasySecuritiesManager.UI.WPF.State.Navigators;
using System;

namespace EasySecuritiesManager.UI.WPF.ViewModels.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel>         _createHomeViewModel ;
        private readonly CreateViewModel<PortfolioViewModel>    _createPortFolioViewModel ;
        private readonly CreateViewModel<BuyViewModel>          _createBuyViewModel ;
        private readonly CreateViewModel<LoginViewModel>        _createLoginViewModel ;

        public ViewModelFactory(    CreateViewModel<HomeViewModel>      createHomeViewModel, 
                                    CreateViewModel<PortfolioViewModel> createPortFolioViewModel, 
                                    CreateViewModel<BuyViewModel>       createBuyViewModel, 
                                    CreateViewModel<LoginViewModel>     createLoginViewModel )
        {
            _createHomeViewModel        = createHomeViewModel;
            _createPortFolioViewModel   = createPortFolioViewModel;
            _createBuyViewModel         = createBuyViewModel;
            _createLoginViewModel       = createLoginViewModel;
        }

        public ViewModelBase CreateViewModel( ViewType viewType )
        {
            switch ( viewType )
            {
                case ViewType.Home:
                    return _createHomeViewModel() ;

                case ViewType.Portfolio:
                    return _createPortFolioViewModel() ;

                case ViewType.Buy:
                    return _createBuyViewModel() ;

                case ViewType.Login:
                    return _createLoginViewModel() ;

                default:
                    throw new ArgumentException( "The ViewType does not have a ViewModel.", "viewType" );
            }
        }
    }
}
