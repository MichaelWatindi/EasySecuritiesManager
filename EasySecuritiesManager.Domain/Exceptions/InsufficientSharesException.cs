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
 *  Created 4/25/2021 4:23:59 AM
 *  Modified 4/25/2021 4:23:59 AM
 */
using System;
using System.Runtime.Serialization;

namespace EasySecuritiesManager.Domain.Exceptions
{
    public class InsufficientSharesException : Exception
    {
        public string   Symbol                  { get ; }
        public int      CurrentAccountShares    { get ; }
        public int      RequiredShares          { get ; }
        public InsufficientSharesException( string  symbol, 
                                            int     currentAccountShares, 
                                            int     requiredShares )
        {
            Symbol                  = symbol ;
            CurrentAccountShares    = currentAccountShares ;
            RequiredShares          = requiredShares ;
        }

        public InsufficientSharesException( string  message , 
                                            string  symbol , 
                                            int     currentAccountShares , 
                                            int     requiredShares ) : base(message)
        {
            Symbol                  = symbol ;
            CurrentAccountShares    = currentAccountShares ;
            RequiredShares          = requiredShares ;
        }

        public InsufficientSharesException( string      message , 
                                            Exception   innerException , 
                                            string      symbol , 
                                            int         currentAccountShares , 
                                            int         requiredShares ) : base( message, innerException )
        {
            Symbol                  = symbol ;
            CurrentAccountShares    = currentAccountShares ;
            RequiredShares          = requiredShares ;
        }
    }
}
