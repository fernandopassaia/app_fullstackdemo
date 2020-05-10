import DeviceInfo from 'react-native-device-info';
import IMEI from 'react-native-imei';

export default class DeviceService {
    //ParametrosInternos
    constructor() {
    }

    callAllMethods() {
        this.getAndroidId();
        this.getApplicationName();
        this.getApiLevel();
        this.getBaseOs();
        this.getBatteryLevel();
        this.getBrand();
        this.getBuildNumber();
        this.getCarrier();
        this.getCodename();
        this.getDevice();
        this.getDeviceId();
        this.getDeviceName();
        this.getDeviceToken();
        this.getFreeDiskStorage();
        this.getImei();
        this.getHardware();
        this.getHost();
        this.getIpAddress();
        this.getMacAddress();
        this.getManufacturer();
        this.getMaxMemory();
        this.getModel();
        this.getPhoneNumber();
        this.getPowerState();
        this.getProduct();
        this.getReadableVersion();
        this.getSerialNumber();
        this.getSecurityPatch();
        this.getSystemName();
        this.getSystemVersion();
        this.getBuildId();
        this.getType();
        this.getTotalDiskCapacity();
        this.getTotalMemory();
        this.getUniqueId();
        this.getUsedMemory();
        this.getUserAgent();
        this.getVersion();
        this.isAirplaneMode();
        this.isBatteryCharging();
        this.isEmulator();
        this.isTablet();
        this.isLandscape();
        this.getDeviceType();
        this.getSystemAvailableFeatures();
        this.isLocationEnabled();
        this.isHeadphonesConnected();
        console.log();
        console.log('---------------------------------');
        console.log();
    }

    //NOTA FERNANDO: No DeviceInf eu chamo essa função tanto via Promisse, quanto via Function
    getAndroidId(callback) {
        DeviceInfo.getAndroidId().then(androidId => {
            //nota: aqui poderia retornar algo como data == { valorA: 2, valorB: 3}
            ////console.log('getAndroidId: ', androidId);
            return callback(null, androidId);
        });
    }

    getApplicationName(callback) {
        let appName = DeviceInfo.getApplicationName();
        ////console.log('getBrand: ', brand);
        return appName;
    }

    getApiLevel(callback) {
        DeviceInfo.getApiLevel().then(apiLevel => {
            //nota: aqui poderia retornar algo como data == { valorA: 2, valorB: 3}
            ////console.log('getApiLevel: ', apiLevel);
            return callback(null, apiLevel);
        });
    }

    getApiLevelDesc(apiLevel) {
        if (apiLevel == 29) {
            return 'Android 10'
        }
        if (apiLevel == 28) {
            return 'Android 9'
        }
        if (apiLevel == 27) {
            return 'Android 8.1'
        }
        if (apiLevel == 26) {
            return 'Android 8.0'
        }
        if (apiLevel == 25) {
            return 'Android 7.1'
        }
        if (apiLevel == 24) {
            return 'Android 7.0'
        }
        if (apiLevel == 23) {
            return 'Android 6.0'
        }
        if (apiLevel == 22) {
            return 'Android 5.1'
        }
        if (apiLevel == 21) {
            return 'Android 5.0'
        }
        if (apiLevel == 20) {
            return 'Android 4.4'
        }
        if (apiLevel == 19) {
            return 'Android 4.4'
        }
        if (apiLevel == 18) {
            return 'Android 4.3'
        }
        if (apiLevel == 17) {
            return 'Android 4.2'
        }
        if (apiLevel == 16) {
            return 'Android 4.1'
        }
        if (apiLevel == 15) {
            return 'Android 4.0.4'
        }
        if (apiLevel == 14) {
            return 'Android 4.0.2'
        }
        if (apiLevel == 13) {
            return 'Android 3.2'
        }
        if (apiLevel == 12) {
            return 'Android 3.1'
        }
        if (apiLevel == 11) {
            return 'Android 3.0'
        }
        if (apiLevel == 10) {
            return 'Android 2.3.4'
        }
        if (apiLevel == 9) {
            return 'Android 2.3.2'
        }
        if (apiLevel == 8) {
            return 'Android 2.2'
        }
        if (apiLevel == 7) {
            return 'Android 2.1'
        }
        if (apiLevel == 6) {
            return 'Android 2.0.1'
        }
        if (apiLevel == 5) {
            return 'Android 2.0'
        }
        if (apiLevel == 4) {
            return 'Android 1.6'
        }
        if (apiLevel == 3) {
            return 'Android 1.5'
        }
        if (apiLevel == 2) {
            return 'Android 1.1'
        }
        if (apiLevel == 1) {
            return 'Android 1.0'
        }

        return '';
    }

