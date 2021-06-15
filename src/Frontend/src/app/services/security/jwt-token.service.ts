import { Injectable } from '@angular/core';
import jwt_decode from 'jwt-decode';
import { LocalStorageService } from '../local-storage/local-storage.service';

@Injectable()
export class JWTTokenService {

    jwtToken: string;
    decodedToken: { [key: string]: string };

    constructor(private _localStorageService: LocalStorageService) { }

    setToken(token: string) {
        if (token) {
            this.jwtToken = token;
            this._localStorageService.set('TOKEN', token)
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
        return this.jwtToken || this._localStorageService.get('TOKEN');
    }

    getUser() {
        this.decodeToken();
        return this.decodedToken ? this.decodedToken.displayname : null;
    }

    getEmailId() {
        this.decodeToken();
        return this.decodedToken ? this.decodedToken.email : null;
    }

    getExpiryTime(): string {
        this.decodeToken();
        return this.decodedToken ? this.decodedToken.exp : null;
    }

    isTokenExpired(): boolean {
        const expiryTime = +this.getExpiryTime();
        if (expiryTime) {
            return ((1000 * expiryTime) - (new Date()).getTime()) < 5000;
        } else {
            return false;
        }
    }
}