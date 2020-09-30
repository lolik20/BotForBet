using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows;

namespace VKGroups

{
    public partial class Form1 : Form
    {
        IWebDriver Browser;
        IWebDriver Browser2;
        IWebDriver Browser3;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
        public Bitmap TakeScreenshot(By by)
        {
            // 1. Make screenshot of all screen
            var screenshotDriver = Browser as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            var bmpScreen = new Bitmap(new MemoryStream(screenshot.AsByteArray));

            // 2. Get screenshot of specific element
            IWebElement element = Browser.FindElement(by);
            var cropArea = new Rectangle(element.Location, element.Size);
            return bmpScreen.Clone(cropArea, bmpScreen.PixelFormat);

        }

        private void button1_Click(object sender, EventArgs e)
        {


            var char_log = textBox1.Text;
            var char_pass = textBox2.Text;
            var time_input = textBox3.Text;
            var link_group = textBox4.Text;
            var link_telegram = textBox5.Text;
            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser2 = new OpenQA.Selenium.Chrome.ChromeDriver();

            Browser3.Navigate().GoToUrl("https://web.telegram.org");

            Browser2.Navigate().GoToUrl("https://vk.com");
            IWebElement login = Browser2.FindElement(By.Id("index_email"));
            login.SendKeys(char_log);
            IWebElement password = Browser2.FindElement(By.Id("index_pass"));
            password.SendKeys(char_pass + OpenQA.Selenium.Keys.Enter);
            System.Threading.Thread.Sleep(60000);



            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl("https://widgets.sir.sportradar.com/betradar/ru/head-to-head");
            System.Threading.Thread.Sleep(3000);

            System.Threading.Thread.Sleep(8000);
            while (true)
            {
                Point:
                try
                {
                    Clipboard.Clear();

                    IWebElement headToHead = Browser.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[3]/div[1]/div/a[4]"));
                    headToHead.Click();
                    IWebElement livematch = Browser.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[2]/div/div[2]/div/div/div/div[2]/div/div/div/div[1]/div[3]"));
                    livematch.Click();
                    System.Threading.Thread.Sleep(5000);
                    IWebElement time = Browser.FindElement(By.XPath("//*[text()=" + "'" + time_input + "’" + "'" + "]"));
                    time.Click();
                }
                catch (NoSuchElementException)
                {
                    goto Point;
                }


                Browser3.Navigate().GoToUrl(link_telegram);
                System.Threading.Thread.Sleep(5000);
                string link = Browser.Url;


                var prnt_scrn1 = TakeScreenshot(By.XPath("/html/body/div/div/div/div[2]/div[2]/div/div[2]/div[1]/div/div/div/div[4]/div/div/div/div[2]/div/div/div[2]/div[1]/div/div[2]"));
                Clipboard.SetImage(prnt_scrn1);
                IWebElement telegramPost = Browser3.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[2]/div[3]/div/div[3]/div[2]/div/div/div/form/div[2]/div[5]"));
                Browser2.Navigate().GoToUrl(link_group);
                System.Threading.Thread.Sleep(3000);
                IWebElement send_post1 = Browser2.FindElement(By.CssSelector("#post_field"));
                send_post1.SendKeys(OpenQA.Selenium.Keys.Control + "v");
                telegramPost.SendKeys(OpenQA.Selenium.Keys.Control + "v");
                System.Threading.Thread.Sleep(2000);
                IWebElement sendBtn = Browser3.FindElement(By.XPath("/html/body/div[7]/div[2]/div/div/div[2]/button[2]/span"));
                sendBtn.Click();

                System.Threading.Thread.Sleep(5000);
                prnt_scrn1 = null;
                Clipboard.Clear();

                var prnt_scrn2 = TakeScreenshot(By.XPath("/html/body/div/div/div/div[2]/div[2]/div/div[2]/div[1]/div/div/div/div[4]/div/div/div/div[2]/div/div/div[2]/div[2]/div[1]/div[1]"));

                Clipboard.SetImage(prnt_scrn2);




                send_post1.SendKeys(OpenQA.Selenium.Keys.Control + "v");
                telegramPost.SendKeys(OpenQA.Selenium.Keys.Control + "v");
                System.Threading.Thread.Sleep(2000);
                sendBtn.Click();
                prnt_scrn2 = null;
                Clipboard.Clear();
                System.Threading.Thread.Sleep(5000);
                var prnt_scrn3 = TakeScreenshot(By.XPath("/html/body/div/div/div/div[2]/div[2]/div/div[2]/div[1]/div/div/div/div[4]/div/div/div/div[2]/div/div/div[2]/div[2]/div[1]/div[2]/div"));
                Clipboard.SetImage(prnt_scrn3);




                send_post1.SendKeys(OpenQA.Selenium.Keys.Control + "v");
                telegramPost.SendKeys(OpenQA.Selenium.Keys.Control + "v");
                System.Threading.Thread.Sleep(2000);
                sendBtn.Click();
                System.Threading.Thread.Sleep(5000);
                IWebElement send_postbtn3 = Browser2.FindElement(By.CssSelector("#send_post"));
                send_postbtn3.Click();
                System.Threading.Thread.Sleep(5000);
                prnt_scrn3 = null;
                Clipboard.Clear();





                GC.Collect();
                System.Threading.Thread.Sleep(40000);
                Browser.Navigate().GoToUrl("https://widgets.sir.sportradar.com/betradar/ru/head-to-head");


                //   }
                //     catch (NoSuchElementException)
                //     {
                //        goto Point;
                //     }
                //      catch ( OutOfMemoryException)
                //       {

                //       }
                //     catch(NotFoundException)
                //      {
                //        goto Point;
                //      }
            }
        }















        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}