namespace app.web.infrastructure
{
    public interface IDisplayInformation
    {
        void display<ReportModel>(ReportModel item_to_display);
    }
}