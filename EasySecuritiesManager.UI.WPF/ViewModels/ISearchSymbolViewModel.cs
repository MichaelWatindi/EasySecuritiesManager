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
 *  Created 4/2/2021 7:25:12 PM
 *  Modified 4/2/2021 7:25:12 PM
 */

using System.ComponentModel;

namespace EasySecuritiesManager.UI.WPF.ViewModels
{
    public interface ISearchSymbolViewModel : INotifyPropertyChanged
    {
        MessageViewModel    ErrorMessageViewModel   { get; set ; }
        string              SearchResultSymbol      { set; }
        decimal             StockPrice              { set ; }
        string              Symbol                  { get ; }
        bool                CanSearchSymbol         { get ; }
    }
}