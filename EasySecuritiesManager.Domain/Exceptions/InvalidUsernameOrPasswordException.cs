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
 *  Created 4/9/2021 8:23:14 PM
 *  Modified 4/9/2021 8:23:14 PM
 */
using System;
using System.Runtime.Serialization;

namespace EasySecuritiesManager.Domain.Exceptions
{
    public class InvalidUsernameOrPasswordException : Exception
    {
        public string  Username { get; set; }
        public string  Password { get; set; }
        public InvalidUsernameOrPasswordException( string username, string password )
        {
            Username = username ;
            Password = password ;
        }

        public InvalidUsernameOrPasswordException(  string username, 
                                                    string password, 
                                                    string message) : base( message )
        {
            Username = username;
            Password = password;
        }

        public InvalidUsernameOrPasswordException(  string      username, 
                                                    string      password, 
                                                    string      message, 
                                                    Exception   innerException) : base( message, innerException )
        {
            Username = username;
            Password = password;
        }    
    }
}
