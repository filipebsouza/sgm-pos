import { Component } from '@angular/core';
import { Usuario } from 'src/app/models/usuario.model';
import { JWTTokenService } from 'src/app/services/security/jwt-token.service';

@Component({
    selector: 'app-cidadao-iptu',
    templateUrl: './iptu.component.html'
})
export class IptuComponent {
    usuario: Usuario;

    constructor(private _jwtService: JWTTokenService) {
        this.usuario = this._jwtService.getUsuario();
    }


}