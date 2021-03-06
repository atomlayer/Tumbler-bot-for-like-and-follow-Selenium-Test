﻿using System;
using System.Threading.Tasks;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TumblerBot_Selenium_Test
{
    public class BotEnvironmentChrome:BotEnvironmentBase
    {
        public BotEnvironmentChrome(Logger logger, Settings settings):base (logger, settings){ }

        public override void Initialize()
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArgument($"user-data-dir={Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $"/Local/Google/Chrome/User DataManager/Profile 1/"}");
            options.AddArgument("--start-maximized");
            options.AddArgument("disable-infobars"); // disabling infobars
            options.AddArgument("--disable-extensions"); // disabling extensions
            options.AddArgument("--disable-gpu"); // applicable to windows os only
            options.AddArgument("--disable-dev-shm-usage"); // overcome limited resource problems
            options.AddArgument("--no-sandbox"); // Bypass OS security model

            Driver = new OpenQA.Selenium.Chrome.ChromeDriver(options);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            base.Initialize();

        }

        public async void RunAsync(ActionBase action)
        {
            await Task.Run(() =>
            {
                action.Initialize(this);
                action.Action();
            });
        }

    }
}
