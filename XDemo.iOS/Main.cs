﻿using System;
using UIKit;
using XDemo.Core.Infrastructure.Logging;

namespace XDemo.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            try
            {
                // if you want to use a different Application Delegate class from "AppDelegate"
                // you can specify it here.
                UIApplication.Main(args, null, "AppDelegate");
            }
            catch (Exception ex)
            {
                // focused to this while debugging
                //throw ex;
                LogCommon.Error(ex);
            }
        }
    }
}
