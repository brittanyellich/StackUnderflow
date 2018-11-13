import { Component, OnInit, Input } from '@angular/core';
import { environment } from "../../environments/environment";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {
  @Input()
  id: number;

  public question;

  constructor(public http: HttpClient) {
    this.http.get<question>(`${environment.apiUrl}questions/${this.id}`).subscribe(result => {
      console.log(result);
      this.question = result;
    }, error => console.error(error));
  }



  ngOnInit() {
  }

  respondToQuestion(content) {
    console.log("Responding....");
  }



}
