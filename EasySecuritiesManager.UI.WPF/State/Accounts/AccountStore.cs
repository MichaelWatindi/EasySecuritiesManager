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
 *  Created 4/12/2021 4:44:19 AM
 *  Modified 4/12/2021 4:44:19 AM
 */
using EasySecuritiesManager.Domain.Models;
using System;

namespace EasySecuritiesManager.UI.WPF.State.Accounts
{
    public class AccountStore : IAccountStore
    {     
        private Account _currentAccount;
        public  Account CurrentAccount
        {
            get { return _currentAccount; }
            set { 
                _currentAccount = value ;
                StateChanged?.Invoke() ;
            }
        }

        public event Action StateChanged ;
    }
}
