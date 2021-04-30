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
 *  Created 4/2/2021 7:30:39 PM
 *  Modified 4/2/2021 7:30:39 PM
 */

using EasySecuritiesManager.UI.WPF.ViewModels;
using System;

namespace EasySecuritiesManager.UI.WPF.State.Navigators
{
    public class Navigator :  INavigator
    {
        private ViewModelBase   _currentViewModel ;
        
        public ViewModelBase    CurrentViewModel  
        { 
            get  => _currentViewModel ; 
            set {
                _currentViewModel?.Dispose() ;
                _currentViewModel = value ;
                StateChanged?.Invoke() ;
            }
        }

        public event Action StateChanged ;
    }
}
