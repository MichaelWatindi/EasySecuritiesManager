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
 *  Created 4/10/2021 12:49:35 PM
 *  Modified 4/10/2021 12:49:35 PM
 */
using System;
using System.Runtime.Serialization;

namespace EasySecuritiesManager.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string Username { get; set; }

        public UserNotFoundException(   string username = null)
        {
            Username = username;
        }

        public UserNotFoundException(   string message, 
                                        string username) : base(message)
        {
            Username = username;
        }

        public UserNotFoundException(   string      message, 
                                        Exception   innerException, 
                                        string      username) : base(message, innerException)
        {
            Username = username;
        }
    }
}
