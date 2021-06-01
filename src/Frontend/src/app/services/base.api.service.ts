import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ApiContract } from './api.contract';

export class BaseApiService<ReturnType> implements ApiContract<ReturnType> {
    recurso: string;
    apiUrl = environment.apiUrl;

    constructor(public http: HttpClient) { }

    list(...args: any): Observable<ReturnType[]> {
        return this.http.get<ReturnType[]>(`${this.apiUrl}/${this.recurso}`);
    }
    get(...args: any): Observable<ReturnType> {
        return this.http.get<ReturnType>(`${this.apiUrl}/${this.recurso}`);
    }
    post(item: ReturnType): Observable<ReturnType> {
        return this.http.post<ReturnType>(`${this.apiUrl}/${this.recurso}`, item);
    }
    delete(item: ReturnType): Observable<ReturnType> {
        return this.http.delete<ReturnType>(`${this.apiUrl}/${this.recurso}`, item);
    }
    put(item: ReturnType): Observable<ReturnType> {
        return this.http.put<ReturnType>(`${this.apiUrl}/${this.recurso}`, item);
    }
}