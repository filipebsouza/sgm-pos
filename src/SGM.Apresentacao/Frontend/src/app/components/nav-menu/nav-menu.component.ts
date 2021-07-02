import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/models/usuario.model';
import { JWTTokenService } from 'src/app/services/security/jwt-token.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  usuario: Usuario;

  constructor(private _jwtService: JWTTokenService, private _router: Router) { }

  ngOnInit(): void {
    this._jwtService.emissorDeUsuarioLogado.subscribe(usuario => this.usuario = usuario);
    if (!this.usuario) {
      this.usuario = this._jwtService.getUsuario();
    }
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  irPara(rota: string) {
    this._router.navigate([rota]);
  }

  sair() {
    this._jwtService.setToken(null);
    this._router.navigate(['login']);
  }
}
