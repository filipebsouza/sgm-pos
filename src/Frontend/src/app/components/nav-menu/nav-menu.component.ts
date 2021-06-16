import { Component } from '@angular/core';
import { Usuario } from 'src/app/models/usuario.model';
import { LocalStorageService } from 'src/app/services/local-storage/local-storage.service';
import { JWTTokenService } from 'src/app/services/security/jwt-token.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  usuario: Usuario;

  constructor(private _jwtService: JWTTokenService, private _localStorage: LocalStorageService) {
    this._jwtService.emissorDeUsuarioLogado.subscribe(usuario => this.usuario = usuario);
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  sair() {
    this._jwtService.setToken(null);
    this._localStorage.remove('TOKEN');
    location.reload();
  }
}
