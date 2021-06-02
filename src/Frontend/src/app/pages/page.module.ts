import { NgModule } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

@NgModule({
    declarations: [
        LoginComponent,
        UnauthorizedComponent
    ]
})
export class PageModule { }