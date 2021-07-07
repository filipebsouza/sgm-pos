import { Component } from '@angular/core';
import { Usuario } from 'src/app/models/usuario.model';
import { JWTTokenService } from 'src/app/services/security/jwt-token.service';

@Component({
    selector: 'app-cidadao-itr',
    templateUrl: './itr.component.html'
})
export class ItrComponent {
    usuario: Usuario;

    constructor(private _jwtService: JWTTokenService) {
        this.usuario = this._jwtService.getUsuario();
    }
}
