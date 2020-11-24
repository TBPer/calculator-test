using System.Collections;
using System.Collections.Generic;
using calculator_app_helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace calculator_ui_tests
{
    [TestClass]
    public class Tests
    {
        private IWebDriver driver { get; set; }

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();

            // This will open up the URL 
            driver.Url = "https://duffmanns.github.io/calc-test/calculator/app/index.html";
        }

        /// <summary>
        /// 1. Simple addition
        ///     1. 1+3
        ///     2. 5+6
        ///     3. 3+7
        ///     4. Add all of the three together to make the whole total
        /// </summary>
        [TestMethod]
        [TestCategory("Additon")]
        [Description("Test")]
        public void SimpleAdditionOfPositiveNumbers()
        {
            Dictionary<EnterInputsOperations, string> testSamples = new Dictionary<EnterInputsOperations, string>()
            {
                { new EnterInputsOperations("1+3"), "4"  },
                { new EnterInputsOperations("5+6"), "11"  },
                { new EnterInputsOperations("3+7"), "10" }
            };

            foreach (var testSample in testSamples)
            {
                var result = testSample.Key.Calculate(driver);
                Assert.AreEqual(result, testSample.Value, message: $"{testSample.Key} is returning {result}, expecting {testSample.Value}!");
            }
        }

        /// <summary>
        /// 2. Simple division
        ///     1. 5/1
        ///     2. 6/2
        ///     3. 100/2
        /// </summary>
        [TestMethod]
        [TestCategory("Division")]
        [Description("2.1 5/1 --- 2.2 6/2 --- 2.3 100/2")]
        public void SimpleDivisions()
        {
            Dictionary<EnterInputsOperations, string> testSamples = new Dictionary<EnterInputsOperations, string>()
            {
                { new EnterInputsOperations("5÷1"), "5"  },
                { new EnterInputsOperations("6÷2"), "3"  },
                { new EnterInputsOperations("100÷2"), "50" }
            };

            foreach (var testSample in testSamples)
            {
                var result = testSample.Key.Calculate(driver);
                Assert.AreEqual(result, testSample.Value, message: $"{testSample.Key} is returning {result}, expecting {testSample.Value}!");
            }
        }

        /// <summary>
        /// 2. Simple division
        ///     4. 0/2
        ///     5. 4/0
        /// </summary>
        [TestMethod]
        [TestCategory("Division")]
        [Description("2.4 0/2")]
        public void ZeroDivided()
        {
            Dictionary<EnterInputsOperations, string> testSamples = new Dictionary<EnterInputsOperations, string>()
            {
                { new EnterInputsOperations("0÷2"), "0" }
            };

            foreach (var testSample in testSamples)
            {
                var result = testSample.Key.Calculate(driver);
                Assert.AreEqual(result, testSample.Value, message: $"{testSample.Key} is returning {result}, expecting {testSample.Value}!");
            }
        }

        /// <summary>
        /// 2. Simple division
        ///     5. 4/0
        /// </summary>
        [TestMethod]
        [TestCategory("Division")]
        [Description("2.5 4/0")]
        public void DividedByZero()
        {
            Dictionary<EnterInputsOperations, string> testSamples = new Dictionary<EnterInputsOperations, string>()
            {
                { new EnterInputsOperations("4÷0"), "Error" }
            };

            foreach (var testSample in testSamples)
            {
                var result = testSample.Key.Calculate(driver);
                Assert.AreEqual(result, testSample.Value, message: $"{testSample.Key} is returning {result}, expecting {testSample.Value}!");
            }
        }

        /// <summary>
        /// 3. Decimals
        ///     1. 0.5+2.65354
        /// </summary>
        [TestMethod]
        [TestCategory("Decimals")]
        [Description("3.1 0.5+2.65354")]
        public void DecimalsAdditionOfPositiveNumbers()
        {
            Dictionary<EnterInputsOperations, string> testSamples = new Dictionary<EnterInputsOperations, string>()
            {
                { new EnterInputsOperations("0.5+2.65354"), "3.15354"  }
            };

            foreach (var testSample in testSamples)
            {
                var result = testSample.Key.Calculate(driver);
                Assert.AreEqual(result, testSample.Value, message: $"{testSample.Key} is returning {result}, expecting {testSample.Value}!");
            }
        }

        /// <summary>
        /// 3. Decimals
        ///     2. 1.25-.25/0
        /// </summary>
        [TestMethod]
        [TestCategory("Decimals")]
        [Description("3.2 1.25-.25/0")]
        public void DecimalsDivisionByZero()
        {
            Dictionary<EnterInputsOperations, string> testSamples = new Dictionary<EnterInputsOperations, string>()
            {
                { new EnterInputsOperations("1.25-.25/0"), "Error"  }
            };

            foreach (var testSample in testSamples)
            {
                var result = testSample.Key.Calculate(driver);
                Assert.AreEqual(result, testSample.Value, message: $"{testSample.Key} is returning {result}, expecting {testSample.Value}!");
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
        }
    }
}
