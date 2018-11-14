import { Component, OnInit, Input } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {
  @Input()
  id: number;

  public question;
  public responses;
  public responsesSubject: BehaviorSubject<any> = new BehaviorSubject({});
  constructor(public http: HttpClient, public route: ActivatedRoute) {
   this.refreshData();
  }

  ngOnInit() {
  }

  refreshData() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    this.http.get<question>(`${environment.apiUrl}questions/${this.id}`).subscribe(result => {
      console.log(result);
      this.question = result;
    }, error => console.error(error));

    this.http.get<response[]>(`${environment.apiUrl}questions/${this.id}/responses`).subscribe(result => {
      console.log('responses', result);
      this.responsesSubject.next(result);
      this.responses = this.responsesSubject.getValue();
    }, error => console.error(error));
  }
  respondToQuestion(content) {
    const payloadResponse = {
      text: content,
      userId: 'Rob',
      questionId: this.id
    };

    this.http.post<response>(`${environment.apiUrl}responses`, payloadResponse).subscribe(result => {
      console.log('we did it');
      this.refreshData();
    }, err => console.error(err));
    console.log(content);
  }

  markResponseInappropriate(responseId) {
    this.http.post<response>(`${environment.apiUrl}Responses/${responseId}/inappropriate`, responseId).subscribe(result => {
      console.log('we did it');
      this.refreshData();
    }, err => console.error(err));
    console.log(responseId);
  }

  upvoteResponse(responseId) {
    this.http.post<response>(`${environment.apiUrl}responses/${responseId}/up`, responseId).subscribe(result => {
      console.log('we did it');
      this.refreshData();
    }, err => console.error(err));
    console.log(responseId);
  }

  downvoteResponse(responseId) {
    this.http.post<response>(`${environment.apiUrl}responses/${responseId}/down`, responseId).subscribe(result => {
      console.log('we did it');
      this.refreshData();
    }, err => console.error(err));
    console.log(responseId);
  }

  markAsSolution(responseId) {
    this.http.post<response>(`${environment.apiUrl}Responses/${responseId}/solution`, responseId).subscribe(result => {
      console.log('we did it');
      this.refreshData();
    }, err => console.error(err));
    console.log(responseId);
  }

}
