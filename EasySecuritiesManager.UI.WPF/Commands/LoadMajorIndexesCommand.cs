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
 *  Created 4/30/2021 3:36:04 AM
 *  Modified 4/30/2021 3:36:04 AM
 */
using EasySecuritiesManager.Domain.Models;
using EasySecuritiesManager.Domain.Services;
using EasySecuritiesManager.UI.WPF.ViewModels;
using System;
using System.Threading.Tasks;

namespace EasySecuritiesManager.UI.WPF.Commands
{
    public class LoadMajorIndexesCommand : AsyncCommandBase
    {
        private readonly MajorIndexListingViewModel _majorIndexListingViewModel ;
        private readonly IMajorIndexService         _majorIndexService ;

        public LoadMajorIndexesCommand( MajorIndexListingViewModel  majorIndexListingViewModel, 
                                        IMajorIndexService          majorIndexService)
        {
            _majorIndexListingViewModel = majorIndexListingViewModel;
            _majorIndexService          = majorIndexService;
        }

        public override async Task ExecuteAsync( object parameter )
        {
            _majorIndexListingViewModel.IsLoading = true;
            await Task.WhenAll(LoadDowJones(), LoadDowNasdaq(), LoadDowSP500()) ;
            _majorIndexListingViewModel.IsLoading = false ;
        }        

        private async Task LoadDowJones()
        {
            _majorIndexListingViewModel.DowJones = await _majorIndexService.GetMajorIndex( MajorIndexType.DowJones );
        }

        private async Task LoadDowNasdaq()
        {
            _majorIndexListingViewModel.Nasdaq = await _majorIndexService.GetMajorIndex( MajorIndexType.NasDaq );
        }

        private async Task LoadDowSP500()
        {
            _majorIndexListingViewModel.SP500 = await _majorIndexService.GetMajorIndex( MajorIndexType.SP500 );
        }
    }
}
