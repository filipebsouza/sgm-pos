import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Papel } from 'src/app/models/papel.model';
import { JWTTokenService } from 'src/app/services/security/jwt-token.service';

@Injectable({
    providedIn: 'root'
})
export class AuthorizeGuard implements CanActivate {
    authorized = false;
    constructor(private _jwtService: JWTTokenService, private _router: Router) {
        this.authorized = false;
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        this._validarAutenticacao();
        this._validarAutorizacao(route);

        if (!this.authorized) {
            this._router.navigate(['/unauthorized']);
        }

        return this.authorized;
    }

    private _validarAutorizacao(route: ActivatedRouteSnapshot) {
        const usuario = this._jwtService.getUsuario();
        const papeisPermitidosParaAcessarARota: Papel[] = route.data.papeis;

        if (usuario && usuario.papeis.some(papel => papeisPermitidosParaAcessarARota.includes(papel))) {
            this.authorized = true;
        } else {
            this.authorized = false;
        }
    }

    private _validarAutenticacao() {
        if (this._jwtService.getUsuario() && !this._jwtService.tokenEstahExpirado()) {
            this.authorized = true;
        } else {
            this.authorized = false;
        }
    }
}