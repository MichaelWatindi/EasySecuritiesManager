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
 *  Created 4/8/2021 5:31:38 AM
 *  Modified 4/8/2021 5:31:38 AM
 */
using EasySecuritiesManager.Domain.Services;
using System;

namespace EasySecuritiesManager.UI.WPF.ViewModels.Factories
{
    public class MajorIndexListingViewModelFactory : IEasySecuritiesManagerViewModelFactory<MajorIndexListingViewModel>
    {
        private readonly IMajorIndexService _majorIndexService ;

        public MajorIndexListingViewModelFactory( IMajorIndexService majorIndexService )
        {
            _majorIndexService = majorIndexService ;
        }

        public MajorIndexListingViewModel CreateViewModel()
        {
            return MajorIndexListingViewModel.LoadMajorIndexViewModel( _majorIndexService ) ;
        }
    }
}
