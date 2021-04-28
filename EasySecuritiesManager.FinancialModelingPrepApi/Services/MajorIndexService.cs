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
 *  Created 4/3/2021 12:12:43 PM
 *  Modified 4/3/2021 12:12:43 PM
 */
using EasySecuritiesManager.Domain.Models;
using EasySecuritiesManager.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EasySecuritiesManager.FinancialModelingPrepApi.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        private readonly FinancialModelingPrepHttpClientFactory _httpClientFactory;

        public MajorIndexService(FinancialModelingPrepHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<MajorIndex> GetMajorIndex( MajorIndexType indexType )
        {
            using ( FinancialModelingPrepHttpClient client = _httpClientFactory.CreateHttpClient() )
            {                
                string indexTypeURIRep  = GetIndexTypeURIRep( indexType ) ;
                string serviceKey       = "46cc602100660fc8f6b927fa71223fc1" ;
                
                string uriSuffix = "quote/" + indexTypeURIRep + "?apikey=" + serviceKey ; 

                MajorIndex majorIndex = await client.GetAsync<MajorIndex>( uriSuffix ) ;
                return majorIndex ;               
            }
        }

        private string GetIndexTypeURIRep( MajorIndexType indexType )
        {
            switch (indexType)
            {
                case MajorIndexType.DowJones:
                    return "^DJI";
                case MajorIndexType.NasDaq:
                    return "^IXIC";
                case MajorIndexType.SP500:
                    return "^GSPC";
                default:
                    throw new Exception( "Major IndexType does not have a suffix defined." ) ;
            }
        }
    }
}