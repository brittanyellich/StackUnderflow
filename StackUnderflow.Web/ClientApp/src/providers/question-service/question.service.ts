import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";

@Injectable()
export class QuestionService {

  constructor(public http: HttpClient) { }

  getQuestions() {
    this.http.get<question[]>(`${environment.apiUrl}Questions`).subscribe(result => {
      return result;
    }, error => console.error(error));
  }
}
