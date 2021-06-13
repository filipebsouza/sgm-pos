import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { JWTTokenService } from '../services/security/jwt-token.service';

@Injectable()
export class HttpConfigInterceptor implements HttpInterceptor {
    constructor(private _jwtService: JWTTokenService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const token = this._jwtService.getToken();
        req = req.clone({
          url:  req.url,
          setHeaders: {
            Authorization: `Bearer ${token}`
          }
        });
        return next.handle(req);
    }
}