    getBaseOs(callback) {
        DeviceInfo.getBaseOs().then(baseOs => {
            // "Windows", "Android" etc
            //console.log('getBaseOs: ', baseOs);
            return callback(null, baseOs);
        });
    }

    getBatteryLevel(callback) {
        DeviceInfo.getBatteryLevel().then(batteryLevel => {
            // 0.759999
            //console.log('getBatteryLevel: ', batteryLevel);
            return callback(null, batteryLevel);
        });
    }

    getBrand() {
        let brand = DeviceInfo.getBrand();
        ////console.log('getBrand: ', brand);
        return brand;
    }

    getBuildNumber() {
        let buildNumber = DeviceInfo.getBuildNumber();
        //console.log('getBuildNumber: ', buildNumber);
        return buildNumber;
    }

    getBundleId() {
        let bundleId = DeviceInfo.getBundleId();
        //console.log('getBuildNumber: ', buildNumber);
        return bundleId;
    }

    getCarrier(callback) {
        DeviceInfo.getCarrier().then(carrier => {
            // "SOFTBANK"
            //console.log('getCarrier: ', carrier);
            return callback(null, carrier);
        });
    }

    getCodename(callback) {
        DeviceInfo.getCodename().then(codename => {
            //console.log('getCodename: ', codename);
            // "REL"
            return callback(null, codename);
        });
    }

    getDevice(callback) {
        DeviceInfo.getDevice().then(device => {
            //console.log('getDevice: ', device);
            // "walleye"
            return callback(null, device);
        });
    }

    getDeviceId() {
        let deviceId = DeviceInfo.getDeviceId();
        //console.log('getDeviceId: ', deviceId);
        // iOS: "iPhone7,2"
        // Android: "goldfish"
        // Windows: ?
        return deviceId;
    }

    getDeviceName(callback) {
        DeviceInfo.getDeviceName().then(deviceName => {
            //console.log('getDeviceName: ', deviceName);
            // iOS: "Becca's iPhone 6"
            // Android: ?
            // Windows: ?
            return callback(null, deviceName);
        });
    }

    getDeviceToken(callback) {
        DeviceInfo.getDeviceToken().then(deviceToken => {
            //console.log('getDeviceToken: ', deviceToken);
            // iOS: "a2Jqsd0kanz..."
            return callback(null, deviceToken);
        });
    }

    getFreeDiskStorage(callback) {
        DeviceInfo.getFreeDiskStorage().then(freeDiskStorage => {
            //console.log('getFreeDiskStorage: ', freeDiskStorage);
            // Android: 17179869184
            // iOS: 17179869184
            return callback(null, freeDiskStorage);
        });
    }

    getImei(callback) {
        var imei = IMEI.getImei().then(imei => {
            return callback(null, imei);
        });
    }

    getHardware(callback) {
        DeviceInfo.getHardware().then(hardware => {
            //console.log('getHardware: ', hardware);
            // "walleye"
            return callback(null, hardware);
        });
    }

    getHost(callback) {
        DeviceInfo.getHost().then(host => {
            //console.log('getHost: ', host);
            // "wprd10.hot.corp.google.com"
            return callback(null, host);
        });
    }

