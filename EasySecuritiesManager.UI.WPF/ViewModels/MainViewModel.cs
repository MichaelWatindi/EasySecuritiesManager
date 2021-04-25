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
 *  Created 4/2/2021 4:31:50 PM
 *  Modified 4/2/2021 4:31:50 PM
 */
using EasySecuritiesManager.UI.WPF.Commands;
using EasySecuritiesManager.UI.WPF.State.Authenticators;
using EasySecuritiesManager.UI.WPF.State.Navigators;
using EasySecuritiesManager.UI.WPF.ViewModels.Factories;
using System.Windows.Input;

namespace EasySecuritiesManager.UI.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigator     _navigator ;
        private readonly IAuthenticator _authenticator ;

        public bool                 IsLoggedIn          => _authenticator.IsLoggedIn ;
        public ViewModelBase        CurrentViewModel    => _navigator.CurrentViewModel ;
        public IViewModelFactory    ViewModelFactory    { get ; }
        public ICommand             UpdateCurrentViewModelCommand  { get ;  }

        public MainViewModel(   INavigator          navigator, 
                                IAuthenticator      authenticator, 
                                IViewModelFactory   viewModelFactory ) : base() 
        {
            _navigator                      = navigator ;
            _authenticator                  = authenticator ;
            ViewModelFactory                = viewModelFactory ;

            _navigator.StateChanged         += Navigator_StateChanged ;
            _authenticator.StateChanged     += Authenticator_StateChanged ;
            UpdateCurrentViewModelCommand   = new UpdateCurrentViewModelCommand( navigator, viewModelFactory ) ;
            UpdateCurrentViewModelCommand.Execute( ViewType.Login ) ;
        }

        private void Authenticator_StateChanged()
        {
            OnPropertyChanged( nameof( IsLoggedIn )) ;
        }       

        private void Navigator_StateChanged()
        {
            OnPropertyChanged( nameof( CurrentViewModel )) ;
        }
    }
}
