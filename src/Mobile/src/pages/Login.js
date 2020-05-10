
import React, { useState, useEffect } from "react"; //funciona do mesmo jeito que no ReactWeb
import {
  View,
  KeyboardAvoidingView,
  Platform,
  Text,
  Button,
  TextInput,
  StyleSheet,
  TouchableOpacity,
  ImageBackground,
  Alert,
} from "react-native";
import AuthService from "../services/auth.service";
import acwp from "../assets/acwp.jpg";
import LoginUserCommand from "../commands/user/LoginUserCommand.model";
import AsyncStorage from "@react-native-community/async-storage";

export default function Login({ navigation }) {
  const [usernameOrEmail, setUsernameOrEmail] = useState("");
  const [password, setPassword] = useState("");
  const [btnLoginText, setBtnLoginText] = useState("Autenticar");
  const [btnLoginStatus, setBtnLoginStatus] = useState(false);
  const authService = new AuthService();

  useEffect(() => {
    checkTokenAndGoToDashboard();
  }, []);

  async function handleSubmit() {
    setBtnLoginStatus(true);
    setBtnLoginText("Please wait...");
    const loginUserCommand = new LoginUserCommand();
    loginUserCommand.UsernameOrEmail = usernameOrEmail;
    loginUserCommand.Password = password;

    const ret = await authService.handleLogin(loginUserCommand);
    setBtnLoginStatus(false);
    setBtnLoginText("Authenticate");

    await checkTokenAndGoToDashboard();
  }

  async function testApi() {
    const msg = await authService.testApi();
    console.log("Mensagem:", msg.data);
  }

  async function checkTokenAndGoToDashboard() {
    const token = await AsyncStorage.getItem("appFullStackDemoTK");
    if (token) {
      navigation.navigate("Dashboard");
    }
  }

  async function goToForgotPassword() {}

  return (
    <KeyboardAvoidingView
      enabled={Platform.OS === "ios"}
      behavior="padding"
      style={styles.container}
    >
      <ImageBackground source={acwp} style={styles.backgroundImage}>
        <View style={styles.form}>
          <TextInput
            style={styles.input}
            placeholder="Login"
            placeholderTextColor="#999"
            keyboardType="email-address"
            autoCapitalize="none"
            autoCorrect={false}
            value={usernameOrEmail}
            onChangeText={setUsernameOrEmail}
          />

          <TextInput
            style={styles.input}
            placeholder="Password"
            placeholderTextColor="#999"
            autoCapitalize="words"
            autoCorrect={false}
            secureTextEntry={true}
            value={password}
            onChangeText={setPassword}
          />

          <TouchableOpacity
            onPress={handleSubmit}
            style={styles.button}
            disabled={btnLoginStatus}
          >
            <Text style={styles.buttonText}>{btnLoginText}</Text>
          </TouchableOpacity>

          <Button
            title="Forgot your password?"
            onPress={testApi}
            titleStyle={{
              color: "#039BE5",
            }}
            type="clear"
          />
          <Text></Text>
          <Text style={styles.labelText}>AppFullStackDemo Opensource by FernandoPassaia</Text>
          <Text style={styles.labelText}> github.com/fernandopassaia/app_fullstackdemo </Text>
        </View>
      </ImageBackground>
    </KeyboardAvoidingView>
  );
}

const styles = StyleSheet.create({
  backgroundImage: {
    width: "100%",
    height: "100%",
    resizeMode: "cover",
    justifyContent: "center",
  },

  container: {
    flex: 1,
  },

  form: {
    alignSelf: "stretch",
    paddingHorizontal: 30,
    marginTop: 120,
  },

  label: {
    fontWeight: "bold",
    color: "#444",
    marginBottom: 8,
  },

  input: {
    borderWidth: 1,
    borderColor: "#ddd",
    backgroundColor: "#ffffff",
    paddingHorizontal: 20,
    fontSize: 16,
    color: "#444",
    height: 44,
    marginBottom: 20,
    borderRadius: 2,
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
  labelText: {
    color: "#FFF",
    fontWeight: "bold",
    fontSize: 14,
  },
});
