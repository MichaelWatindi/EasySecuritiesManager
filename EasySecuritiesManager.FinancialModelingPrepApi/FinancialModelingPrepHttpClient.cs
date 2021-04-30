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
 *  Created 4/4/2021 12:45:39 AM
 *  Modified 4/4/2021 12:45:39 AM
 */
using EasySecuritiesManager.FinancialModelingPrepApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EasySecuritiesManager.FinancialModelingPrepApi
{
    public class FinancialModelingPrepHttpClient
    {
        private readonly HttpClient _client ;
        private readonly string     _apiKey ;

        public FinancialModelingPrepHttpClient( HttpClient client, FinancialModelingPrepApiKey apiKey )
        {            
            _client     = client ;
            _apiKey     = apiKey.Key ;
        }

        public string ApiKey => _apiKey;

        public async Task<T> GetAsync<T>( string uri ) where T : class
        {
            HttpResponseMessage response = await _client.GetAsync( $"{uri}?apikey={ApiKey}" ) ;
            string jsonResponse = await response.Content.ReadAsStringAsync() ;

            if ( jsonResponse == "" || jsonResponse == "[]" ) { throw new Exception() ; }

            List<T> entityCollection = JsonConvert.DeserializeObject<List<T>>( jsonResponse ) ;
            if ( !entityCollection.Any() ) { return null ; }

            return entityCollection[ 0 ] ; 
        }
     }
}
