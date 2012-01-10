namespace Domain
{
    public partial class DBSupport
    {
        public static void InitializeDB()
        {
            ProjectStatusReporting.BusinessLogic.ProjectReportDemoCtx.InitializeDB();
        }
    }
}