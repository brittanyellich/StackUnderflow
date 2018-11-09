import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {

  public questions: Question[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private modalService: NgbModal) {
    http.get<Question[]>(baseUrl + 'api/Questions').subscribe(result => {
      this.questions = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

  addQuestion(content){
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      console.log('nice')
    }, (reason) => {
    });
  }

}
interface Question {
  text: string;
  askedBy: string;
  askedAt: DateTimeFormat;
  responseSolutionId: number;
  votes: number;
}
