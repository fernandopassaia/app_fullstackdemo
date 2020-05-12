import React, {
  useState,
  useEffect
} from "react";
import {
  Button,
  View,
  Text,
  Image,
  StyleSheet,
  PermissionsAndroid,
} from "react-native";
import fullstackicon from "../assets/fullstackicon.png";
import AsyncStorage from "@react-native-community/async-storage";

export default function Dashboard({
  navigation
}) {
  const [token, setToken] = useState("");
  const [userName, setUserName] = useState("");
  const [userEmail, setUserEmail] = useState("");
  const [userId, setUserId] = useState("");
  const [equipId, setEquipId] = useState(""); //BackEnd

  useEffect(() => {
    async function loadUser() {
      setToken(await AsyncStorage.getItem("appFullStackDemoTK"));
      setUserName(await AsyncStorage.getItem("appFullStackDemoUN"));
      setUserEmail(await AsyncStorage.getItem("appFullStackDemoEM"));
      setUserId(await AsyncStorage.getItem("appFullStackDemoUI"));
      setEquipId(await AsyncStorage.getItem("appFullStackDemoEQ"));
      await requestReadPhoneStatePermission();
    }
    loadUser();
  }, []);

  async function requisitarPermissoesNavegarSaveDevice() {
    await requestReadPhoneStatePermission();
    navigation.navigate("SaveDevice");
  }

  async function requestReadPhoneStatePermission() {
    try {
      const granted = await PermissionsAndroid.request(
        PermissionsAndroid.PERMISSIONS.READ_PHONE_STATE, {
          title: "Phone Number",
          message: "Needs permission to get your phone number.",
          buttonNeutral: "After",
          buttonNegative: "Cancel",
          buttonPositive: "OK",
        }
      );
      if (granted === PermissionsAndroid.RESULTS.GRANTED) {
        console.log("You can use the Read_Phone_State");
      } else {
        console.log("Read_Phone_State permission denied");
      }
    } catch (err) {
      console.warn(err);
    }
  }

  return (
    <View style={styles.form}>
      <Image
        style={styles.thumbnail}
        source={fullstackicon}
      />
      <Text> </Text>
      <Text>User: {userName}</Text>      
      <Text>Email: {userEmail}</Text>
      <Text>UserId: {userId} </Text>
      <Text>EquipId: {equipId}</Text>
      <Text> </Text>

      <Button
        title="Device Info & Registration"
        onPress={requisitarPermissoesNavegarSaveDevice}
        titleStyle={{
          color: "#d6621a",
        }}
        type="clear"
      />
      <Text></Text>
    </View>
  );
}

const styles = StyleSheet.create({
  bold: {
    fontWeight: "bold",
  },
  form: {
    alignSelf: "stretch",
    paddingHorizontal: 30,
    marginTop: 30,
  },
  thumbnail: {
    width: 220,
    height: 160,
    resizeMode: "cover",
    borderRadius: 2,
    alignContent: "center",
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
});