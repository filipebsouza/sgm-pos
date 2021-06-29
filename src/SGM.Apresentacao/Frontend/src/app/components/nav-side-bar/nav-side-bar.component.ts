import { AfterViewInit, Component, ComponentFactoryResolver, Input, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { NgbNavChangeEvent } from '@ng-bootstrap/ng-bootstrap';
import { SideBarItem } from 'src/app/models/side-bar.model';

@Component({
    selector: 'app-nav-side-bar',
    templateUrl: './nav-side-bar.component.html'
})
export class NavSideBarComponent implements OnInit, AfterViewInit {
    @Input() itens: SideBarItem[] = [];
    @ViewChild('conteudoDaAba', { read: ViewContainerRef }) viewContainerRef!: ViewContainerRef;

    abaAtiva: string = '';
    // componenteAtual: any;

    constructor(private _componentFactoryResolver: ComponentFactoryResolver) { }

    ngOnInit(): void {
        // this.componenteAtual = this.itens[0].componente;
        this.abaAtiva = this.itens[0].identificadorDoItem;
    }

    ngAfterViewInit(): void {
        this.carregarComponenteDaPrimeiraAba();
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
        const fabricador = this._componentFactoryResolver.resolveComponentFactory(item.componente);
        // if (this.viewContainerRef.indexOf(this.componenteAtual) >= 0) {
        //     this.viewContainerRef.remove(this.viewContainerRef.indexOf(this.componenteAtual));
        // }
        this.viewContainerRef.clear();
        this.viewContainerRef.createComponent<typeof item.componente>(fabricador);

        // this.componenteAtual = item.componente;
    }
}