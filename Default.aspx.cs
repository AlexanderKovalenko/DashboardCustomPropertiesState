using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using System;

public partial class Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        ASPxDashboard1.SetDataSourceStorage(CreateDataSourceStorage());
    }

    public DataSourceInMemoryStorage CreateDataSourceStorage() {
        DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();          
        DashboardObjectDataSource objDataSource = new DashboardObjectDataSource("ObjectDataSource", typeof(ProductSales));

        objDataSource.DataMember = "GetProductSales";
        dataSourceStorage.RegisterDataSource("objectDataSource", objDataSource.SaveToXml());

        return dataSourceStorage;
    }

    protected void ASPxDashboard1_DashboardLoading(object sender, DashboardLoadingWebEventArgs e) {
        if (e.DashboardId == "dashboard1") {
            Dashboard dashboard = new Dashboard();
            dashboard.LoadFromXDocument(e.DashboardXml);

            var stateFromXml = dashboard.CustomProperties.GetValue("DashboardState");

            dashboard.CustomProperties.SetValue("DashboardState", "{\"Items\":{\"gridDashboardItem1\":{\"MasterFilterValues\":[[2,\"Chai\"]]}}}");

            e.DashboardXml = dashboard.SaveToXDocument();
        }
    }
}