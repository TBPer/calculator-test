using System;
using OpenQA.Selenium;

namespace calculator_app_helper
{
    public class EnterInputsOperations
    {
        public string Input { get; set; }

        public EnterInputsOperations(string input)
        {

            this.Input = input;
        }

        public string Calculate (IWebDriver webDriver)
        {
            foreach(var input in Input.ToCharArray())
            {
                webDriver.Hit(input);
            }

            webDriver.Hit('=');
            return webDriver.GetDisplayResult();
        }
    }
}
