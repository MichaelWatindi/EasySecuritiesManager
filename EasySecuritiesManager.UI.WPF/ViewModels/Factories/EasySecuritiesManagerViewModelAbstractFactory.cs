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
    public class EasySecuritiesManagerViewModelAbstractFactory : IEasySecuritiesManagerViewModelAbstractFactory
    {
        private readonly IEasySecuritiesManagerViewModelFactory<HomeViewModel> _homeViewModelFactory ;

        public EasySecuritiesManagerViewModelAbstractFactory( IEasySecuritiesManagerViewModelFactory<HomeViewModel> homeViewModelFactory )
        {
            _homeViewModelFactory = homeViewModelFactory;
        }

        public ViewModelBase CreateViewModel( ViewType viewType )
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return new HomeViewModel( MajorIndexListingViewModel.LoadMajorIndexViewModel( new MajorIndexService() )) ;
                    
                case ViewType.Portfolio:
                    return new PortfolioViewModel() ;
                default:
                    throw new ArgumentException( "The ViewType does not have a ViewModel.", "viewType" );
            }
        }
    }
}
