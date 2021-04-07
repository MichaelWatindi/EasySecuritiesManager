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
 *  Created 4/6/2021 1:28:07 AM
 *  Modified 4/6/2021 1:28:07 AM
 */
using System;
using System.Runtime.Serialization;

namespace EasySecuritiesManager.Domain.Exceptions
{
    public class InsufficientFundsException : Exception
    {
        public decimal AccountBalance   { get ; set ; }
        public decimal RequiredBalance  { get ; set ; }

        public InsufficientFundsException( decimal accountBalance, decimal requiredBalance )
        {
            AccountBalance  = accountBalance ;
            RequiredBalance = requiredBalance ; 
        }

        public InsufficientFundsException(  decimal accountBalance , 
                                            decimal requiredBalance , 
                                            string  message ) : base( message )
        {
            AccountBalance  = accountBalance ;
            RequiredBalance = requiredBalance ;
        }

        public InsufficientFundsException(  decimal     accountBalance ,
                                            decimal     requiredBalance , 
                                            string      message , 
                                            Exception   innerException ) : base( message, innerException )
        {
            AccountBalance  = accountBalance ;
            RequiredBalance = requiredBalance ;
        }
    }
}
