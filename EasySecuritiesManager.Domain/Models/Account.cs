/**
 *  Tindi Systems Inc
 *  EasySecuritiesManager Domain
 *  See Copyright file at the top of the source tree.
 *
 *  This product includes software developed by the 
 *  Tindi Systems
 *
 *  @file Account.cs
 *
 *  @brief
 *
 *  @author Michael Watindi
 *  See contact information in the license file at the top of the source tree.
 *
 *  Copyright (c) 2021 Tindi Systems Inc.
 *  All Rights Reserved.
 *  
 *  Created 4/1/2021 5:02:19 AM
 *  Modified 4/1/2021 5:02:19 AM
 */
using System.Collections.Generic;

namespace EasySecuritiesManager.Domain.Models
{
    public class Account : DomainObject
    {
        public User                             AccountHolder       { get; set; }
        public decimal                          Balance             { get; set; }
        public ICollection<AssetTransaction>    AssetTransactions   { get; set; }        
    }
}
