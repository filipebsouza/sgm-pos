import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { InterceptorModule } from './interceptors/interceptor.module';
import { ServiceModule } from './services/service.module';
import ROUTES from './router/routes';
import { PageModule } from './pages/page.module';
import { LoginComponent } from './pages/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    InterceptorModule,
    ServiceModule,
    PageModule,
  //   RouterModule.forRoot( [
  //     { path: '', component: HomeComponent, pathMatch: 'full' },
  //     { path: 'counter', component: CounterComponent },
  //     { path: 'fetch-data', component: FetchDataComponent },
  //     { path: 'login', component: LoginComponent },
  // ])
  RouterModule.forRoot(ROUTES)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
