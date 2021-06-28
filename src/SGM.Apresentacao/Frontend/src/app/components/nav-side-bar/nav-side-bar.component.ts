import { AfterViewInit, Component, ComponentFactoryResolver, Input, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { SideBarItem } from 'src/app/models/side-bar.model';

@Component({
    selector: 'app-nav-side-bar',
    templateUrl: './nav-side-bar.component.html'
})
export class NavSideBarComponent implements OnInit, AfterViewInit {
    @Input() itens: SideBarItem[] = [];
    @ViewChild('conteudoDaAba', { read: ViewContainerRef }) viewContainerRef!: ViewContainerRef;

    abaAtiva: string = '';

    constructor(private _componentFactoryResolver: ComponentFactoryResolver) { }

    ngOnInit(): void {
        this.abaAtiva = this.itens[0].identificadorDoItem;
    }

    ngAfterViewInit(): void {
        this.carregarComponenteDaPrimeiraAba();
    }

    carregarComponenteDaPrimeiraAba() {
        const item = this.itens[0];
        this.carregarComponente(item);
    }

    carregarComponente(item: SideBarItem) {
        const fabricador = this._componentFactoryResolver.resolveComponentFactory(item.componente);
        this.viewContainerRef.clear();
        this.viewContainerRef.createComponent(fabricador);
    }
}