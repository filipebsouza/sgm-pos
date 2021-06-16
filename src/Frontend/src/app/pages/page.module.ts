import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ModulosComponent } from './modulos/modulos.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

@NgModule({
    declarations: [
        HomeComponent,
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