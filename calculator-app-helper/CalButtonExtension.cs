using System;
using OpenQA.Selenium;


namespace calculator_app_helper
{
    public static class CalButtonExtension
    {
        /// <summary>
        /// Find
        /// </summary>
        /// <param name="value"></param>
        public static void Hit(this IWebDriver webdDriver, char value)
        {
            if (value == '/')
                value = '÷';

            webdDriver.FindElement(By.XPath($"//input[@value='{value}']")).Click();
        }

        public static string GetDisplayResult(this IWebDriver webdDriver)
        {
            return webdDriver.FindElement(By.XPath($"//*[@id='display']/div")).Text;
        }

    }
}
