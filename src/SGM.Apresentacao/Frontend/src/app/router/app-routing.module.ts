import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from '../guards/authorize/authorize.guard';
import { Papel } from '../models/papel.model';
import { HomeComponent } from '../pages/home/home.component';
import { LoginComponent } from '../pages/login/login.component';
import { CidadaoComponent } from '../pages/modulos/cidadao/cidadao.component';
import { GeoComponent } from '../pages/modulos/geo/geo.component';
import { ModulosComponent } from '../pages/modulos/modulos.component';
import { UnauthorizedComponent } from '../pages/unauthorized/unauthorized.component';

const ROUTES: Routes =
    [
        { path: '', component: HomeComponent, pathMatch: 'full' },
        { path: 'login', component: LoginComponent },
        { path: 'unauthorized', component: UnauthorizedComponent },
        { path: 'modulos', component: ModulosComponent, canActivate: [AuthorizeGuard],
            data: { papeis: [Papel.CONTRIBUINTE, Papel.GESTOR, Papel.SERVIDOR] } },
        { path: 'modulos/cidadao', component: CidadaoComponent, canActivate: [AuthorizeGuard],
            data: { papeis: [Papel.CONTRIBUINTE, Papel.GESTOR, Papel.SERVIDOR] } },
        { path: 'modulos/geo', component: GeoComponent, canActivate: [AuthorizeGuard],
            data: { papeis: [Papel.GESTOR, Papel.SERVIDOR] } }
    ];
@NgModule({
    imports: [RouterModule.forRoot(ROUTES, { relativeLinkResolution: 'corrected' })],
    exports: [RouterModule]
})
export class AppRoutingModule { }
