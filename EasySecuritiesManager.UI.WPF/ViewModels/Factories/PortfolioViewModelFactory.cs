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
 *  Created 4/8/2021 4:31:50 PM
 *  Modified 4/8/2021 4:31:50 PM
 */
namespace EasySecuritiesManager.UI.WPF.ViewModels.Factories
{
    public class PortfolioViewModelFactory : IEasySecuritiesManagerViewModelFactory<PortfolioViewModel>
    {
        public PortfolioViewModel CreateViewModel()
        {
            return new PortfolioViewModel() ;
        }
    }
}
