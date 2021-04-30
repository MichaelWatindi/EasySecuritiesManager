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
 *  Created 4/3/2021 11:35:49 PM
 *  Modified 4/3/2021 11:35:49 PM
 */
using EasySecuritiesManager.Domain.Exceptions;
using EasySecuritiesManager.Domain.Services;
using System.Threading.Tasks;

namespace EasySecuritiesManager.FinancialModelingPrepApi.Services
{
    class StockPriceResult
    {
        public string   Symbol  { get; set; }
        public decimal  Price   { get; set; }
        public int      Volume  { get; set; }
    }

    public  class GetStockPriceService : IGetStockPriceService
    {
        private readonly FinancialModelingPrepHttpClient _httpClient ;

        public GetStockPriceService( FinancialModelingPrepHttpClient httpClientFactory )
        {
            _httpClient = httpClientFactory;
        }

        public async Task<decimal> GetPrice( string symbol )
        {            
            string uriSuffix    = "quote-short/" + symbol.ToUpper() ;// + "?apikey=" + serviceKey ;

            StockPriceResult stockPriceResult = await _httpClient.GetAsync<StockPriceResult>( uriSuffix ) ;

            if ( stockPriceResult.Price == 0 ) {   
                    
                throw new InvalidSymbolException( symbol ) ; 
            }

            return stockPriceResult.Price ;                
            
        }
    }
}
