import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { JWTTokenService } from '../services/security/jwt-token.service';
import { ToastMessageService } from '../services/ui/toast-message.service';

@Injectable()
export class HttpConfigInterceptor implements HttpInterceptor {
  constructor(private _jwtService: JWTTokenService, private _router: Router, private _toastMessageService: ToastMessageService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this._jwtService.getToken();
    req = req.clone({
      url: req.url,
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });

    return next.handle(req)
      .pipe(
        catchError((error) => {

          let handled: boolean = false;
          const dataEHoraDoErro = new Date();
          console.error(error);
          if (error instanceof HttpErrorResponse) {
            if (error.error instanceof ErrorEvent) {
              this._toastMessageService.criarMensagem({
                titulo: 'Erro de evento',
                dataEHora: dataEHoraDoErro,
                mensagem: 'Erro de evento'
              });
            } else {
              const titulo = `${error.status} ${error.statusText}`;
              switch (error.status) {
                case 401:      //login
                  this._router.navigateByUrl("/unauthorized");
                  handled = true;
                  break;
                case 403:     //forbidden
                  this._router.navigateByUrl("/unauthorized");
                  handled = true;
                  break;
                case 404:
                  this._toastMessageService.criarMensagem({
                    titulo: titulo,
                    dataEHora: dataEHoraDoErro,
                    mensagem: 'Erro na requisição'
                  });
                case 500:
                  this._toastMessageService.criarMensagem({
                    titulo: titulo,
                    dataEHora: dataEHoraDoErro,
                    mensagem: 'Erro interno não tratado'
                  });
              }
            }
          }

          if (handled) {
            return of(error);
          } else {
            return throwError(error);
          }
        })
      );
  }
}