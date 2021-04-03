/**
 *  Tindi Systems Inc
 *  $specifiedsolutionname$ $projectname$
 *  See Copyright file at the top of the source tree.
 *
 *  This product includes software developed by the 
 *  Tindi Systems
 *
 *  @file $filename
 *
 *  @brief
 *
 *  @author Michael Watindi
 *  See contact information in the license file at the top of the source tree.
 *
 *  Copyright (c) 2021 Tindi Systems Inc.
 *  All Rights Reserved.
 *  
 *  Created 4/2/2021 7:28:25 PM
 *  Modified 4/2/2021 7:28:25 PM
 */

using EasySecuritiesManager.UI.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace EasySecuritiesManager.UI.WPF.State.Navigators
{
    public enum ViewType
    {
        Home,
        Portfolio
    }
    public interface INavigator
    {
        ViewModelBase   CurrentViewModel        { get ; set ; }
        ICommand        UpdateCurrentViewModelCommand  { get ; }
    }
}