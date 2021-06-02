import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../../models/usuario.model';
import { BaseApiService } from '../_base/base.api.service';

@Injectable()
export class UsuarioService extends BaseApiService<Usuario> {
    recurso = 'Usuarios'
    constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
        super(http, baseUrl);
    }

    logar(usuario: Usuario): Observable<Usuario> {
        return this.http.post<Usuario>(`${this.baseUrl}/${this.recurso}`, usuario);
    }
}