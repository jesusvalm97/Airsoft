using OKHOSTING.Core;
using OKHOSTING.ORM;
using OKHOSTING.ORM.Operations;
using OKHOSTING.ORM.UI;
using OKHOSTING.UI;
using OKHOSTING.UI.Media;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace AirsoftDeliciasChihuahua.Standard
{
    public class DataAppController : OKHOSTING.ORM.UI.DataAppController
    {
        public DataAppController (IPage page) : base(page)
        {

        }

        protected override IImageButton CreateLogo()
        {
            var logo = BaitAndSwitch.Create<IImageButton>();
            logo.LoadFromBytes(Resources.Images.airsoft);
            logo.Click += logo_Click;
            logo.Width = 250;
            logo.Height = 250;

            return logo;
        }
    }
}
