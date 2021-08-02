import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/models/usuario.model';
import { JWTTokenService } from 'src/app/services/security/jwt-token.service';

@Component({
    selector: 'app-unauthorized',
    templateUrl: './unauthorized.component.html'
})
export class UnauthorizedComponent implements OnInit {
    usuario: Usuario;

    constructor(private _jwtService: JWTTokenService,
        private router: Router) { }

    ngOnInit(): void {
        this._jwtService.emissorDeUsuarioLogado.subscribe(usuario => this.usuario = usuario);
        if (!this.usuario) {
            this.usuario = this._jwtService.getUsuario();
        }
    }

    irParaTelaDeLogin() {
        this.router.navigate(['/login']);
    }
}
