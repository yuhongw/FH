using HtmlUI.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;


namespace HtmlUI
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ControllerManager.Instance.InitControllers();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(wb.Document!=null)
                wb.Document.InvokeScript("hello",new object[] { });
        }

        public void CalledByScript(string arg)
        {
            MessageBox.Show(arg);
        }

        public void Post(string data)
        {
            
        }

        private void wb_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.IsFile)
            {
                wb.ObjectForScripting = ControllerManager.Instance.GetByName(System.IO.Path.GetFileName(e.Url.LocalPath));
            }
        }

        private void wb_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.FileInfo file = new System.IO.FileInfo("View/Hello.html");
            wb.Navigate(file.FullName);
        }
    }
}
