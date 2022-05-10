using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chrome.ChromeDriverExtensions;
using OpenQA.Selenium.Interactions;

namespace proxy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static void KillProcessAndChildren(int pid)
        {
            // Cannot close 'system idle process'.
            if (pid == 0)
            {
                return;
            }
            ManagementObjectSearcher searcher = new ManagementObjectSearcher
                    ("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection moc = searcher.Get();
            foreach (ManagementObject mo in moc)
            {
                KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
            }
            try
            {
                Process proc = Process.GetProcessById(pid);
                proc.Kill();
            }
            catch (ArgumentException)
            {
                // Process already exited.
            }
        }

        string line;

        //options.AddArguments("--proxy-server=http://user:password@yourProxyServer.com:8080");
       void AllMethods(string line)
        {

            multiselenium(line);
        }
        private async void button1_Click(object sender, EventArgs e)
        {

            Process[] chromeDriverProcesses2 = Process.GetProcessesByName("chromedriver");
            foreach (var chromeDriverProcess2 in chromeDriverProcesses2)
            {
                chromeDriverProcess2.Kill();
                Thread.Sleep(3000);

            }


            string[] lines = System.IO.File.ReadAllLines(@"proxy.txt");

            // Display the file contents by using a foreach loop.



            while (true)
            {

                foreach (string linee in lines)
                {


                    line = linee;

                    Thread t = new Thread(() => AllMethods(line));
                    t.Start();


                    Thread.Sleep(3000);

                    while (true)
                    {
                        int counter = System.Diagnostics.Process.GetProcessesByName("chromedriver").Length;
                        if (counter > 2)
                        {
                            Thread.Sleep(5000);

                        }
                        else
                        {
                            break;

                        }

                        //MessageBox.Show(counter.ToString());


                    }


                }

                Thread.Sleep(5000);
            }





        }
        bool kapa = false;
        private void button2_Click(object sender, EventArgs e)
        {
            kapa = true;
        }
        
public async void  multiselenium(string line)
        {

            try
            {
 IWebDriver driver;
                var options = new ChromeOptions();



                options.AddArgument("--window-position=-32000,-32000");



                //Weird = Starting from V.93, without this argument, CHROME CRASHES!



                Application.DoEvents();

                string PROXY_HOST = "";
                int PROXY_PORT = 80;
                string PROXY_USER = "";
                string PROXY_PASSWORD = "";
                // Use a tab to indent each line of the file.
                //MessageBox.Show(line);
                var a = line.Split(':');
                PROXY_HOST = a[0];
                PROXY_PORT = Convert.ToInt32(a[1]);
                PROXY_USER = a[2];
                PROXY_PASSWORD = a[3];



                options.AddHttpProxy(PROXY_HOST, PROXY_PORT, PROXY_USER, PROXY_PASSWORD);

                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;

                driver = new ChromeDriver(service, options); // or new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, options);


                Application.DoEvents();

                //driver.Navigate().GoToUrl("https://api.ipify.org/");
                //Thread.Sleep(1000);
             


                driver.Navigate().GoToUrl("https://www.pinksale.finance/#/launchpad/0x64bA9E7a0a049A31fA986a6A0b847e4085CAF7Ff?chain=BSC");
                String winHandle = driver.CurrentWindowHandle;
                driver.Manage().Window.Minimize();
                Application.DoEvents();

                Thread.Sleep(6000);
                //*[@id="root"]/section/section/main/div[2]/div[1]/div[1]/div[1]/div/article/div/div/div[2]/div/a[1]/svg
                var element = driver.FindElement(By.XPath("//*[@id='root']/section/section/main/div[2]/div[1]/div[1]/div[1]/div/article/div/div/div[2]/div/a[1]"));
                var element1 = driver.FindElement(By.XPath("//*[@id='root']/section/section/main/div[2]/div[1]/div[1]/div[1]/div/article/div/div/div[2]/div/a[2]"));
                var element2 = driver.FindElement(By.XPath("//*[@id='root']/section/section/main/div[2]/div[1]/div[1]/div[1]/div/article/div/div/div[2]/div/a[3]"));


                Application.DoEvents();


                element.Click();
                //IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                //executor.ExecuteScript("arguments[0].click();", element);
                Thread.Sleep(2000);

                driver.SwitchTo().Window(winHandle);

                Thread.Sleep(3000);
                //IJavaScriptExecutor executor1 = (IJavaScriptExecutor)driver;
                //executor1.ExecuteScript("arguments[0].click();", element1);
                element1.Click();
                Thread.Sleep(2000);
                driver.SwitchTo().Window(winHandle);
                Thread.Sleep(2000);
                //IJavaScriptExecutor executor2 = (IJavaScriptExecutor)driver;
                //executor2.ExecuteScript("arguments[0].click();", element2);
                element2.Click();
                Thread.Sleep(2000);
                driver.SwitchTo().Window(winHandle);
                Thread.Sleep(2000);
                //Actions actions = new Actions(driver);
                //actions.SendKeys(OpenQA.Selenium.Keys.End).Build().Perform();
                //Thread.Sleep(5000);

                Application.DoEvents();

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollBy(0,150)", "");
                Thread.Sleep(2000);
                IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
                js1.ExecuteScript("window.scrollBy(0,150)", "");
                Thread.Sleep(2000);
                IJavaScriptExecutor js2 = (IJavaScriptExecutor)driver;
                js2.ExecuteScript("window.scrollBy(0,150)", "");
                Thread.Sleep(2000);
                IJavaScriptExecutor js3 = (IJavaScriptExecutor)driver;
                js3.ExecuteScript("window.scrollBy(0,150)", "");
                Thread.Sleep(2000);
                Application.DoEvents();

                IJavaScriptExecutor js4 = (IJavaScriptExecutor)driver;
                js4.ExecuteScript("window.scrollBy(0,150)", "");
                Thread.Sleep(2000);
                Application.DoEvents();

                Actions actions2 = new Actions(driver);
                actions2.SendKeys(OpenQA.Selenium.Keys.PageUp).Build().Perform();
                Thread.Sleep(2000);
                Application.DoEvents();

                Actions actions3 = new Actions(driver);
                actions3.SendKeys(OpenQA.Selenium.Keys.PageUp).Build().Perform();
                Thread.Sleep(2000);
                driver.Quit();
                Thread.Sleep(1000);
                Application.DoEvents();

                Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");
                foreach (var chromeDriverProcess in chromeDriverProcesses)
                {
                    chromeDriverProcess.Kill();
                    Thread.Sleep(1000);

                }
            }
            catch
            {
                Process[] processes3 = Process.GetProcesses();
                foreach (var pro3 in Process.GetProcessesByName("chrome"))
                {
                    try
                    {
                        KillProcessAndChildren(pro3.Id);

                    }
                    catch
                    {

                    }
                }
                Process[] processes2 = Process.GetProcesses();
                foreach (var pro2 in Process.GetProcessesByName("chromedriver"))
                {
                    try
                    {
                        KillProcessAndChildren(pro2.Id);

                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(3000);

            }

        }

        //Web sayfasında gitmek
        //        driver.Navigate().GoToUrl("https://google.com");

        //        //sayfa başlığını alma
        //        string title = driver.Title();

        //        //güncel sayfa url'i alma
        //        string currentUrl = driver.Url();

        //        //sayfa kaynak kodu alma
        //        string source = driver.PageSource();

        //        //sayfayı yenileme
        //        driver.Navigate().Refresh();

        //        //Bir önceki sayfaya geri gitme
        //        driver.Navigate().Back();

        //        //Sayfayı büyütmek
        //        driver.Manage().Window.Maximize();

        ////Sayfanın ekran görüntüsü almak için
        //Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        //        screenshot.SaveAsFile(@"pathToImage", ImageFormat.Png);

        ////Frame değiştirmek
        //driver.SwitchTo().Frame(1);
        //        driver.SwitchTo().Frame("frameName");
        //        IWebElement element = this.driver.FindElement(By.Id("id"));
        //this.driver.SwitchTo().Frame(element);

        //        //Pencere değiştirmek
        //        driver.SwitcTo().Window(driver.WindowHandles.Last());
        //        driver.SwitcTo().Window(driver.WindowHandles.First());
        //        driver.SwitchTo().Window(driver.WindowHandles.LAstOrDefault());

        //        //Pop-up işlemleri
        //        IAlert alert = driver.SwitchTo().Alert();
        //        alert.Accept();
        //alert.Dismiss();
    }
}
