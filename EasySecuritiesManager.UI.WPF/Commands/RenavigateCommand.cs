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
 *  Created 4/23/2021 9:57:36 PM
 *  Modified 4/23/2021 9:57:36 PM
 */
using EasySecuritiesManager.UI.WPF.State.Navigators;
using System;
using System.Windows.Input;

namespace EasySecuritiesManager.UI.WPF.Commands
{
    public class RenavigateCommand : ICommand
    {
        private readonly    IRenavigator _renavigator ;
        public  event       EventHandler CanExecuteChanged;

        public RenavigateCommand( IRenavigator renavigator )
        {
            _renavigator = renavigator;
        }        

        public bool CanExecute( object parameter ) => true ;

        public void Execute( object parameter )
        {
            _renavigator.Renavigate() ;
        }
    }
}
