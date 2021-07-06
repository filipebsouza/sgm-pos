import { Component, Input } from '@angular/core';
import { ImpostoSobreImovel } from 'src/app/models/imposto-sobre-imovel.model';

@Component({
    selector: 'app-cidadao-iptu-resultado-pesquisa',
    templateUrl: './resultado-pesquisa.component.html'
})
export class ResultadoPesquisaComponent {
    @Input() iptu: ImpostoSobreImovel;
}