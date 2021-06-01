import { Route } from '@angular/router';
import { CounterComponent } from '../counter/counter.component';
import { FetchDataComponent } from '../fetch-data/fetch-data.component';
import { HomeComponent } from '../home/home.component';
import { LoginComponent } from '../pages/login/login.component';

const ROUTES: Route[] =
    [
        { path: '', component: HomeComponent, pathMatch: 'full' },
        { path: 'counter', component: CounterComponent },
        { path: 'fetch-data', component: FetchDataComponent },
        { path: 'login', component: LoginComponent },
    ];
export default ROUTES;