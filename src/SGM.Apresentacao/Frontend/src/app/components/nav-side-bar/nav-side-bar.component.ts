import { Component, Input, OnInit, Type } from '@angular/core';
import { NgbNavChangeEvent } from '@ng-bootstrap/ng-bootstrap';
import { SideBarItem } from 'src/app/models/side-bar.model';

@Component({
    selector: 'app-nav-side-bar',
    templateUrl: './nav-side-bar.component.html'
})
export class NavSideBarComponent implements OnInit {
    @Input() itens: SideBarItem[] = [];

    componenteAtual: Type<any>;
    abaAtiva: string = '';

    ngOnInit(): void {
        this.abaAtiva = this.itens[0].identificadorDoItem;
        const primeiroItem = this.itens[0];
        this.componenteAtual = primeiroItem.componente;
    }

    onNavChange(changeEvent: NgbNavChangeEvent) {
        const indiceDoComponente = changeEvent.nextId;
        const item = this.itens.find(item => item.identificadorDoItem === indiceDoComponente);
        this.componenteAtual = item.componente;
    }
}