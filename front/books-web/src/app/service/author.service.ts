import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root',
})
export class AuthorService {
    constructor(private http: HttpClient) {}

    getAuthors(): Observable<any> {
        return this.http.get(`${environment.apiUrl}Authors`);
    }
}
