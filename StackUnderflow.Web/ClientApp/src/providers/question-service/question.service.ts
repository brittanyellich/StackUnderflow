import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Inject, Injectable} from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable()
export class QuestionService {

  constructor(public http: HttpClient) { }

  getQuestions() {
    const token = localStorage.getItem('jwt');
    this.http.get<question[]>(`${environment.apiUrl}Questions`, {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${token}`,
        'Content-Type': 'application/json'
      })
    }).subscribe(result => {
      return result;
    }, error => console.error(error));
  }
}
