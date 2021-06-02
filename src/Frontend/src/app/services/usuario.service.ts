import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../models/usuario.model';
import { BaseApiService } from './base.api.service';

@Injectable()
export class UsuarioService extends BaseApiService<Usuario> {
    recurso = 'Usuarios'
    constructor(public http: HttpClient) {
        super(http);
    }

    logar(usuario: Usuario): Observable<Usuario> {
        return this.http.post<Usuario>(`${this.apiUrl}/${this.recurso}`, usuario);
    }
}