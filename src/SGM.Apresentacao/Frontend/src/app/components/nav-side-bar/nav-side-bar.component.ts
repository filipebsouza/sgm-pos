import { Component, ComponentFactoryResolver, Input, OnInit, ViewChild, ViewChildren } from '@angular/core';
import { AddComponentDirective } from 'src/app/directives/add-component.directive';
import { SideBarItem } from 'src/app/models/side-bar.model';

@Component({
    selector: 'app-nav-side-bar',
    templateUrl: './nav-side-bar.component.html'
})
export class NavSideBarComponent implements OnInit {
    @Input() itens: SideBarItem[] = [];

    @ViewChild(AddComponentDirective, { static: true }) addComponent!: AddComponentDirective;

    constructor(private _componentFactoryResolver: ComponentFactoryResolver) { }

    ngOnInit(): void {
        this.carregarComponenteDaPrimeiraAba();
    }

    carregarComponenteDaPrimeiraAba() {
        const item = this.itens[0];
        this.carregarComponente(item);
    }

    carregarComponente(item: SideBarItem) {
        const fabricador = this._componentFactoryResolver.resolveComponentFactory(item.componente);
        const viewContainerRef = this.addComponent.viewContainerRef;
        viewContainerRef.clear();

        viewContainerRef.createComponent<AddComponentDirective>(fabricador);
    }
}