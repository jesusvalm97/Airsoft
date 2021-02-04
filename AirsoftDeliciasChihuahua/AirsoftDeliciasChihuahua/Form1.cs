using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirsoftDeliciasChihuahua
{
    public partial class Form1 : OKHOSTING.UI.Net4.WinForms.Page
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            var config = new AirsoftDeliciasChihuahua.Standard.Config();
            config.Start();

            App = new AirsoftDeliciasChihuahua.Standard.App();
            App.MainPage = this;

            //new AirsoftDeliciasChihuahua.Standard.Login(this).Start();
            new AirsoftDeliciasChihuahua.Standard.Home(this).Start();
        }
    }
}
