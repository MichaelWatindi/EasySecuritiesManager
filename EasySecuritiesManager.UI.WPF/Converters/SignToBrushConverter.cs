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
 *  Created 4/4/2021 1:12:13 AM
 *  Modified 4/4/2021 1:12:13 AM
 */
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace EasySecuritiesManager.UI.WPF.Converters
{
    [ ValueConversion( typeof( int ),       typeof( Brush ))]
    [ ValueConversion( typeof( double ),    typeof( Brush ))]
    [ ValueConversion( typeof( byte ),      typeof( Brush ))]
    [ ValueConversion( typeof( long ),      typeof( Brush ))]
    [ ValueConversion( typeof( float ),     typeof( Brush ))]
    [ ValueConversion( typeof( uint ),      typeof( Brush ))]
    [ ValueConversion( typeof( short ),     typeof( Brush ))]
    [ ValueConversion( typeof( sbyte ),     typeof( Brush ))]
    [ ValueConversion( typeof( ushort ),    typeof( Brush ))]
    [ ValueConversion( typeof( ulong ),     typeof( Brush ))]
    [ ValueConversion( typeof( decimal ),   typeof( Brush ))]
    [ ValueConversion( typeof( int ),       typeof( Brush ))]
    public class SignToBrushConverter : IValueConverter
    {
        private static readonly Brush DefaultNegativeBrush  = new SolidColorBrush(  Colors.Red ) ;
        private static readonly Brush DefaultPositiveBrush  = new SolidColorBrush(  Colors.Green ) ;
        private static readonly Brush DefaultzeroBrush      = new SolidColorBrush(  Colors.Green ) ;

        static SignToBrushConverter()
        {
            DefaultNegativeBrush.Freeze() ;
            DefaultPositiveBrush.Freeze() ;
            DefaultzeroBrush.Freeze() ;
        }

        public Brush NegativeBrush  { get ; set ; } 
        public Brush PositiveBrush  { get ; set ; } 
        public Brush ZeroBrush      { get ; set ; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ( !IsSupportedType( value ) ) { return DependencyProperty.UnsetValue ; }

            decimal decimalValue = System.Convert.ToDecimal( value ) ;

            if( decimalValue < 0M ) return NegativeBrush ?? DefaultNegativeBrush ;
            if( decimalValue > 0M ) return PositiveBrush ?? DefaultPositiveBrush ;

            return ZeroBrush ?? DefaultzeroBrush ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static bool IsSupportedType( object value)
        {
            return  value is int    || 
                    value is double ||
                    value is byte   ||
                    value is long   ||
                    value is float  ||
                    value is uint   ||
                    value is short  ||
                    value is sbyte  ||
                    value is ushort ||
                    value is ulong  ||
                    value is decimal;
        }
    }
}
