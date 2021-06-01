import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario } from '../models/usuario.model';
import { BaseApiService } from './base.api.service';

@Injectable()
export class UsuarioService extends BaseApiService<Usuario> {
    recurso = 'Usuarios'
    constructor(public http: HttpClient) {
        super(http);
    }
}