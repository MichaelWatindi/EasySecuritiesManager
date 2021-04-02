/**
 *  Tindi Systems Inc
 *  $specifiedsolutionname$ $projectname$
 *  See Copyright file at the top of the source tree.
 *
 *  This product includes software developed by the 
 *  Tindi Systems
 *
 *  @file $filename
 *
 *  @brief
 *
 *  @author Michael Watindi
 *  See contact information in the license file at the top of the source tree.
 *
 *  Copyright (c) 2021 Tindi Systems Inc.
 *  All Rights Reserved.
 *  
 *  Created 4/2/2021 9:34:16 AM
 *  Modified 4/2/2021 9:34:16 AM
 */

using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasySecuritiesManager.Domain.Services
{
    public interface IDataService<T>
    {
        //  Get by id
        Task<T> GetAsync( int id ) ;

        //  Get all
        Task<IEnumerable<T>> GetAllAsync() ;

        //  Create
        Task<T> CreateAsync( T entity ) ;

        //  Update
        Task<T> Update( int id, T entity ) ;

        //  Delete
        Task<bool> Delete( int id ) ; 
    }
}