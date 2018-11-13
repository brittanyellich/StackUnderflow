import { Component, OnInit, Input } from '@angular/core';
import { environment } from "../../environments/environment";
import { HttpClient } from "@angular/common/http";
import Question = require("../../models/question");
import question = Question.question;
import { Router, ActivatedRoute } from '@angular/router';
import Response1 = require("../../models/response");
import response = Response1.response;

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

  constructor(public http: HttpClient, public route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    this.http.get<question>(`${environment.apiUrl}questions/${this.id}`).subscribe(result => {
      console.log(result);
      this.question = result;
    }, error => console.error(error));

    this.http.get<response[]>(`${environment.apiUrl}questions/${this.id}/responses`).subscribe(result => {
      console.log(result);
      this.responses = result;
    }, error => console.error(error));

  }

  ngOnInit() {
  }

  respondToQuestion(content) {
    const payloadResponse = {
      text: content,
      askedBy: 'Rob',
      questionId: this.id
    };

    this.http.post<response>(`${environment.apiUrl}Responses`, payloadResponse).subscribe(result => {
      console.log('we did it');
    }, err => console.error(err));
    console.log(content);
  }

  markResponseInappropriate(responseId) {
    this.http.post<response>(`${environment.apiUrl}Responses/${responseId}/inappropriate`, responseId).subscribe(result => {
      console.log('we did it');
    }, err => console.error(err));
    console.log(responseId);
  }

  upvoteResponse(responseId) {
    this.http.post<response>(`${environment.apiUrl}Responses/${responseId}/upvote`, responseId).subscribe(result => {
      console.log('we did it');
    }, err => console.error(err));
    console.log(responseId);
  }

  downvoteResponse(responseId) {
    this.http.post<response>(`${environment.apiUrl}Responses/${responseId}/downvote`, responseId).subscribe(result => {
      console.log('we did it');
    }, err => console.error(err));
    console.log(responseId);
  }

  markAsSolution(responseId) {
    this.http.post<response>(`${environment.apiUrl}Responses/${responseId}/solution`, responseId).subscribe(result => {
      console.log('we did it');
    }, err => console.error(err));
    console.log(responseId);
  }

}
