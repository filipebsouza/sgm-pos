import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { LocalStorageService } from './services/local-storage/local-storage.service';
import { JWTTokenService } from './services/security/jwt-token.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'SGM';

  constructor(private _router: Router, private _jwtService: JWTTokenService, private _localStorageService: LocalStorageService) {
    this._router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this._jwtService.setTokenFromLocalStorage();
        if (this._jwtService.tokenEstahExpirado()) {
          this._localStorageService.remove('TOKEN');
        }
      }
    });
  }
}
