import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Usuario } from 'src/app/models/usuario.model';
import { UsuarioService } from 'src/app/services/apis/usuario.service';
import { JWTTokenService } from 'src/app/services/security/jwt-token.service';
import { ToastMessageService } from 'src/app/services/ui/toast-message.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    form: FormGroup;
    usuario: Usuario;

    constructor(private _fb: FormBuilder, private _usuarioService: UsuarioService,
        private _toastMessageService: ToastMessageService, private _jwtService: JWTTokenService
    ) { 
        this.construirForm();
    }

    ngOnInit(): void {
        this.usuario = this._jwtService.getUsuario();
        this._jwtService.emissorDeUsuarioLogado.subscribe(usuario => {
            this.usuario = usuario;
            if (!this.usuario) {
                this.usuario = this._jwtService.getUsuario();
            } else {
                this.form.reset();
            }
        });
    }

    construirForm() {
        this.form = this._fb.group({
            email: ['', [Validators.required, Validators.email]],
            senha: ['', [Validators.required]]
        });
    }

    logar() {
        this.usuario = this.form.value;
        this._usuarioService.logar(this.usuario)
            .subscribe(retorno => {
                if (retorno) {
                    this.usuario = retorno as Usuario;
                    this.form.reset({
                        email: '',
                        senha: ''
                    });
                    this._toastMessageService.criarMensagem({
                        titulo: 'Login',
                        mensagem: 'Usuário logado com sucesso',
                        dataEHora: new Date()
                    });
                }
            }, () => this.usuario = null);
    }
}