using DotNetBrowser;
using DotNetBrowser.DOM;
using DotNetBrowser.Events;
using DotNetBrowser.WinForms;
using DotNetBrowser.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Web_Page_to_PNG_Image
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            browserView.Browser.LoadURL("http://www.google.com");

            ComplexPageLoad();

            this.Text = browserView.Browser.Title;
            toolStripAddress.Text = browserView.Browser.URL.ToString();
        }

        private void toolStripAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ComplexPageLoad();
                browserView.Browser.LoadURL(toolStripAddress.Text.ToString());
                this.Text = browserView.Browser.Title;
                toolStripAddress.Text = browserView.Browser.URL.ToString();
            }
        }

        private void toolStripUpload_Click(object sender, EventArgs e)
        {
            //Create new browser for rendering
            WinFormsBrowserView browserView1 = new WinFormsBrowserView(BrowserFactory.Create(BrowserType.LIGHTWEIGHT));
            Browser browser = browserView1.Browser;

            // #1 Set browser initial size
            browserView1.Browser.SetSize(1280, 1024);

            // #2 Load web page and wait until web page is loaded completely.
            ManualResetEvent resetEvent = new ManualResetEvent(false);
            FinishLoadingFrameHandler listener = new FinishLoadingFrameHandler((object sender1, FinishLoadingEventArgs e1) =>
            {
                if (e1.IsMainFrame)
                {
                    resetEvent.Set();
                }
            });
            browser.FinishLoadingFrameEvent += listener;
            try
            {
                browser.LoadURL(toolStripAddress.Text.ToString());
                resetEvent.WaitOne(new TimeSpan(0, 0, 45));
            }
            finally
            {
                browser.FinishLoadingFrameEvent -= listener;
            }

            // #3 Set the required document size.
            JSValue documentHeight = browserView1.Browser.ExecuteJavaScriptAndReturnValue(
                    "Math.max(document.body.scrollHeight, " +
                    "document.documentElement.scrollHeight, document.body.offsetHeight, " +
                    "document.documentElement.offsetHeight, document.body.clientHeight, " +
                    "document.documentElement.clientHeight);");
            JSValue documentWidth = browserView1.Browser.ExecuteJavaScriptAndReturnValue(
                    "Math.max(document.body.scrollWidth, " +
                    "document.documentElement.scrollWidth, document.body.offsetWidth, " +
                    "document.documentElement.offsetWidth, document.body.clientWidth, " +
                    "document.documentElement.clientWidth);");

            int scrollBarSize = 25;

            int viewWidth = (int)documentWidth.GetNumber() + scrollBarSize;
            int viewHeight = (int)documentHeight.GetNumber() + scrollBarSize;

            // #4 Register OnRepaint to get notifications
            // about paint events. We expect that web page will be completely rendered twice:
            // 1. When its size is updated.
            // 2. When HTML content is loaded and displayed.
            //ManualResetEvent waitEvent = new ManualResetEvent(false);

            DrawingView drawingView = (DrawingView)browserView1.GetImage();
            browserView1.Browser.SetSize(viewWidth, viewHeight);
            // #5 Wait until Chromium renders web page content.
            //waitEvent.WaitOne();
            // #6 Save Image of the loaded web page into a PNG file.

            //Create Save file dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG files (*.PNG)|*.PNG|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            //Choose path and name to save the file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Format name of file
                string imageFileName = saveFileDialog.FileName.ToString().Replace("%.png%", "");
                browserView1.GetImage().Save(imageFileName, ImageFormat.Png);
            }
            if (!browser.IsDisposed())
            {
                browser.Dispose();
                browserView1.Dispose();
            }
        }

        private void ComplexPageLoad()
        {
            ManualResetEvent resetEvent = new ManualResetEvent(false);
            FinishLoadingFrameHandler listener = new FinishLoadingFrameHandler((object sender, FinishLoadingEventArgs e) =>
            {
                if (e.IsMainFrame)
                {
                    resetEvent.Set();
                }
            });
            browserView.Browser.FinishLoadingFrameEvent += listener;
            try
            {
                browserView.Browser.LoadURL(toolStripAddress.Text.ToString());
                resetEvent.WaitOne(new TimeSpan(0, 0, 45));
            }
            finally
            {
                browserView.Browser.FinishLoadingFrameEvent -= listener;
            }
        }

        private void toolStripGoogleSearchToFile_Click(object sender, EventArgs e)
        {
            string allTextToFile = "";
            Browser browser = BrowserFactory.Create();
            ManualResetEvent resetEvent = new ManualResetEvent(false);
            FinishLoadingFrameHandler listener = new FinishLoadingFrameHandler((object sender1, FinishLoadingEventArgs e1) =>
            {
                if (e1.IsMainFrame)
                {
                    resetEvent.Set();
                }
            });
            browser.FinishLoadingFrameEvent += listener;
            try
            {
                browser.LoadURL("https://www.google.com.ua/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=hi");
                resetEvent.WaitOne(new TimeSpan(0, 0, 45));
            }
            finally
            {
                browser.FinishLoadingFrameEvent -= listener;
            }

            // Get Web page
            DOMDocument document = browser.GetDocument();


                        //Only for Google search results
                        int countDiv = document.GetElementsByTagName("div").Count;

                        int countH3 = 0;

                        //Quantity of h3 tags in div tags
                        for (int i = 0; i < countDiv; i++)
                        {
                            int tmpH3 = document.GetElementsByTagName("div")[i].GetElementsByTagName("h3").Count;
                            countH3 += tmpH3;
                        }

                        //For debug
                        Console.Out.WriteLine("div = " + countDiv);
                        Console.Out.WriteLine("h3 = " + countH3);

                        //Search for a tags in h3
                        for (int i = 0; i < countH3; i++)
                        {

                            string text = document.GetElementsByTagName("h3")[i].GetElementByTagName("a").InnerText.ToString();

                            //string match = Regex.Match(text, "<a.*?>(.*)</a>").Value.ToString();
                            //Console.Out.WriteLine(text);
                            //For debug
                            Console.Out.WriteLine("# " + (i + 1) + "\nname =  " + text + "\nhyperlink = " +
                                        document.GetElementsByTagName("h3")[i].GetElementByTagName("a").GetAttribute("href") + "\n");

                            //Make string for add to file
                            string textToFile = "# " + (i + 1) + Environment.NewLine +
                               "name =  " + text + Environment.NewLine +
                               "hyperlink = " + document.GetElementsByTagName("h3")[i].GetElementByTagName("a").GetAttribute("href") + Environment.NewLine;

                            allTextToFile += textToFile + Environment.NewLine;


                        }


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            //Choose path and name to save the file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Format name of file
                string txtFileName = saveFileDialog.FileName.ToString();
                //string weq = saveFileDialog.
                File.WriteAllText(txtFileName, allTextToFile);

            }  
            if (browser.IsDisposed())
            {
                browser.Dispose();
            }          
        }
    }
}
