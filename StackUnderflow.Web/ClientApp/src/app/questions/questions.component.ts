import {Component, OnInit} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { question } from '../../models/question';
import { BehaviorSubject } from 'rxjs';
@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {

  closeResult: string;
  public questions;
  public questionsSubject: BehaviorSubject<any> = new BehaviorSubject({});
  constructor(public http: HttpClient) {
   this.refreshData();
  }

  ngOnInit() {
  }

  refreshData() {
    const token = localStorage.getItem('jwt');
    this.http.get<question[]>(`${environment.apiUrl}questions`, {headers: new HttpHeaders({
        'Authorization': 'Bearer ' + token,
        'Content-Type': 'application/json'
    })}).subscribe(result => {
      this.questionsSubject.next(result);
      this.questions = this.questionsSubject.getValue();
    }, error => console.error(error));
  }
  addQuestion(content) {
    const payload = {
      text: content,
      askedBy: 'Rob',
      topic: 1
    };
    this.http.post<question>(`${environment.apiUrl}questions`, payload).subscribe(result => {
      this.refreshData();
    }, err => console.error(err));
  }

  upvoteQuestion(questionId) {
    this.http.post<question>(`${environment.apiUrl}questions/${questionId}/up`, questionId).subscribe(result => {
      this.refreshData();
    }, err => console.error(err));
  }
  // p00
  downvoteQuestion(questionId) {
    this.http.post<question>(`${environment.apiUrl}questions/${questionId}/down`, questionId).subscribe(result => {
      this.refreshData();
    }, err => console.error(err));
  }
}

