// import { Injectable } from '@angular/core';
// import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
// import { Observable } from 'rxjs';
// import { Usuario } from 'src/app/models/usuario.model';
// import { UsuarioService } from 'src/app/services/apis/usuario.service';
// import { LocalStorageService } from 'src/app/services/local-storage/local-storage.service';
// import { JWTTokenService } from 'src/app/services/security/jwt-token.service';

// @Injectable({
//     providedIn: 'root'
// })
// export class AuthorizeGuard implements CanActivate {
//     constructor(private usuarioService: UsuarioService,
//         private localStorageService: LocalStorageService,
//         private jwtService: JWTTokenService) {
//     }

//     canActivate(
//         next: ActivatedRouteSnapshot,
//         state: RouterStateSnapshot): Observable<Usuario> | Promise<Usuario> | boolean {
//         if (this.jwtService.getUser()) {
//             if (this.jwtService.isTokenExpired()) {
//                 // Should Redirect Sig-In Page
//             } else {
//                 return true;
//             }
//         } else {
//             return new Promise((resolve) => {
//                 this.usuarioService.signIncallBack().then((e) => {
//                     resolve(true);
//                 }).catch((e) => {
//                     // Should Redirect Sign-In Page
//                 });
//             });
//         }
//     }
// }