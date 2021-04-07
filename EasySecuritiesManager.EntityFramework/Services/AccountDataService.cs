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
 *  Created 4/6/2021 3:07:23 AM
 *  Modified 4/6/2021 3:07:23 AM
 */
using EasySecuritiesManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasySecuritiesManager.EntityFramework.Services
{
    public class AccountDataService : GenericDataService<Account>
    {
        public AccountDataService( EasySecuritiesManagerDbContextFactory contextFactory ) 
            : base( contextFactory ) { }

        public async Task<Account> GetWithAssetTransactionsAsync( int id )
        {
            using ( EasySecuritiesManagerDBContext context = _contextFactory.CreateDbContext() )
            {
                Account entity = await context.tAccounts.Include( a => a.AssetTransactions )
                                                        .FirstOrDefaultAsync( e => e.Id == id );
                return entity;
            }
        }

        public async Task<IEnumerable<Account>> GetWithAssetTransactionsAsync()
        {
            using ( EasySecuritiesManagerDBContext context = _contextFactory.CreateDbContext() )
            {
                IEnumerable<Account> entities = await context.tAccounts.Include( a => a.AssetTransactions )
                                                                       .ToListAsync();
                return entities;
            }
        }
    }
}
