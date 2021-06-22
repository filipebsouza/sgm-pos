import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from '../guards/authorize/authorize.guard';
import { HomeComponent } from '../pages/home/home.component';
import { LoginComponent } from '../pages/login/login.component';
import { ModulosComponent } from '../pages/modulos/modulos.component';
import { UnauthorizedComponent } from '../pages/unauthorized/unauthorized.component';

const ROUTES: Routes =
    [
        { path: '', component: HomeComponent, pathMatch: 'full' },
        { path: 'login', component: LoginComponent },
        { path: 'unauthorized', component: UnauthorizedComponent },
        { path: 'modulos', component: ModulosComponent, canActivate: [AuthorizeGuard] }
    ];
@NgModule({
    imports: [RouterModule.forRoot(ROUTES)],
    exports: [RouterModule]
})
export class AppRoutingModule { }