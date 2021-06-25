import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NgbDropdownModule, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { LoaderComponent } from './loader/loader.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ToastMessageComponent } from './toast-message/toast-message.component';

@NgModule({
    declarations: [
        NavMenuComponent,
        ToastMessageComponent,
        LoaderComponent,
    ],
    exports: [
        NavMenuComponent,
        ToastMessageComponent,
        LoaderComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        NgbToastModule,
        NgbDropdownModule
    ]
})
export class ComponentsModule { }