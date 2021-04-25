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
 *  Created 4/2/2021 7:52:49 PM
 *  Modified 4/2/2021 7:52:49 PM
 */
using EasySecuritiesManager.UI.WPF.State.Assets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EasySecuritiesManager.UI.WPF.ViewModels
{
    public class PortfolioViewModel : ViewModelBase
    {
        public AssetListingViewModel pAssetListingViewModel { get ;  }

        public PortfolioViewModel( AssetStore assetStore )
        {
            pAssetListingViewModel = new AssetListingViewModel( assetStore ) ;
        }
    }
}
