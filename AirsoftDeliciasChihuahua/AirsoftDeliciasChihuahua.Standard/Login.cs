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
        ILabel lblWarning = BaitAndSwitch.Create<ILabel>();
        protected override void OnStart()
        {
            IStack stackMain = BaitAndSwitch.Create<IStack>();

            ILabel lblUser = BaitAndSwitch.Create<ILabel>();
            lblUser.Text = "Usuario";
            stackMain.Children.Add(lblUser);
            
            stackMain.Children.Add(txtUser);

            ILabel lblPassword = BaitAndSwitch.Create<ILabel>();
            lblPassword.Text = "Contraseña";
            stackMain.Children.Add(lblPassword);

            stackMain.Children.Add(txtPassword);

            lblWarning.Text = " ";
            lblWarning.Visible = false;
            stackMain.Children.Add(lblWarning);

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
                lblWarning.Visible = false;
                new DataAppController(this.Page).Start();
            }
            else
            {
                lblWarning.Text = "Uno de los datos están mal";
                lblWarning.Visible = true;
            }
        }
    }
}
