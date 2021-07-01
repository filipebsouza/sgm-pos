import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ModulosComponent } from './modulos/modulos.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { CidadaoComponent } from './modulos/cidadao/cidadao.component';
import { GeoComponent } from './modulos/geo/geo.component';
import { IptuComponent } from './modulos/cidadao/iptu/iptu.component';
import { ItrComponent } from './modulos/cidadao/itr/itr.component';
import { SturComponent } from './modulos/cidadao/stur/stur.component';
import { ServicosAoCidadaoComponent } from './modulos/cidadao/servicos-ao-cidadao/servicos-ao-cidadao.component';
import { ComponentsModule } from '../components/components.module';
import { AtendimentoComponent } from './modulos/cidadao/iptu/atendimento/atendimento.component';
import { AcessoPublicoComponent } from './modulos/cidadao/iptu/acesso-publico/acesso-publico.component';

@NgModule({
    declarations: [
        HomeComponent,
        LoginComponent,
        UnauthorizedComponent,
        ModulosComponent,
        CidadaoComponent,
        IptuComponent,
        AcessoPublicoComponent,
        AtendimentoComponent,
        ItrComponent,
        SturComponent,
        ServicosAoCidadaoComponent,
        GeoComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ComponentsModule
    ]
})
export class PageModule { }