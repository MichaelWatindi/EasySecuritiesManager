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
 *  Created 4/12/2021 1:56:46 AM
 *  Modified 4/12/2021 1:56:46 AM
 */
using EasySecuritiesManager.UI.WPF.ViewModels;
using EasySecuritiesManager.UI.WPF.ViewModels.Factories;
using System;

namespace EasySecuritiesManager.UI.WPF.State.Navigators
{
    
    public class ViewModelFactoryRenavigator<TViewModel> : IRenavigator where TViewModel : ViewModelBase
    {
        private readonly INavigator _navigator ;
        private readonly IEasySecuritiesManagerViewModelFactory<TViewModel> _viemModelFactory ;

        public ViewModelFactoryRenavigator(INavigator           navigator, 
            IEasySecuritiesManagerViewModelFactory<TViewModel>  viemModelFactory)
        {
            _navigator          = navigator;
            _viemModelFactory   = viemModelFactory;
        }

        public void Renavigate()
        {
            _navigator.CurrentViewModel = _viemModelFactory.CreateViewModel() ;
        }
    }
}
