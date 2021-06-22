import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { JWTTokenService } from 'src/app/services/security/jwt-token.service';

@Injectable({
    providedIn: 'root'
})
export class AuthorizeGuard implements CanActivate {
    constructor(private _jwtService: JWTTokenService, private _router: Router) {
    }

    canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): boolean {
        if (this._jwtService.getUsuario() && !this._jwtService.tokenEstahExpirado()) {
            return true;
        }

        this._router.navigate(['/unauthorized']);
        return false;
    }
}