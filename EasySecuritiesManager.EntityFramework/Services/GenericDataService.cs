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
 *  Created 4/2/2021 1:08:11 PM
 *  Modified 4/2/2021 1:08:11 PM
 */
using EasySecuritiesManager.Domain.Models;
using EasySecuritiesManager.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasySecuritiesManager.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        protected readonly EasySecuritiesManagerDbContextFactory _contextFactory ;

        public GenericDataService( EasySecuritiesManagerDbContextFactory contextFactory )
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> CreateAsync(T entity)
        {
            using ( EasySecuritiesManagerDBContext context = _contextFactory.CreateDbContext() )
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync( entity ) ;
                await context.SaveChangesAsync() ;

                return createdResult.Entity ;
            }
        }

        public async Task<bool> Delete( int id )
        {
            using (EasySecuritiesManagerDBContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync( e => e.Id == id ) ;
                context.Set<T>().Remove( entity ) ; 
                await context.SaveChangesAsync() ;
                
                return true ;
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            using (EasySecuritiesManagerDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public virtual async Task<T> GetAsync( int id )
        {
            using (EasySecuritiesManagerDBContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync( e => e.Id == id ) ;
                return entity ;
            }
        }

        public async Task<T> Update( int id, T entity )
        {
            using ( EasySecuritiesManagerDBContext context = _contextFactory.CreateDbContext() )
            {
                entity.Id = id ;
                context.Set<T>().Update( entity ) ;
                await context.SaveChangesAsync() ;

                return entity ;
            }
        }
    }
}
