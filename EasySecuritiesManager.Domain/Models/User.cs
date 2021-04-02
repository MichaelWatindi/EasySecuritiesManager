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
 *  Created 4/1/2021 5:05:46 AM
 *  Modified 4/1/2021 5:05:46 AM
 */
using System;

namespace EasySecuritiesManager.Domain.Models
{
    public class User : DomainObject
    {
        public string   Email           { get; set; }
        public string   Username        { get; set; }
        public string   PasswordHash    { get; set; }
        public DateTime DateJoined      { get; set; } = DateTime.Now ;
    }
}
