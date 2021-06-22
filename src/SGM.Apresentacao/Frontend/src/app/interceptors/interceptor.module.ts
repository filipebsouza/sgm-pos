import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { HttpConfigInterceptor } from './http-config.interceptor';

@NgModule({
    providers: [
        HttpConfigInterceptor, {
            provide: HTTP_INTERCEPTORS,
            useClass: HttpConfigInterceptor,
            multi: true,
        },
    ]
})
export class InterceptorModule { }