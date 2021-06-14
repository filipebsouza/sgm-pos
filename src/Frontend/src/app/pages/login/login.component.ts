import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Usuario } from 'src/app/models/usuario.model';
import { UsuarioService } from 'src/app/services/apis/usuario.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./longin.component.css']
})
export class LoginComponent {
    form: FormGroup;
    usuario: Usuario;
    constructor(private _fb: FormBuilder, private _usuarioService: UsuarioService) {
        this.construirForm();
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
                this.usuario = retorno as Usuario;
                this.form.reset({
                    email: '',
                    senha: ''
                })
            });
    }
}