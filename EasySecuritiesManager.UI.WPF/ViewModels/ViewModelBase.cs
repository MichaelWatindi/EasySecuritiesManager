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
 *  Created 4/2/2021 4:32:34 PM
 *  Modified 4/2/2021 4:32:34 PM
 */
using EasySecuritiesManager.UI.WPF.Models;

namespace EasySecuritiesManager.UI.WPF.ViewModels
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase ;

    public class ViewModelBase : ObservableObject
    {
        public MessageViewModel ErrorMessageViewModel   { get; }
        public MessageViewModel StatusMessageViewModel  { get; }
    }
}
