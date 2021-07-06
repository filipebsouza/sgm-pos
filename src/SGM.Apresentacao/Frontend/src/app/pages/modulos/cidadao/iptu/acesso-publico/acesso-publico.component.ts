import { Component, Input, OnInit } from '@angular/core';
import { ImpostoSobreImovel } from 'src/app/models/imposto-sobre-imovel.model';
import { Usuario } from 'src/app/models/usuario.model';
import { IptuService } from 'src/app/services/apis/iptu.service';
import { ToastMessageService } from 'src/app/services/ui/toast-message.service';

@Component({
    selector: 'app-cidado-iptu-acesso-publico',
    templateUrl: './acesso-publico.component.html'
})
export class AcessoPublicoComponent implements OnInit {
    @Input() usuario: Usuario;

    iptu: ImpostoSobreImovel;

    constructor(
        private _iptuService: IptuService,
        private _toastMessageService: ToastMessageService
    ) { }

    ngOnInit(): void {
        this.pesquisarPorUsuarioLogado();
    }

    private pesquisarPorUsuarioLogado() {
        if (!!this.usuario) {
            this._iptuService.get().subscribe((iptu: ImpostoSobreImovel) => {
                this.iptu = iptu;

                if (this.iptu === null) {
                    this._toastMessageService.criarMensagem({
                        titulo: 'Atenção',
                        mensagem: 'Não há débitos de IPTU para este ano',
                        dataEHora: new Date()
                    });
                }
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