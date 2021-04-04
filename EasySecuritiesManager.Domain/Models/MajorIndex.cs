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
 *  Created 4/3/2021 10:55:05 AM
 *  Modified 4/3/2021 10:55:05 AM
 */
using System;

namespace EasySecuritiesManager.Domain.Models
{
    public enum MajorIndexType
    {
        DowJones,
        NasDaq,
        SP500
    }
    public class MajorIndex
    {
        public string           Name                { get; set; }
        public decimal          Price               { get; set; }
        public double           Change              { get; set; }
        public MajorIndexType   Type                { get; set; }
        public double           DayLow              { get; set; }
        public double           DayHigh             { get; set; }
        public double           ChangesPercentage   { get; set; }
        public decimal          YearHigh            { get; set; }
        public decimal          YearLow             { get; set; }

    }
}
