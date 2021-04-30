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
 *  Created 4/28/2021 6:33:07 PM
 *  Modified 4/28/2021 6:33:07 PM
 */
using System;

namespace EasySecuritiesManager.FinancialModelingPrepApi.Models
{
    public class FinancialModelingPrepApiKey 
    {
        public string Key { get ; }

        public FinancialModelingPrepApiKey( string key ) => Key = key;
        
    }
}
