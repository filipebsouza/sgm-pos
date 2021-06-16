import { Injectable } from '@angular/core';
import jwt_decode from 'jwt-decode';
import { Subject } from 'rxjs';
import { Papel } from 'src/app/models/papel.model';
import { Usuario } from 'src/app/models/usuario.model';
import { LocalStorageService } from '../local-storage/local-storage.service';

@Injectable()
export class JWTTokenService {

    jwtToken: string;
    decodedToken: { [key: string]: string };
    public emissorDeUsuarioLogado: Subject<Usuario> = new Subject();

    constructor(private _localStorageService: LocalStorageService) { }

    setToken(token: string) {
        if (token) {
            this.jwtToken = token;
            this._localStorageService.set('TOKEN', token);
            this.emissorDeUsuarioLogado.next(this.getUsuario());
        }
    }

    decodeToken() {
        if (this.jwtToken) {
            this.decodedToken = jwt_decode(this.jwtToken);
        }
    }

    getDecodeToken() {
        return jwt_decode(this.jwtToken);
    }

    getToken(): string {
        if (this.jwtToken) {
            return this.jwtToken;
        }
        this.setTokenFromLocalStorage();

        return this.jwtToken || null;
    }

    setTokenFromLocalStorage() {
        this.setToken(this._localStorageService.get('TOKEN'));
    }

    getUsuario(): Usuario {
        this.decodeToken();
        const name = this.decodedToken ? this.decodedToken.displayname : null;
        if (name) {
            return {
                email: '',
                papeis: [Papel.Contribuinte],
                nome: 'Nome qualquer',
                token: this.getToken()
            }
        }

        return null;
    }

    getEmailId() {
        this.decodeToken();
        return this.decodedToken ? this.decodedToken.email : null;
    }

    getExpiryTime(): string {
        this.decodeToken();
        return this.decodedToken ? this.decodedToken.exp : null;
    }

    tokenEstahExpirado(): boolean {
        const expiryTime = +this.getExpiryTime();
        if (expiryTime) {
            return ((1000 * expiryTime) - (new Date()).getTime()) < 5000;
        } else {
            return false;
        }
    }
}