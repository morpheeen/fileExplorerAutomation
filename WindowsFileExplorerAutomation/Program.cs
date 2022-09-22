using System.Windows.Automation;
using System.Windows.Forms;

namespace WindowsFileExplorerAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            var ieWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children, new
 PropertyCondition(AutomationElement.ClassNameProperty, "CabinetWClass"));

            if (ieWindow == null)
                return;

            var searchBox = ieWindow.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, "SearchEditBox"));
            if (searchBox == null)
                return;
            if (!searchBox.Current.IsEnabled)
                return;
            ieWindow.SetFocus();
            var pattern= (ValuePattern)searchBox.GetCurrentPattern(ValuePattern.Pattern);
            pattern.SetValue("");
            SendKeys.SendWait("search me");
        }
    }
}
