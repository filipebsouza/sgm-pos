import { BrowserModule } from '@angular/platform-browser';
import { LOCALE_ID, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './pages/home/home.component';
import { InterceptorModule } from './interceptors/interceptor.module';
import { ServiceModule } from './services/service.module';
import { PageModule } from './pages/page.module';
import { AppRoutingModule } from './router/app-routing.module';
import { environment } from 'src/environments/environment';
import { registerLocaleData } from '@angular/common';
import localeBr from '@angular/common/locales/pt';
import { ToastMessageComponent } from './components/toast-message/toast-message.component';

registerLocaleData(localeBr, 'pt');

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ToastMessageComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    InterceptorModule,
    ServiceModule,
    PageModule,
    AppRoutingModule
  ],
  providers: [
    { provide: 'BASE_URL', useValue: environment.apiUrl },
    { provide: LOCALE_ID, useValue: 'pt' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
