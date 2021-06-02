import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CounterComponent } from '../counter/counter.component';
import { FetchDataComponent } from '../fetch-data/fetch-data.component';
import { HomeComponent } from '../home/home.component';
import { LoginComponent } from '../pages/login/login.component';
import { UnauthorizedComponent } from '../pages/unauthorized/unauthorized.component';

const ROUTES: Routes =
    [
        { path: '', component: HomeComponent, pathMatch: 'full' },
        { path: 'counter', component: CounterComponent },
        { path: 'fetch-data', component: FetchDataComponent },
        { path: 'login', component: LoginComponent },
        { path: 'unauthorized', component: UnauthorizedComponent }
    ];
@NgModule({
    imports: [RouterModule.forRoot(ROUTES)],
    exports: [RouterModule]
})
export class AppRoutingModule { }