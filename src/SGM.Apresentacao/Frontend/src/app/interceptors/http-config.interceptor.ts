import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of, throwError } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';
import { JWTTokenService } from '../services/security/jwt-token.service';
import { LoaderService } from '../services/ui/loader.service';
import { ToastMessageService } from '../services/ui/toast-message.service';

@Injectable()
export class HttpConfigInterceptor implements HttpInterceptor {
  private totalRequests = 0;

  constructor(private _jwtService: JWTTokenService, private _router: Router,
    private _toastMessageService: ToastMessageService, private _loaderService: LoaderService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.totalRequests++;
    this._loaderService.setLoading(true);

    const token = this._jwtService.getToken();
    req = req.clone({
      url: req.url,
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });

    return next.handle(req)
      .pipe(
        catchError((error) => this.tratarErroNaRequisicao(error)),
        finalize(() => this.limparLoader())
      );
  }

  limparLoader() {
    this.totalRequests--;
    if (this.totalRequests === 0) {
      this._loaderService.setLoading(false);
    }
  }

  tratarErroNaRequisicao(error: any) {
    if (error) {
      this._loaderService.setLoading(false);
    }

    let handled = false;
    const dataEHoraDoErro = new Date();
    if (error instanceof HttpErrorResponse) {
      if (error.error instanceof ErrorEvent) {
        this._toastMessageService.criarMensagem({
          titulo: 'Erro de evento',
          dataEHora: dataEHoraDoErro,
          mensagem: 'Erro de evento'
        });
      } else {
        const titulo = `${error.status}`;
        switch (error.status) {
          case 401:      // login
            this._router.navigateByUrl('/unauthorized');
            handled = true;
            break;
          case 403:     // forbidden
            this._router.navigateByUrl('/unauthorized');
            handled = true;
            break;
          case 404:
            this._toastMessageService.criarMensagem({
              titulo: titulo,
              dataEHora: dataEHoraDoErro,
              mensagem: error.error.message
            });
            break;
          case 500:
            this._toastMessageService.criarMensagem({
              titulo: titulo,
              dataEHora: dataEHoraDoErro,
              mensagem: error.error.message
            });
            break;
        }
      }
    }

    if (handled) {
      return of(error);
    } else {
      return throwError(error);
    }
  }
}
