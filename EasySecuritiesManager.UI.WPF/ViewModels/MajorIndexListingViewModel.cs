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
 *  Created 4/3/2021 5:14:41 PM
 *  Modified 4/3/2021 5:14:41 PM
 */
using EasySecuritiesManager.Domain.Models;
using EasySecuritiesManager.Domain.Services;
using System;
using System.Threading.Tasks;

namespace EasySecuritiesManager.UI.WPF.ViewModels
{
    public class MajorIndexListingViewModel : ViewModelBase
    {
        private readonly IMajorIndexService _majorIndexService ;
     
        private MajorIndex _dowJones ;
        public MajorIndex DowJones  
        {
            get { return _dowJones ; }
            set {
                _dowJones = value ;
                OnPropertyChanged( nameof( DowJones ) ) ;
            } 
        }
        
        private MajorIndex _nasdaq;
        public MajorIndex Nasdaq
        {
            get { return _nasdaq; }
            set
            {
                _nasdaq = value;
                OnPropertyChanged( nameof( Nasdaq ) );
            }
        }

        private MajorIndex _sp500;
        public MajorIndex SP500
        {
            get { return _sp500; }
            set
            {
                _sp500 = value;
                OnPropertyChanged( nameof( SP500 ) );
            }
        }

        public MajorIndexListingViewModel( IMajorIndexService majorIndexService ) : base() 
        {
            _majorIndexService = majorIndexService;
        }

        public static MajorIndexListingViewModel LoadMajorIndexViewModel( IMajorIndexService majorIndexService )
        {
            MajorIndexListingViewModel majorIndexViewModel = new MajorIndexListingViewModel( majorIndexService ) ;
            majorIndexViewModel.LoadMajorIndices() ;
            return majorIndexViewModel; 
        }

        private void LoadMajorIndices()
        {            
            _majorIndexService.GetMajorIndex(MajorIndexType.DowJones).ContinueWith(task =>
            {
                if ( task.Exception == null)
                {
                    DowJones = task.Result ;
                }
            });
            _majorIndexService.GetMajorIndex(MajorIndexType.NasDaq).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Nasdaq = task.Result;
                }
            });
            _majorIndexService.GetMajorIndex(MajorIndexType.SP500).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    SP500 = task.Result;
                }
            });
        }
    }
}
