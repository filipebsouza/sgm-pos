import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { JWTTokenService } from './services/security/jwt-token.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'SGM';

  constructor(private _router: Router, private _jwtService: JWTTokenService) {
    this._router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this._jwtService.setTokenFromLocalStorage();
        if (this._jwtService.tokenEstahExpirado()) {
          this._jwtService.setToken(null);
        }
      }
    });
  }
}
