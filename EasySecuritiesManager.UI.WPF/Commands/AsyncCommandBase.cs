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
 *  Created 4/23/2021 6:20:12 AM
 *  Modified 4/23/2021 6:20:12 AM
 */
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EasySecuritiesManager.UI.WPF.Commands
{
    public abstract class AsyncCommandBase : ICommand
    {
        private bool _isExecuting ;
        public bool IsExecuting
        {
            get => _isExecuting ;
            set {
                _isExecuting = value ;
                OnCanExecuteChanged() ;
            }
        }

        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute( object parameter ) => !IsExecuting ;       

        public async void Execute( object parameter )
        {
            IsExecuting = true ;
            await ExecuteAsync( parameter ) ;
            IsExecuting = false ;
        }

        public abstract Task ExecuteAsync( object parameter ) ;

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke( this, new EventArgs() ) ;
        }
    }
}
