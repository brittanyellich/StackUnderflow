import {Component, OnInit} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import { question } from '../../models/question';
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

  addQuestion(content) {
    const payload = {
      text: content,
      askedBy: 'Rob',
      topic: 1
    };
    this.http.post<question>(`${environment.apiUrl}questions`, payload).subscribe(result => {
      console.log('we did it');
    }, err => console.error(err));
    console.log(content);
  }

  upvoteQuestion(questionId, ) {
    this.http.post<question>(`${environment.apiUrl}questions/${questionId}/up`, payload).subscribe(result => {
      console.log('we did it');
    }, err => console.error(err));
    console.log(questionId);
  }
  // p00
  downvoteQuestion(questionId) {
    this.http.post<question>(`${environment.apiUrl}questions/${questionId}/down`, payload).subscribe(result => {
      console.log('we did it');
    }, err => console.error(err));
    console.log(questionId);
  }
}

