import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { ToastMessage } from 'src/app/models/toast-message.model';
import { ToastMessageService } from 'src/app/services/ui/toast-message.service';

@Component({
    selector: 'app-toast-message',
    templateUrl: './toast-message.component.html',
})
export class ToastMessageComponent {
    titulo: string = 'Titulo';
    dataEHora: Date = new Date();
    mensagem: string = 'Mensagem';
    observador: Subscription = new Subscription();

    constructor(private _toasMessageService: ToastMessageService) { }

    ngOnInit() {
        this.observador = this._toasMessageService.emissorDeMensagens.subscribe(
            (toast: ToastMessage) => {
                this.titulo = toast.titulo;
                this.dataEHora = toast.dataEHora;
                this.mensagem = toast.mensagem;
            }
        );
    }
    
    ngOnDestroy() {
        this.observador.unsubscribe();
    }
}