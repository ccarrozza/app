using System.Web;

namespace app.web.infrastructure.stubs
{
    public class StubReportEngine:IDisplayInformation
    {
        public void display<ReportModel>(ReportModel item_to_display)
        {
            HttpContext.Current.Items.Add("blah",item_to_display);
            HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx");
        }
    }
}