//classe para tratamento de erros
import { Response } from '@angular/http'
import { Observable } from 'rxjs/Observable';
import { NotificationService } from './notification.service';

export class ErrorHandler {

    constructor() { }

    //recebo um erro que pode ser Response (uma resposta do angular) ou qualquer outra coisa (que irei testar no método)
    static handleError(error: Response | any) {
        let errorMessage: string

        //tratamento de erro
        if (error instanceof Response)//se error for uma response
        {
            //se o erro for uma instância de response - darei uma mensagem mais legível com código do erro (400, 404...)
            errorMessage = `Erro ${error.status} ao obter a URL ${error.url} - código erro: ${error.statusText}`
        }
        else {
            errorMessage = error.toString() //se não for uma response e eu não souber o que é, pegarei só a mensagem do erro
        }

        NotificationService.showNotification('warning', 'top', 'right', "Erro", errorMessage);
        return Observable.throw(errorMessage)
    }

}