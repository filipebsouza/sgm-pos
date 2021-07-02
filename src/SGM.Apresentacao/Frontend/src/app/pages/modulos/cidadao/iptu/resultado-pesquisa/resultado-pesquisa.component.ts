import { Component, Input } from '@angular/core';
import { Iptu } from 'src/app/models/iptu.model';

@Component({
    selector: 'app-cidadao-iptu-resultado-pesquisa',
    templateUrl: './resultado-pesquisa.component.html'
})
export class ResultadoPesquisaComponent {
    @Input() iptu: Iptu;
}