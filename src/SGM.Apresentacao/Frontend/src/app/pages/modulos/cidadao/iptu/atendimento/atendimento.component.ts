import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ImpostoSobreImovel } from 'src/app/models/imposto-sobre-imovel.model';
import { IptuService } from 'src/app/services/apis/iptu.service';
import { ToastMessageService } from 'src/app/services/ui/toast-message.service';

@Component({
    selector: 'app-cidado-iptu-atendimento',
    templateUrl: './atendimento.component.html',
    styleUrls: ['./atendimento.component.css']
})
export class AtendimentoComponent implements OnInit {
    iptu: ImpostoSobreImovel;
    form: FormGroup;

    constructor(
        private _fb: FormBuilder,
        private _toastMessageService: ToastMessageService,
        private _iptuService: IptuService
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
            this._iptuService
                .getPorCpfDoContribuinteEAnoDeReferencia(this.form.get('cpf').value, +this.form.get('ano').value)
                .subscribe((iptu: ImpostoSobreImovel) => {
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
                mensagem: 'Para realizar a pesquisa deve ser informado os campos de CPF e Ano de Referência',
                dataEHora: new Date()
            });
        }
    }

    limparTela() {
        this.form.reset();
        this.iptu = null;
    }
}
