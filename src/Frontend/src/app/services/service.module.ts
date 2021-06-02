import { NgModule } from '@angular/core';
import { UsuarioService } from './apis/usuario.service';
import { LocalStorageService } from './local-storage/local-storage.service';
import { JWTTokenService } from './security/jwt-token.service';

@NgModule({
    providers: [
        UsuarioService,
        JWTTokenService,
        LocalStorageService
    ]
})
export class ServiceModule { }