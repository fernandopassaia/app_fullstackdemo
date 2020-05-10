
export default class LocalHostResolver {

    constructor() {
    }

    //helper to change "localhost" to machine IP (Emulator don't accept "localhost") (will be removed on deploy)
    //because API server will never be localhost, this will be ignored (probably) during deploy. Anyway i can deactivate
    resolveLocalHost(url) {
        let strToReplace = url.toString();
        //strToReplace = strToReplace.replace('localhost', '192.168.1.7'); //put here the address of localMachine
        strToReplace = strToReplace.replace('localhost', 'http://www.futuradata.com.br/acback'); //put here the address of localMachine
        return strToReplace;
    }
}