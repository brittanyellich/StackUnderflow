import { Component, OnInit, Input } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import Response = require('../../models/response');
import response = Response.response;
import { Router, ActivatedRoute } from '@angular/router';
import Comment = require('../../models/comment');
import comment = Comment.comment;

@Component({
  selector: 'app-responses',
  templateUrl: './responses.component.html',
  styleUrls: ['./responses.component.css']
})
export class ResponsesComponent implements OnInit {
  @Input()
  id: number;
  public response;
  public comments;


  constructor(public http: HttpClient, public route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    this.http.get<response>(`${environment.apiUrl}responses/${this.id}`).subscribe(result => {
      console.log(result);
      this.response = result;
    }, error => console.error(error));

    this.http.get<comment[]>(`${environment.apiUrl}responses/${this.id}/comments`).subscribe(result => {
      console.log(result);
      this.comments = result;
    }, error => console.error(error));

  }

  ngOnInit() {
  }

  commentOnResponse(content) {
    const payloadResponse = {
      text: content,
      commentedBy: 'Rob',
      responseId: this.id
    };

    this.http.post<comment>(`${environment.apiUrl}Comments`, payloadResponse).subscribe(result => {
        console.log('we did it');
      },
      err => console.error(err));
    console.log(content);
  }


}
