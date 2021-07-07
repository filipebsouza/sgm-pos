import { Component, Input, OnInit } from '@angular/core';
import { ImpostoSobreImovel } from 'src/app/models/imposto-sobre-imovel.model';
import { Usuario } from 'src/app/models/usuario.model';
import { ItrService } from 'src/app/services/apis/itr.service';
import { ToastMessageService } from 'src/app/services/ui/toast-message.service';

@Component({
    selector: 'app-cidado-itr-acesso-publico',
    templateUrl: './acesso-publico.component.html'
})
export class AcessoPublicoComponent implements OnInit {
    @Input() usuario: Usuario;

    itr: ImpostoSobreImovel;

    constructor(
        private _itrService: ItrService,
        private _toastMessageService: ToastMessageService
    ) { }

    ngOnInit(): void {
        this.pesquisarPorUsuarioLogado();
    }

    private pesquisarPorUsuarioLogado() {
        if (!!this.usuario) {
            this._itrService.get().subscribe((itr: ImpostoSobreImovel) => {
                this.itr = itr;

                if (this.itr === null) {
                    this._toastMessageService.criarMensagem({
                        titulo: 'Atenção',
                        mensagem: 'Não há débitos de ITR para este ano',
                        dataEHora: new Date()
                    });
                }
            });
        } else {
            this._toastMessageService.criarMensagem({
                titulo: 'Atenção',
                mensagem: 'Para consultar o ITR, você deve estar logado no sistema',
                dataEHora: new Date()
            });
        }
    }
}