    getIpAddress(callback) {
        // DeviceInfo.getIpAddress().then(ip => {
        //     //console.log('getIpAddress: ', ip);
        //     // "92.168.32.44"
        //     return callback(null, apiLevel);
        // });
        //needs android.permission.ACCESS_WIFI_STATE
    }

    getMacAddress(callback) {
        DeviceInfo.getMacAddress().then(mac => {
            //     //console.log('getMacAddress: ', mac);
            //     // "E5:12:D8:E5:69:97"
            return callback(null, mac);
        });
        //needs android.permission.ACCESS_WIFI_STATE
    }

    getManufacturer(callback) {
        DeviceInfo.getManufacturer().then(manufacturer => {
            //console.log('getManufacturer: ', manufacturer);
            // iOS: "Apple"
            // Android: "Google"
            // Windows: ?
            return callback(null, manufacturer);
        });
    }

    getMaxMemory(callback) {
        DeviceInfo.getMaxMemory().then(maxMemory => {
            //console.log('getMaxMemory: ', maxMemory);
            // 402653183
            return callback(null, maxMemory);
        });
    }

    getModel() {
        let model = DeviceInfo.getModel();
        //console.log('getModel: ', model);
        // iOS: ?
        // Android: ?
        // Windows: ?
        return model;
    }

    getPhoneNumber(callback) {
        DeviceInfo.getPhoneNumber().then(phoneNumber => {
            //console.log('getPhoneNumber: ', phoneNumber);
            // Android: null return: no permission, empty string: unprogrammed or empty SIM1, e.g. "+15555215558": normal return value
            return callback(null, phoneNumber);
        });
    }

    getPowerState(callback) {
        DeviceInfo.getPowerState().then(state => {
            //console.log('getPowerState: ', state);
            //   batteryLevel: 0.759999,
            //   batteryState: 'unplugged',
            //   lowPowerMode: false,
            return callback(null, state);
        });
    }

    getProduct(callback) {
        DeviceInfo.getProduct().then(product => {
            //console.log('getProduct: ', product);
            // "walleye"
            return callback(null, product);
        });
    }

    getReadableVersion() {
        let readableVersion = DeviceInfo.getReadableVersion();
        //console.log('getReadableVersion: ', readableVersion);
        // iOS: 1.0.1.32
        // Android: 1.0.1.234
        // Windows: ?
        return readableVersion;
    }

    getSerialNumber(callback) {
        DeviceInfo.getSerialNumber().then(serialNumber => {
            //console.log('getSerialNumber: ', serialNumber);
            // iOS: unknown
            // Android: ? (maybe a serial number, if your app is privileged)
            // Windows: unknown
            return callback(null, serialNumber);
        });
    }

    getSecurityPatch(callback) {
        DeviceInfo.getSecurityPatch().then(securityPatch => {
            //console.log('getSecurityPatch: ', securityPatch);
            // "2018-07-05"
            return callback(null, securityPatch);
        });
    }

    getSystemName() {
        let systemName = DeviceInfo.getSystemName();
        //console.log('getSystemName: ', systemName);
        // iOS: "iOS" on newer iOS devices "iPhone OS" on older devices, including older iPad's.
        // Android: "Android"
        // Windows: ?
        return systemName;
    }

    getSystemVersion() {
        let systemVersion = DeviceInfo.getSystemVersion();
        //console.log('getSystemVersion: ', systemVersion);
        // iOS: "11.0"
        // Android: "7.1.1"
        // Windows: ?
        return systemVersion;
    }

    getBuildId(callback) {
        DeviceInfo.getBuildId().then(buildId => {
            //console.log('getBuildId: ', buildId);
            // iOS: "12A269"
            // tvOS: not available
            // Android: "13D15"
            // Windows: not available
            return callback(null, buildId);
        });
    }

    getType(callback) {
        DeviceInfo.getType().then(type => {
            //console.log('getType: ', type);
            // "user", "eng"
            return callback(null, type);
        });
    }

    getTotalDiskCapacity(callback) {
        DeviceInfo.getTotalDiskCapacity().then(capacity => {
            //console.log('getTotalDiskCapacity: ', capacity);
            // Android: 17179869184
            // iOS: 17179869184
            return callback(null, capacity);
        });
    }

