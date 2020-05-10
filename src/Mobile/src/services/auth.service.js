import api from "../services/api";
import AsyncStorage from "@react-native-community/async-storage";
import LocalHostResolver from "../helpers/LocalHostResolver";

export default class AuthService {
  //ParametrosInternos
  constructor() {}

  async testApi() {
    console.log("Entrou no TestApi2");
    const axios = require("axios");
    try {
      return await axios.get(
        "http://www.futuradata.com.br/acback/api/User/v1/test"
      );
    } catch (error) {
      console.log("Test API Failed");
      console.error(error);
    }
  }

  async handleLogin(loginUserCommand) {
    var header = {
      "Content-Type": "application/json",
      "Access-Control-Allow-Origin": "*",
      "Access-Control-Allow-Methods": "*",
    };

    const response = await api
      .post("/User/v1/Login", loginUserCommand, header)
      .then((res) => {
        if (res.data) {
          if (res.data.Success) {
            const localHostResolver = new LocalHostResolver();
            AsyncStorage.setItem("appFullStackDemoTK", res.data.ResponseDataObj.Token);
            AsyncStorage.setItem("appFullStackDemoUN", res.data.ResponseDataObj.UserName);
            AsyncStorage.setItem("appFullStackDemoEM", res.data.ResponseDataObj.UserEmail);
            AsyncStorage.setItem("appFullStackDemoUI", res.data.ResponseDataObj.UserId);
          }
        }
      });
    return response;
  }
}