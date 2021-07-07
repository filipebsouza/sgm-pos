import { Component } from '@angular/core';
import { SideBarItem } from 'src/app/models/side-bar.model';
import { IptuComponent } from './iptu/iptu.component';
import { ItrComponent } from './itr/itr.component';
import { ServicosAoCidadaoComponent } from './servicos-ao-cidadao/servicos-ao-cidadao.component';
import { SturComponent } from './stur/stur.component';

@Component({
    selector: 'app-modulo-cidadao',
    templateUrl: './cidadao.component.html'
})
export class CidadaoComponent {
    menu: SideBarItem[] = [
        {
            identificadorDoItem: 'IPTU',
            descricao: 'IPTU',
            componente: IptuComponent
        },
        {
            identificadorDoItem: 'ITR',
            descricao: 'ITR',
            componente: ItrComponent
        },
        {
            identificadorDoItem: 'servicos-cidadao',
            descricao: 'Serviços ao Cidadão',
            componente: ServicosAoCidadaoComponent
        },
        {
            identificadorDoItem: 'STUR',
            descricao: 'Acesso ao STUR',
            componente: SturComponent
        }
    ];
}