    getTotalMemory(callback) {
        DeviceInfo.getTotalMemory().then(totalMemory => {
            //console.log('getTotalMemory: ', totalMemory);
            // 1995018240
            return callback(null, totalMemory);
        });
    }

    getUniqueId() {
        let uniqueId = DeviceInfo.getUniqueId();
        //console.log('getUniqueId: ', uniqueId);
        // iOS: "FCDBD8EF-62FC-4ECB-B2F5-92C9E79AC7F9"
        // Android: "dd96dec43fb81c97"
        // Windows: ?
        return uniqueId;
    }

    getUsedMemory(callback) {
        DeviceInfo.getUsedMemory().then(usedMemory => {
            //console.log('usedMemory: ', usedMemory);
            // 23452345
            return callback(null, usedMemory);
        });
    }

    getUserAgent(callback) {
        DeviceInfo.getUserAgent().then(userAgent => {
            //console.log('userAgent: ', userAgent);
            // iOS: "Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143"
            // tvOS: not available
            // Android: ?
            // Windows: ?
            return callback(null, userAgent);
        });
    }

    getVersion() {
        let version = DeviceInfo.getVersion();
        //console.log('version: ', version);
        // iOS: "1.0"
        // Android: "1.0"
        // Windows: ?
        return version;
    }

    isAirplaneMode(callback) {
        DeviceInfo.isAirplaneMode().then(airplaneModeOn => {
            //console.log('airplaneModeOn: ', airplaneModeOn);
            // false
            return callback(null, airplaneModeOn);
        });
    }

    isBatteryCharging(callback) {
        DeviceInfo.isBatteryCharging().then(isCharging => {
            //console.log('isCharging: ', isCharging);
            // true or false
            return callback(null, isCharging);
        });
    }

    isEmulator(callback) {
        DeviceInfo.isEmulator().then(isEmulator => {
            //console.log('isEmulator: ', isEmulator);
            // false
            return callback(null, isEmulator);
        });
    }

    isTablet() {
        let isTablet = DeviceInfo.isTablet();
        //console.log('isTablet: ', isTablet);
        // true
        return isTablet;
    }

    isLandscape(callback) {
        DeviceInfo.isLandscape().then(isLandscape => {
            //console.log('isLandscape: ', isLandscape);
            // true
            return callback(null, isLandscape);
        });
    }

    getDeviceType() {
        let type = DeviceInfo.getDeviceType();
        //console.log(': ', type);
        // 'Handset', 'Tablet', 'Tv'
        return type;
    }

    getSystemAvailableFeatures(callback) {
        DeviceInfo.getSystemAvailableFeatures().then(features => {
            //console.log('getDeviceType: ', features);
            // ["android.software.backup", "android.hardware.screen.landscape", "android.hardware.wifi", ...]
            return '';
            return callback(null, features); //its returning too much info, let see it in future
        });
    }

    isLocationEnabled(callback) {
        DeviceInfo.isLocationEnabled().then(enabled => {
            //console.log('isLocationEnabled: ', enabled);
            // true or false
            return callback(null, enabled);
        });
    }

    isHeadphonesConnected(callback) {
        DeviceInfo.isHeadphonesConnected().then(enabled => {
            //console.log('isHeadphonesConnected: ', enabled);
            // true or false
            return callback(null, enabled);
        })
    }

    formatBytes(x) {
        const units = ['bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'];
        //console.log('x:', x);
        if (x === 1) return '1 byte';
        let l = 0, n = parseInt(x, 10) || 0;
        while (n >= 1024 && ++l) {
            n = n / 1024;
        }
        //include a decimal point and a tenths-place digit if presenting 
        //less than ten of KB or greater units
        //console.log('return:', n.toFixed(n < 10 && l > 0 ? 1 : 0) + ' ' + units[l]);
        return (n.toFixed(n < 10 && l > 0 ? 1 : 0) + ' ' + units[l]);
    }
}