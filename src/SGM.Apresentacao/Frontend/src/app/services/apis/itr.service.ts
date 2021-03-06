import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ImpostoSobreImovel } from 'src/app/models/imposto-sobre-imovel.model';
import { BaseApiService } from '../_base/base.api.service';

@Injectable()
export class ItrService extends BaseApiService<ImpostoSobreImovel> {
    recurso = 'Itrs';
    constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
        super(http, baseUrl);
    }

    getPorCpfDoContribuinteEAnoDeReferencia(cpfDoContribuinte: string, anoDeReferencia: number): Observable<void | ImpostoSobreImovel> {
        return this.http.get<ImpostoSobreImovel>(`${this.baseUrl}/${this.recurso}/${cpfDoContribuinte}/${anoDeReferencia}`);
    }
}
