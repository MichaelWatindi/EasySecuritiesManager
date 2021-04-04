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
 *  Created 4/4/2021 2:59:20 AM
 *  Modified 4/4/2021 2:59:20 AM
 */
using System;
using System.Runtime.Serialization;

namespace EasySecuritiesManager.Domain.Exceptions
{
    public class InvalidSymbolException : Exception
    {
        public string Symbol { get; set; }

        public InvalidSymbolException( string symbol )
        {
            Symbol = symbol ;
        }

        public InvalidSymbolException( string symbol, string message ) : base( message )
        {
            Symbol = symbol;
        }

        public InvalidSymbolException( string symbol, string message, Exception innerException ) : base( message, innerException )
        {
            Symbol = symbol;
        }
    }
}
