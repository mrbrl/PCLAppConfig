using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace PCLCoreDemo.Views
{
    public partial class HomeView : BaseView
    {
        public HomeView()
        {
            try
            {
                InitializeComponent();
            }
            catch (System.Reflection.TargetInvocationException tie)
            {
                // on tests, this will always throw an exception
                if (!tie.Message.Contains("MUST"))
                    throw;
            }
            catch (System.InvalidOperationException soe)
            {
                if (!soe.Message.Contains("MUST"))
                    throw;
            }
        }
    }
}
