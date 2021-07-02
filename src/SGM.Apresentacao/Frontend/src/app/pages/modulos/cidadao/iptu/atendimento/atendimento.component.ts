import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Iptu } from 'src/app/models/iptu.model';
import { IptuService } from 'src/app/services/apis/iptu.service';
import { ToastMessageService } from 'src/app/services/ui/toast-message.service';

@Component({
    selector: 'app-cidado-iptu-atendimento',
    templateUrl: './atendimento.component.html',
    styleUrls: ['./atendimento.component.css']
})
export class AtendimentoComponent implements OnInit {
    iptu: Iptu;
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
                .getPorCpfDoContribuinteEAnoDeReferencia(+this.form.get('cpf'), +this.form.get('ano'))
                .subscribe((i: Iptu) => {
                    this.iptu = i;
                });
        } else {
            this._toastMessageService.criarMensagem({
                titulo: 'Atenção',
                mensagem: 'Para realizar a pesquisa deve ser informado os campos de CPF e Ano de Referência',
                dataEHora: new Date()
            });
        }
    }
}