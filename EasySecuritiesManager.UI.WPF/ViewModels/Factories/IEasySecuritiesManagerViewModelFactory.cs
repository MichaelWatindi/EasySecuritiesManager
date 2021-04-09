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
 *  Created 4/8/2021 5:23:08 AM
 *  Modified 4/8/2021 5:23:08 AM
 */
using System;

namespace EasySecuritiesManager.UI.WPF.ViewModels.Factories
{
    public interface IEasySecuritiesManagerViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel() ;
    }
}