import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, first } from 'rxjs/operators';
import { Usuario } from '../../models/usuario.model';
import { JWTTokenService } from '../security/jwt-token.service';
import { BaseApiService } from '../_base/base.api.service';

@Injectable()
export class UsuarioService extends BaseApiService<Usuario> {
    recurso = 'Usuarios'
    constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string, private _jwtService: JWTTokenService) {
        super(http, baseUrl);
    }

    logar(usuario: Usuario): Observable<void | Usuario> {
        return this.http.post<Usuario>(`${this.baseUrl}/${this.recurso}/login`, usuario)
            .pipe(
                map(retorno => {
                    this._jwtService.setToken(retorno.token);
                }),
                first()
            );
    }
}