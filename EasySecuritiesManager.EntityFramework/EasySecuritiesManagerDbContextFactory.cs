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
 *  Created 4/2/2021 12:35:06 PM
 *  Modified 4/2/2021 12:35:06 PM
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace EasySecuritiesManager.EntityFramework
{
    public class EasySecuritiesManagerDbContextFactory : IDesignTimeDbContextFactory<EasySecuritiesManagerDBContext>
    {
        public EasySecuritiesManagerDBContext CreateDbContext( string[] args = null )
        {
            var options = new DbContextOptionsBuilder<EasySecuritiesManagerDBContext>() ;
            options.UseSqlServer("Data Source=.;Initial Catalog=EasySecuritiesManager;Integrated Security=True");

            return new EasySecuritiesManagerDBContext( options.Options ) ;
        }
    }
}
