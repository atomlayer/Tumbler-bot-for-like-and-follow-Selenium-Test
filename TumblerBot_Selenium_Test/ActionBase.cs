﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using OpenQA.Selenium;

namespace TumblerBot_Selenium_Test
{
    public abstract class ActionBase
    {
        public BotEnvironmentBase BotEnvironment;

        protected ActionBase()
        {
        }

        protected ActionBase(BotEnvironmentBase botEnvironment)
        {
            BotEnvironment = botEnvironment;
        }


        public void Initialize(BotEnvironmentBase botEnvironment)
        {
            BotEnvironment = botEnvironment;
        }

        public abstract void Action();

        public void GoToURL(string URL)
        {
            try{ BotEnvironment.Driver.Navigate().GoToUrl(URL); }
            catch (Exception e) { BotEnvironment.Logger.Debug(e.Message);}
        }

        public  void ScrollDown()
        {
            try { BotEnvironment.Jse.ExecuteScript("window.scrollBy(0,1000)");}
            catch (Exception e) { BotEnvironment.Logger.Error(e);}
        }
    }
}
