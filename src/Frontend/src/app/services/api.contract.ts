import { Observable } from 'rxjs';

export interface ApiContract<ReturnType> {
    recurso: string;
    apiUrl: string;
    list(...args: any): Observable<ReturnType[]>;
    get(...args: any): Observable<ReturnType>;
    post(item: ReturnType): Observable<ReturnType>;
    delete(item: ReturnType): Observable<ReturnType>;
    put(item: ReturnType): Observable<ReturnType>;
}