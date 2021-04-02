/**
 *  Tindi Systems Inc
 *  EasySecuritiesManager Domain
 *  See Copyright file at the top of the source tree.
 *
 *  This product includes software developed by the 
 *  Tindi Systems
 *
 *  @file AssetTransaction.cs
 *
 *  @brief
 *
 *  @author Michael Watindi
 *  See contact information in the license file at the top of the source tree.
 *
 *  Copyright (c) 2021 Tindi Systems Inc.
 *  All Rights Reserved.
 *  
 *  Created 4/2/2021 9:15:20 AM
 *  Modified 4/2/2021 9:15:20 AM
 */
using System;

namespace EasySecuritiesManager.Domain.Models
{
    public class AssetTransaction : DomainObject
    {
        public Account  TheAccount      { get; set; }
        public bool     IsPurchase      { get; set; }
        public Asset    TheAsset        { get; set; }
        public int      Shares          { get; set; }
        public DateTime DateProcessed   { get; set; }
    }
}
