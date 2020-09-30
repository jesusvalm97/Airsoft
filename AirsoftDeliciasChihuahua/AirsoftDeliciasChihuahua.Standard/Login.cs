using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirsoftDeliciasChihuahua.Standard
{
    public class Login : Controller
    {
        public Login (IPage page) : base(page)
        {

        }

        ITextBox txtUser = BaitAndSwitch.Create<ITextBox>();
        IPasswordTextBox txtPassword = BaitAndSwitch.Create<IPasswordTextBox>();
        protected override void OnStart()
        {
            IStack stackMain = BaitAndSwitch.Create<IStack>();

            txtUser.Placeholder = "Usuario";
            stackMain.Children.Add(txtUser);

            stackMain.Children.Add(txtPassword);

            IButton cmdLogin = BaitAndSwitch.Create<IButton>();
            cmdLogin.Text = "Iniciar Sesion";
            cmdLogin.Click += CmdLogin_Click;
            stackMain.Children.Add(cmdLogin);

            Page.Content = stackMain;
            Page.Title = "Login";
        }

        private void CmdLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Value == "root" && txtPassword.Value == "PwE5G3")
            {
                new OKHOSTING.ORM.UI.DataAppController(this.Page).Start();
            }
        }
    }
}
