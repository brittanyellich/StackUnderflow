import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable()
export class AuthService {

  constructor(private http: HttpClient) {}

  login(username, password) {
    return this.http.post(`${environment.apiUrl}auth/login`, {UserName: username, Password: password});
  }

}
