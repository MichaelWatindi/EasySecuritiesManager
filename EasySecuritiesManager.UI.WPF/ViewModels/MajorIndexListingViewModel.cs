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
using EasySecuritiesManager.UI.WPF.Commands;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EasySecuritiesManager.UI.WPF.ViewModels
{
    public class MajorIndexListingViewModel : ViewModelBase
    {
        private MajorIndex _dowJones ;
        public MajorIndex DowJones
        {
            get => _dowJones;
            set {
                _dowJones = value;
                OnPropertyChanged(nameof(DowJones));
            }
        }

        private MajorIndex _nasdaq;
        public MajorIndex Nasdaq
        {
            get => _nasdaq;
            set {
                _nasdaq = value;
                OnPropertyChanged(nameof(Nasdaq));
            }
        }

        private MajorIndex _sp500 ;
        public MajorIndex SP500
        {
            get => _sp500;
            set {
                _sp500 = value;
                OnPropertyChanged(nameof(SP500));
            }
        }

        private bool _isLoading = false ;
        public bool IsLoading
        {
            get => _isLoading ; 
            set {
                _isLoading = value;
                OnPropertyChanged( nameof( IsLoading ) );
            }
        }

        public ICommand cLoadMajorIndexesCommand { get ; }

        public MajorIndexListingViewModel( IMajorIndexService majorIndexService ) : base() 
        {
            cLoadMajorIndexesCommand = new LoadMajorIndexesCommand( this, majorIndexService) ;
        }

        public static MajorIndexListingViewModel LoadMajorIndexViewModel( IMajorIndexService majorIndexService )
        {
            MajorIndexListingViewModel majorIndexViewModel = new MajorIndexListingViewModel( majorIndexService ) ;
            majorIndexViewModel.cLoadMajorIndexesCommand.Execute( null ) ;
            return majorIndexViewModel;            
        }            
    }
}
