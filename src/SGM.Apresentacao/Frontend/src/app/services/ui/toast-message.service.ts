import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { ToastMessage } from 'src/app/models/toast-message.model';

@Injectable()
export class ToastMessageService {
    public emissorDeMensagens: Subject<ToastMessage> = new Subject();

    public criarMensagem(toast: ToastMessage) {
        this.emissorDeMensagens.next(toast);
    }
}
