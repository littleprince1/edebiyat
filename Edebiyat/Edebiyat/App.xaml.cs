﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Edebiyat
{
    /// <summary>
    /// App.xaml etkileşim mantığı
    /// </summary>
    public partial class App : Application
    {
        public static double Screen_Height = SystemParameters.PrimaryScreenHeight;
        public static double Screen_Width = SystemParameters.PrimaryScreenWidth;
        App()
        {

        }
    }
}
