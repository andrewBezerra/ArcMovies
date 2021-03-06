﻿using ArcMovies.Helpers;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace ArcMovies.Converters
{
    public class MovieImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && parameter.Equals("Backdrop"))
                return string.Format("{0}{1}", AppSettings.BackdropImageBaseUrl, value);
            else 
                return string.Format("{0}{1}", AppSettings.PosterImageBaseUrl, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
