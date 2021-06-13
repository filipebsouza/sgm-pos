import { NgModule } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { ModulosComponent } from './modulos/modulos.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

@NgModule({
    declarations: [
        LoginComponent,
        UnauthorizedComponent,
        ModulosComponent
    ]
})
export class PageModule { }