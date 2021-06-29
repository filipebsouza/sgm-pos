import { BrowserModule } from '@angular/platform-browser';
import { LOCALE_ID, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { InterceptorModule } from './interceptors/interceptor.module';
import { ServiceModule } from './services/service.module';
import { PageModule } from './pages/page.module';
import { AppRoutingModule } from './router/app-routing.module';
import { environment } from 'src/environments/environment';
import { CommonModule, registerLocaleData } from '@angular/common';
import localeBr from '@angular/common/locales/pt';
import { ComponentsModule } from './components/components.module';

registerLocaleData(localeBr, 'pt');

@NgModule({
  declarations: [
    AppComponent
  ],
  exports: [
    ComponentsModule,
    PageModule,
    InterceptorModule,
    ServiceModule,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InterceptorModule,
    ServiceModule,
    PageModule,
    ComponentsModule,
    AppRoutingModule
  ],
  providers: [
    { provide: 'BASE_URL', useValue: environment.apiUrl },
    { provide: LOCALE_ID, useValue: 'pt' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
