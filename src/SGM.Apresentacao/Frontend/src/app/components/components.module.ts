import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NgbDropdownModule, NgbNavModule, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { LoaderComponent } from './loader/loader.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { NavSideBarComponent } from './nav-side-bar/nav-side-bar.component';
import { ToastMessageComponent } from './toast-message/toast-message.component';

@NgModule({
    declarations: [
        NavMenuComponent,
        ToastMessageComponent,
        LoaderComponent,
        NavSideBarComponent
    ],
    exports: [
        NavMenuComponent,
        ToastMessageComponent,
        LoaderComponent,
        NavSideBarComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        NgbToastModule,
        NgbDropdownModule,
        NgbNavModule
    ]
})
export class ComponentsModule { }