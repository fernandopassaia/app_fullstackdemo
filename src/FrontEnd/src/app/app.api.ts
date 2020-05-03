// here is my API Address - All my Services should reference this file - Please Externalize it to JSON

export class AppApi {
  static MobileControlApi = "http://192.168.1.10:4001/api"; //Local-Ip HPDEVL
  //static MobileControlApi = "http://www.futuradata.com.br/acback/api"; //to the Real-Server
  static MobileControlApiResourceUser =
    AppApi.MobileControlApi + "/User";
  static MobileControlApiResourceDeviceModel =
    AppApi.MobileControlApi + "/DeviceModel";
  static MobileControlApiResourceEquipment =
    AppApi.MobileControlApi + "/Equipment";
  static MobileControlApiResourceManufacturer =
    AppApi.MobileControlApi + "/Manufacturer";
  static MobileControlApiResourceDashBoard =
    AppApi.MobileControlApi + "/DashBoard";
}
