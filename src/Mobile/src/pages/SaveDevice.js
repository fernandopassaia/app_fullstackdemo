//This Screen has a BASIC information and the Main-Information from the Device. The "DeviceInf" screen
//is like this one, but over there there is a lot of another more complex information.

import React, { useState, useEffect } from "react";
import {
  Text,
  Button,
  View,
  ScrollView,
  StyleSheet,
  TouchableOpacity,
} from "react-native";
import DeviceService from "../services/device.service";
import CreateEquipmentCommand from "../commands/equipment/CreateEquipmentCommand.model";
import EquipmentService from "../services/equipment.service";
import AsyncStorage from "@react-native-community/async-storage";

export default function SaveDevice({ navigation }) {
  const deviceService = new DeviceService();
  const equipService = new EquipmentService();
  
  const [equipId, setEquipId] = useState(""); //BackEnd
  const [userId, setUserId] = useState(""); //BackEnd
  const [androidId, setAndroidId] = useState("");
  const [imei1, setImei1] = useState("");
  const [imei2, setImei2] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [macAddress, setMacAddress] = useState("");
  const [apiLevel, setApiLevel] = useState(0);
  const [apiLevelDesc, setApiLevelDesc] = useState("");
  const [serialNumber, setSerialNumber] = useState("");
  const [systemName, setSystemName] = useState("");
  const [systemVersion, setSystemVersion] = useState(""); 
  const [manufacturer, setManufacturer] = useState("");
  const [model, setModel] = useState("");

  async function redirectDashboard() {
    if (equipId == "" || equipId == null) {
      await registerOnPortal();
    }
    navigation.navigate("Login");
  }

  useEffect(() => {
    //tenta pegar o Id do Portal, se não achar, ai habilita o botão pra Cadastrar
    async function loadUser() {
      setUserId(await AsyncStorage.getItem("appFullStackDemoUI"));
      setEquipId(await AsyncStorage.getItem("appFullStackDemoEQ"));      
    }

    loadUser();

    deviceService.getImei(function (err, res) {
      if (err) {
        console.log("Falha ao obter FreeDiskStorage na Function: ", err);
      }
      if (res[0]) {
        setImei1(res[0]);
      } else {
        setImei1("");
      }
      if (res[1]) {
        setImei2(res[1]);
      } else {
        setImei2("");
      }
    });

    deviceService.getMacAddress(function (err, res) {
      if (err) {
        console.log("Falha ao obter MacAddress na Function: ", err);
      }
      setMacAddress(res);
    });
    
    deviceService.getPhoneNumber(function (err, res) {
      if (err) {
        console.log("Falha ao obter Phone Number na Function: ", err);
      }
      setPhoneNumber(res);
    });    

    deviceService.getApiLevel(function (err, res) {
      if (err) {
        console.log("Falha ao obter ApiLevel na Function: ", err);
      }
      setApiLevel(res);
      setApiLevelDesc(deviceService.getApiLevelDesc(res));
    });

    deviceService.getAndroidId(function (err, res) {
      if (err) {
        console.log("Falha ao obter AndroidId na Function: ", err);
      }
      setAndroidId(res);
    });    

    deviceService.getManufacturer(function (err, res) {
      if (err) {
        console.log("Falha ao obter Manufacturer na Function: ", err);
      }
      setManufacturer(res);
    });

    setModel(deviceService.getModel());

    deviceService.getSerialNumber(function (err, res) {
      if (err) {
        console.log("Falha ao obter Serial Number na Function: ", err);
      }
      setSerialNumber(res);
    });
    
    setSystemName(deviceService.getSystemName());
    setSystemVersion(deviceService.getSystemVersion());
    }, []);
  

  async function redirectToDeviceInfo() {
    navigation.navigate("DeviceInf");
  }

  async function registerOnPortal() {
    const createEquipmentCommand = new CreateEquipmentCommand();
    createEquipmentCommand.AndroidId = androidId.toString();
    createEquipmentCommand.Imei1 = imei1.toString();
    createEquipmentCommand.Imei2 = imei2.toString();
    createEquipmentCommand.PhoneNumber = phoneNumber.toString();
    createEquipmentCommand.MacAddress = macAddress.toString();
    createEquipmentCommand.ApiLevel = apiLevel.toString();
    createEquipmentCommand.ApiLevelDesc = apiLevelDesc.toString();
    createEquipmentCommand.SerialNumber = serialNumber.toString();
    createEquipmentCommand.SystemName = systemName.toString();
    createEquipmentCommand.SystemVersion = systemVersion.toString();
    createEquipmentCommand.Manufacturer = manufacturer.toString();
    createEquipmentCommand.Model = model.toString();
    createEquipmentCommand.UserId = userId.toString();

    const ret = await equipService.saveEquipment(createEquipmentCommand);
    if (ret.data) {
      setEquipId(ret.data.ResponseDataObj.Id);
      AsyncStorage.setItem("appFullStackDemoEQ", equipId);
    }
  }

  return (
    <View style={styles.form}>
      <ScrollView>        
        <Button title="Register Device" onPress={registerOnPortal} />
        <Text> </Text>
        <TouchableOpacity onPress={redirectDashboard} style={styles.button}>
          <Text style={styles.buttonText}>Go Back</Text>
        </TouchableOpacity>

        <Text> </Text>
        <Text style={styles.title}>Equipment Id: {equipId}</Text>
        <Text style={styles.title}>Owner: {userId}</Text>
        <Text style={styles.title}>Android Id: {androidId}</Text>
        <Text style={styles.title}>
          Android Version: <Text style={styles.bold}>{apiLevel}(</Text>
          {apiLevelDesc})
        </Text>
        <Text style={styles.title}>Serial Number: {serialNumber}</Text>
        <Text style={styles.title}>Phone Number: {phoneNumber}</Text>        
        <Text style={styles.title}>IMEI1: {imei1}</Text>
        <Text style={styles.title}>IMEI2: {imei2}</Text>
        <Text style={styles.title}>Mac Address: {macAddress}</Text>
        <Text style={styles.title}>Manufacturer: {manufacturer}</Text>
        <Text style={styles.title}>Model: {model}</Text>
        <Text style={styles.title}>System Name: {systemName}</Text>
        <Text style={styles.title}>System Version: {systemVersion}</Text>
        <Text> </Text>
      </ScrollView>
    </View>
  );
}

const styles = StyleSheet.create({
  bold: {
    fontWeight: "bold",
  },

  button: {
    height: 42,
    backgroundColor: "#f05a5b",
    justifyContent: "center",
    alignItems: "center",
    borderRadius: 2,
  },

  buttonText: {
    color: "#FFF",
    fontWeight: "bold",
    fontSize: 16,
  },

  container: {
    flex: 1,
  },

  form: {
    alignSelf: "stretch",
    paddingHorizontal: 30,
    marginTop: 15,
  },

  hairline: {
    backgroundColor: "#A2A2A2",
    height: 2,
    width: 165,
  },

  logo: {
    height: 32,
    resizeMode: "contain",
    alignSelf: "center",
    marginTop: 30,
  },
  label: {
    fontWeight: "bold",
    color: "#444",
    marginBottom: 8,
  },
  input: {
    borderWidth: 1,
    borderColor: "#ddd",
    paddingHorizontal: 20,
    fontSize: 14,
    color: "#444",
    marginBottom: 15,
    borderRadius: 2,
  },

  title: {
    fontSize: 14,
    color: "#444",
    paddingHorizontal: 20,
    marginBottom: 15,
  },
});