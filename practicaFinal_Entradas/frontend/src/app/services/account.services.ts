import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';

import { User } from '../shared/Usuarios';

@Injectable({ providedIn: 'root' })
export class AccountService {
    public user: User = new User();

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
    }

    register(Username: any, Email: any, Password: any) {
        this.user.Username = Username;
        this.user.Email = Email;
        this.user.Password = Password;
        return this.http.post('/api/Registro', this.user);
    }
}