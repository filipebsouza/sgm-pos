import { NgModule } from '@angular/core';
import { UsuarioService } from './apis/usuario.service';
import { LocalStorageService } from './local-storage/local-storage.service';
import { JWTTokenService } from './security/jwt-token.service';
import { LoaderService } from './ui/loader.service';
import { ToastMessageService } from './ui/toast-message.service';

@NgModule({
    providers: [
        UsuarioService,
        JWTTokenService,
        LocalStorageService,
        ToastMessageService,
        LoaderService
    ]
})
export class ServiceModule { }