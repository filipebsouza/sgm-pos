import { Component } from '@angular/core';
import { Usuario } from 'src/app/models/usuario.model';
import { UsuarioService } from 'src/app/services/apis/usuario.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./longin.component.css']
})
export class LoginComponent {
    usuario: Usuario;
    constructor(private usuarioService: UsuarioService) { }

    logar() {
        this.usuarioService.logar(this.usuario)
            .subscribe(retorno => {
                this.usuario = retorno as Usuario;
            });
    }
}