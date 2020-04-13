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
using OpenQA.Selenium.Chrome;
using System.IO;

using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;

namespace SongDownloader
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\Desktop\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName;
                string[] filelines = File.ReadAllLines(filename);
                ChromeDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://www.mp3juices.cc/");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                for (int a = 0; a < filelines.Length; a++)
                {
                    driver.Navigate().GoToUrl("https://www.mp3juices.cc/");
                    driver.SwitchTo().Window(driver.WindowHandles.First());
                    driver.FindElement(By.Id("query")).SendKeys(filelines[a]);
                    driver.FindElement(By.Id("button")).SendKeys(OpenQA.Selenium.Keys.Enter);
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    driver.FindElement(By.XPath("//a[@class='download 1']")).SendKeys(OpenQA.Selenium.Keys.Enter);
                    driver.FindElement(By.ClassName("url")).SendKeys(OpenQA.Selenium.Keys.Enter);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.youtube.com/playlist?list=PLolzHJ_EoFrdB-uyqS_-xp8pOLG8Nfu0Y");

            IList<IWebElement> all = driver.FindElements(By.Id("video-title"));

            String[] allText = new String[all.Count];
            int i = 0;
            foreach (IWebElement element in all)
            {
                allText[i++] = element.Text;
            }


        }
    }
}
