using System;
using System.Collections.Generic;
using System.Text;

namespace AirsoftDeliciasChihuahua.Standard
{
    public class App : OKHOSTING.UI.App
    {
        protected override void StartController(OKHOSTING.UI.Controller controller)
        {
            base.StartController(controller);

            //OKHOSTING.UI.CSS.Style style = new OKHOSTING.UI.CSS.Style();
            //var assembly = typeof(App).Assembly;
            //var resourceName = "RealWellness.UI.Style.css";

            //using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    string css = reader.ReadToEnd();
            //    style.Parse(css);
            //}



        }
    }
}
