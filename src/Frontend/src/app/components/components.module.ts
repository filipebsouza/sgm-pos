import { NgModule } from '@angular/core';
import { NgbModule, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ToastMessageComponent } from './toast-message/toast-message.component';

@NgModule({
    declarations: [
        NavMenuComponent,
        ToastMessageComponent,
    ],
    imports: [
        NgbModule,
        NgbToastModule
    ]
})
export class ComponentsModule { }