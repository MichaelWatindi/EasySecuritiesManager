/**
 *  Tindi Systems Inc
 *  $specifiedsolutionname$ EntityFramework
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
 *  Created 4/2/2021 10:28:58 AM
 *  Modified 4/2/2021 10:28:58 AM
 */
using EasySecuritiesManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EasySecuritiesManager.EntityFramework
{
    public class EasySecuritiesManagerDBContext : DbContext
    {
        public DbSet<User>              tUsers              { get ; set ; }
        public DbSet<Account>           tAccounts           { get ; set ; }
        public DbSet<AssetTransaction>  tAssetTransactions  { get ; set ; }
        
        public EasySecuritiesManagerDBContext( DbContextOptions options ) : base( options )  { }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            //  TheAsset like stocks is owned by the transaction. 
            modelBuilder.Entity<AssetTransaction>().OwnsOne( a => a.TheAsset ) ;
            base.OnModelCreating( modelBuilder ); 
        }       

    }
}
