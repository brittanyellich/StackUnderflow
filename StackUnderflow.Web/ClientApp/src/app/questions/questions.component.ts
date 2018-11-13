import {Component, OnInit} from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {

  closeResult: string;
  public questions;

  constructor(public http: HttpClient) {
    this.http.get<question[]>(`${environment.apiUrl}questions`).subscribe(result => {
      console.log(result);
      this.questions = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

  addQuestion(content){

  }
}

