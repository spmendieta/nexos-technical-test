import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root',
})
export class EditorialService {
    constructor(private http: HttpClient) {}

    getEditorials(): Observable<any> {
        return this.http.get(`${environment.apiUrl}Editorials`);
    }
}