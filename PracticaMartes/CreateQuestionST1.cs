using System;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PracticaMartes
{
    [TestFixture]
    public class CreateQuestionST1
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private bool acceptNextAlert = true;
        private WebDriverWait wait;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheExhibitsFieldsListedTwiceTest()
        {
            try
            {
                Console.WriteLine("Navegando a ST1");
                driver.Navigate().GoToUrl("https://examdevtst1.pearsonvue.com/ExamDeveloper/login/Login.aspx");

                Console.WriteLine("Introducimos username");
                driver.FindElement(By.Id("ctl00_RHSContentPlaceHolder_tbUsername")).Click();
                driver.FindElement(By.Id("ctl00_RHSContentPlaceHolder_tbUsername")).Clear();
                driver.FindElement(By.Id("ctl00_RHSContentPlaceHolder_tbUsername")).SendKeys("Lynx01");

                Console.WriteLine("Introducimos password");
                driver.FindElement(By.Id("ctl00_RHSContentPlaceHolder_tbPassword")).Click();
                driver.FindElement(By.Id("ctl00_RHSContentPlaceHolder_tbPassword")).Clear();
                driver.FindElement(By.Id("ctl00_RHSContentPlaceHolder_tbPassword")).SendKeys("ed1tHPi0f");

                Console.WriteLine("Clickamos en login");
                driver.FindElement(By.Id("ctl00_RHSContentPlaceHolder_btnLogin")).Click();

                Console.WriteLine("Introducimos la respuesta de confirmacion");
                driver.FindElement(By.Id("ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_tbAnswer")).Click();
                driver.FindElement(By.Id("ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_tbAnswer")).Clear();
                driver.FindElement(By.Id("ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_tbAnswer")).SendKeys("velvet");
                driver.FindElement(By.Id("ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_btnSubmit")).Click();
                Thread.Sleep(4000);

                Console.WriteLine("Buscamos el proyecto Manu y lo abrimos");
                wait.Until(x => x.FindElement(By.XPath("(//img[@alt='#'])[5]"))).Click();
                driver.FindElement(By.LinkText("Manu project")).Click();

                Console.WriteLine("Click on Develop Question");
                driver.FindElement(By.Id("ctl00_ctl00_ctl00_plcMenu_mnuTopMenu_rptTopmenu_ctl00_lnkTopmenu")).Click();

                Console.WriteLine("Click on Write Question");
                driver.FindElement(By.Id("ctl00_ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_RHSContentPlaceHolder_btnWrite")).Click();

                Console.WriteLine("Seleccionamos el idioma ingles");
                driver.FindElement(By.Id("ctl00_ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_RHSContentPlaceHolder_QuestionControl_ddlLanguageCode")).Click();
                new SelectElement(driver.FindElement(By.Id("ctl00_ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_RHSContentPlaceHolder_QuestionControl_ddlLanguageCode"))).SelectByText("English");
                driver.FindElement(By.Id("ctl00_ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_RHSContentPlaceHolder_QuestionControl_ddlLanguageCode")).Click();

                Console.WriteLine("Introducimos el stem");
                driver.FindElement(By.Id("ctl00_ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_RHSContentPlaceHolder_QuestionControl_qEditor1_tbQuestionText_dvEditorControl")).Click();
                driver.SwitchTo().Frame("ctl00_ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_RHSContentPlaceHolder_QuestionControl_qEditor1_tbQuestionText_txtEditorControl_ifr");
                driver.FindElement(By.Id("tinymce")).SendKeys("Question 4");
                driver.SwitchTo().DefaultContent();

                Console.WriteLine("Introducimos la opcion A");
                driver.FindElement(By.Id("ctl00_ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_RHSContentPlaceHolder_QuestionControl_qEditor1_rptOptions_ctl00_tbDistractor_dvEditorControl")).Click();
                driver.SwitchTo().Frame("ctl00_ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_RHSContentPlaceHolder_QuestionControl_qEditor1_rptOptions_ctl00_tbDistractor_txtEditorControl_ifr");
                driver.FindElement(By.Id("tinymce")).SendKeys("A");
                driver.SwitchTo().DefaultContent();

                Console.WriteLine("Introducimos la opcion B");
                driver.FindElement(By.Id("ctl00_ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_RHSContentPlaceHolder_QuestionControl_qEditor1_rptOptions_ctl01_tbDistractor_dvEditorControl")).Click();
                driver.SwitchTo().Frame("ctl00_ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_RHSContentPlaceHolder_QuestionControl_qEditor1_rptOptions_ctl01_tbDistractor_txtEditorControl_ifr");
                driver.FindElement(By.Id("tinymce")).SendKeys("B");
                driver.SwitchTo().DefaultContent();

                Console.WriteLine("Introducimos la opcion C");
                driver.FindElement(By.Id("ctl00_ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_RHSContentPlaceHolder_QuestionControl_qEditor1_rptOptions_ctl02_tbDistractor_dvEditorControl")).Click();
                driver.SwitchTo().Frame("ctl00_ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_RHSContentPlaceHolder_QuestionControl_qEditor1_rptOptions_ctl02_tbDistractor_txtEditorControl_ifr");
                driver.FindElement(By.Id("tinymce")).SendKeys("C");
                driver.SwitchTo().DefaultContent();

                Console.WriteLine("Introducimos la opcion D");
                driver.FindElement(By.Id("ctl00_ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_RHSContentPlaceHolder_QuestionControl_qEditor1_rptOptions_ctl03_tbDistractor_dvEditorControl")).Click();
                driver.SwitchTo().Frame("ctl00_ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_RHSContentPlaceHolder_QuestionControl_qEditor1_rptOptions_ctl03_tbDistractor_txtEditorControl_ifr");
                driver.FindElement(By.Id("tinymce")).SendKeys("D");
                driver.SwitchTo().DefaultContent();

                Console.WriteLine("Marcamos la opcion correcta");
                driver.FindElement(By.Id("ctl00_ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_RHSContentPlaceHolder_QuestionControl_qEditor1_rptOptions_ctl00_chkDistractor")).Click();

                Console.WriteLine("Clickamos en submit");
                driver.FindElement(By.Id("ctl00_ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_RHSContentPlaceHolder_btnSubmitForReview")).Click();
                driver.FindElement(By.Id("ctl00_ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_RHSContentPlaceHolder_btnSubmit")).Click();
                driver.FindElement(By.Id("__tab_ctl00_ctl00_ctl00_RHSContentPlaceHolder_RHSContentPlaceHolder_RHSContentPlaceHolder_tabs_tabDashboard")).Click();

                Console.WriteLine("Comprobamos que la nueva pregunta se ha creado");
                Assert.AreEqual("Question 4", driver.FindElement(By.LinkText("Question 4")).Text);

                Console.WriteLine("Hacemos click on LogOut");
                driver.FindElement(By.Id("ctl00_ctl00_ctl00_plcMenu_mnuTopMenu_lbtnLogout")).Click();
                driver.FindElement(By.Id("ctl00_RHSContentPlaceHolder_Button1")).Click();

                Console.WriteLine("Comprobamos que nos hemos deslogado");
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//form[@id='aspnetForm']/div[4]/div[2]/div/div/div/div/div/div/div/div/div/div[2]/center/div[3]/div/div/div/div/div/div[2]/div")).Text, "^[\\s\\S]* Username:$"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo falló: " + e.Message);
            }
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}

