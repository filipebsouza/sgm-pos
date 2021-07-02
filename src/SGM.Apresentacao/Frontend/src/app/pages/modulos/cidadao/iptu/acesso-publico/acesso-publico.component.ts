import { Component, Input, OnInit } from '@angular/core';
import { Iptu } from 'src/app/models/iptu.model';
import { Usuario } from 'src/app/models/usuario.model';
import { IptuService } from 'src/app/services/apis/iptu.service';
import { ToastMessageService } from 'src/app/services/ui/toast-message.service';

@Component({
    selector: 'app-cidado-iptu-acesso-publico',
    templateUrl: './acesso-publico.component.html'
})
export class AcessoPublicoComponent implements OnInit {
    @Input() usuario: Usuario;
    
    iptu: Iptu;
    
    constructor(
        private _iptuService: IptuService,
        private _toastMessageService: ToastMessageService
        ) { }

    ngOnInit(): void {
        this.pesquisarPorUsuarioLogado();
    }

    private pesquisarPorUsuarioLogado() {
        if (!!this.usuario) {     
            this._iptuService.get().subscribe((i: Iptu) => {
                this.iptu = i;
            });
        } else {
            this._toastMessageService.criarMensagem({
                titulo: 'Atenção',
                mensagem: 'Para consultar o IPTU, você deve estar logado no sistema',
                dataEHora: new Date()
            });
        }
    }
}