import { AfterViewInit, Component, ComponentFactoryResolver, ComponentRef, Input, OnDestroy, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { NgbNavChangeEvent } from '@ng-bootstrap/ng-bootstrap';
import { SideBarItem } from 'src/app/models/side-bar.model';

@Component({
    selector: 'app-nav-side-bar',
    templateUrl: './nav-side-bar.component.html'
})
export class NavSideBarComponent implements OnInit, AfterViewInit, OnDestroy {
    @Input() itens: SideBarItem[] = [];
    @ViewChild('conteudoDaAba', { read: ViewContainerRef }) viewContainerRef!: ViewContainerRef;

    componentRef: ComponentRef<any>;
    abaAtiva: string = '';

    constructor(private _componentFactoryResolver: ComponentFactoryResolver) { }

    ngOnInit(): void {
        this.abaAtiva = this.itens[0].identificadorDoItem;
    }

    ngAfterViewInit(): void {
        this.carregarComponenteDaPrimeiraAba();
    }

    ngOnDestroy(): void {
        this.componentRef.destroy();
    }

    onNavChange(changeEvent: NgbNavChangeEvent) {
        const indiceDoComponente = changeEvent.nextId;
        this.carregarComponente(this.itens.find(item => item.identificadorDoItem === indiceDoComponente));
    }

    carregarComponenteDaPrimeiraAba() {
        const item = this.itens[0];
        this.carregarComponente(item);
    }

    carregarComponente(item: SideBarItem) {
        this.viewContainerRef.clear();
        const fabricador = this._componentFactoryResolver.resolveComponentFactory(item.componente);
        this.componentRef = this.viewContainerRef.createComponent<typeof item.componente>(fabricador);
    }
}