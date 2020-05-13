// here is my API Address - All my Services should reference this file - Please Externalize it to JSON

export class AppApi {
  static AppFullStackDemoApi = "http://localhost:4001/api";
  static AppFullStackDemoApiResourceUser =
    AppApi.AppFullStackDemoApi + "/User";
  static AppFullStackDemoApiResourceDeviceModel =
    AppApi.AppFullStackDemoApi + "/DeviceModel";
  static AppFullStackDemoApiResourceEquipment =
    AppApi.AppFullStackDemoApi + "/Equipment";
  static AppFullStackDemoApiResourceManufacturer =
    AppApi.AppFullStackDemoApi + "/Manufacturer";
  static AppFullStackDemoApiResourceDashBoard =
    AppApi.AppFullStackDemoApi + "/DashBoard";
}
