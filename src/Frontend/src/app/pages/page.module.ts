import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { ModulosComponent } from './modulos/modulos.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

@NgModule({
    declarations: [
        LoginComponent,
        UnauthorizedComponent,
        ModulosComponent
    ],
    imports: [
        FormsModule,
        ReactiveFormsModule,
    ]
})
export class PageModule { }