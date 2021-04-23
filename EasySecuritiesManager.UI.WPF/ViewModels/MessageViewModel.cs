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
 *  Created 4/21/2021 4:12:01 AM
 *  Modified 4/21/2021 4:12:01 AM
 */
using EasySecuritiesManager.UI.WPF.Models;
using System;

namespace EasySecuritiesManager.UI.WPF.ViewModels
{
    public class MessageViewModel : ObservableObject
    {
        private string _message ;

        public string Message
        {
            get => _message;
            set {
                _message = value;
                OnPropertyChanged( nameof( Message ));
                OnPropertyChanged( nameof( HasMessage ));
            }
        }

        public bool HasMessage => !string.IsNullOrEmpty( Message );
    }
}
