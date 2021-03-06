﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Panuon.UI
{
    //ProgressBar专用内部圆角转换器
    internal class ProgressBarConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //0是CornerRadius，1是Direction
            var cr = (CornerRadius)values[0];
            var dir = (PUProgressBar.Directions)values[1];
            if (dir == PUProgressBar.Directions.LeftToRight)
                return new CornerRadius(cr.TopLeft, 0, 0, cr.BottomLeft);
            else if (dir == PUProgressBar.Directions.RightToLeft)
                return new CornerRadius(0, cr.TopRight, cr.BottomRight, 0);
            else if (dir == PUProgressBar.Directions.TopToBottom)
                return new CornerRadius(cr.TopLeft, cr.TopRight, 0, 0);
            else
                return new CornerRadius(0, 0, cr.BottomRight, cr.BottomLeft);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class WidthToMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var actualWidth = (double)value;
            return new Thickness(actualWidth, 0, 0, 1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    //Window Header和Title转换器
    internal class HeaderConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //0是Header，1是Title
            return (string)values[0] == null ? (string)values[1]: (string)values[0];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }
    //Icon字体大小转换器（ + 5）
    internal class IconFontSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value  + 5;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    //CheckBox General样式内部对号的缩放比例
    internal class ScaleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //0是InnerWidth，1是InnerHeight
            var minvalue = (double)values[0] < (double)values[1] ? (double)values[0] : (double)values[1];
            return minvalue / 22;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    internal class ToggleHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value - 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    //内部Toggle的圆角转换器
    internal class ToHalfConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value / 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    //内部Toggle的水平偏移量转换器
    internal class ToggleTranslateXConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //0是InnerWidth，1是InnerHeight
            return ((double)values[0] - (double)values[1] + 1) * -1;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    //输入框内部宽度转换器
    internal class TextBoxInnerWidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //0是Width，1是Padding，，2是HorizontalContentAlignment
            if ((HorizontalAlignment)values[2] != HorizontalAlignment.Center)
                return (double)values[0] - ((Thickness)values[1]).Left - ((Thickness)values[1]).Right;
            else
                return DependencyProperty.UnsetValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }

    //输入框内部高度转换器
    internal class TextBoxInnerHeightConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //0是Heihgt，1是Padding，2是VerticalContentAlignment
            if ((VerticalAlignment)values[2] != VerticalAlignment.Center)
                return (double)values[0] - ((Thickness)values[1]).Top - ((Thickness)values[1]).Bottom;
            else
                return DependencyProperty.UnsetValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }
}
