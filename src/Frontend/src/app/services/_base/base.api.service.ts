import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiContract } from './api.contract';

export class BaseApiService<ReturnType> implements ApiContract<ReturnType> {
    recurso: string;
    constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) { }

    list(...args: any): Observable<ReturnType[]> {
        return this.http.get<ReturnType[]>(`${this.baseUrl}/${this.recurso}`);
    }
    get(...args: any): Observable<ReturnType> {
        return this.http.get<ReturnType>(`${this.baseUrl}/${this.recurso}`);
    }
    post(item: ReturnType): Observable<ReturnType> {
        return this.http.post<ReturnType>(`${this.baseUrl}/${this.recurso}`, item);
    }
    delete(item: ReturnType): Observable<ReturnType> {
        return this.http.delete<ReturnType>(`${this.baseUrl}/${this.recurso}`, item);
    }
    put(item: ReturnType): Observable<ReturnType> {
        return this.http.put<ReturnType>(`${this.baseUrl}/${this.recurso}`, item);
    }
}