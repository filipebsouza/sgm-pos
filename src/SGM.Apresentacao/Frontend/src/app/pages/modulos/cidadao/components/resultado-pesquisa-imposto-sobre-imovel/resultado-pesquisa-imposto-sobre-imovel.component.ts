import { Component, Input } from '@angular/core';
import { ImpostoSobreImovel } from 'src/app/models/imposto-sobre-imovel.model';

@Component({
    selector: 'app-cidadao-components-resultado-pesquisa-imposto-sobre-imovel',
    templateUrl: './resultado-pesquisa-imposto-sobre-imovel.component.html'
})
export class ResultadoPesquisaImpostoSobreImovelComponent {
    @Input() imposto: ImpostoSobreImovel;
}
