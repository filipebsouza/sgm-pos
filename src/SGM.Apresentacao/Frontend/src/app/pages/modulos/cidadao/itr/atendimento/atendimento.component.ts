import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ImpostoSobreImovel } from 'src/app/models/imposto-sobre-imovel.model';
import { ItrService } from 'src/app/services/apis/itr.service';
import { ToastMessageService } from 'src/app/services/ui/toast-message.service';

@Component({
    selector: 'app-cidado-itr-atendimento',
    templateUrl: './atendimento.component.html',
    styleUrls: ['./atendimento.component.css']
})
export class AtendimentoComponent implements OnInit {
    itr: ImpostoSobreImovel;
    form: FormGroup;

    constructor(
        private _fb: FormBuilder,
        private _toastMessageService: ToastMessageService,
        private _itrService: ItrService
    ) { }

    ngOnInit(): void {
        this.construirForm();
    }

    construirForm() {
        this.form = this._fb.group({
            cpf: ['', [Validators.required]],
            ano: ['', [Validators.required, Validators.maxLength(4)]]
        });
    }

    pesquisar() {
        if (this.form.valid) {
            this._itrService
                .getPorCpfDoContribuinteEAnoDeReferencia(this.form.get('cpf').value, +this.form.get('ano').value)
                .subscribe((itr: ImpostoSobreImovel) => {
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
                mensagem: 'Para realizar a pesquisa deve ser informado os campos de CPF e Ano de Referência',
                dataEHora: new Date()
            });
        }
    }

    limparTela() {
        this.form.reset();
        this.itr = null;
    }
}
