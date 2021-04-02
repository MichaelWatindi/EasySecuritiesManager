/**
 *  Tindi Systems Inc
 *  EasySecuritiesManager Domain
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
 *  Created 4/1/2021 5:05:30 AM
 *  Modified 4/1/2021 5:05:30 AM
 */
using System;

namespace EasySecuritiesManager.Domain.Models
{
    public class Asset
    {        
        public string   Symbol          { get; set; }
        public decimal  PricePerShare   { get; set; }
        public string   Name            { get; set; }
        public decimal  DayLow          { get; set; }
        public decimal  DayHigh         { get; set; }
        public decimal  YearHigh        { get; set; }
        public decimal  YearLow         { get; set; }
        public decimal  MarketCap       { get; set; }
        public DateTime TimeOfFetch     { get; set; }

    }
}
