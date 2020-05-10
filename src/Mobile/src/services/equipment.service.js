import api from '../services/api';
import { Alert } from 'react-native';
import AsyncStorage from '@react-native-community/async-storage';

export default class EquipmentService {
    //ParametrosInternos
    constructor() {
    }

    async saveEquipment(createEquipmentCommand) {
        var header = {
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*',
            'Access-Control-Allow-Methods': '*'
        };
        const response = await api.post('/Equipment/v1', createEquipmentCommand, header).then(res => {
            if (res.data.ResponseDataObj) {
                AsyncStorage.setItem('appFullStackDemoEQ', res.data.ResponseDataObj.Id);                
                return res;
            }
            else {
                Alert('Falha ao Registrar o Equipamento');
            }
        });
        return response;
    }
}