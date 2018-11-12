import {Component, OnInit} from '@angular/core';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {QuestionService} from "../../providers/question-service/question.service";

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {
  public questions;

  constructor(public questionSvc: QuestionService, private modalService: NgbModal) {
    this.questions = this.questionSvc.getQuestions();
  }

  ngOnInit() {
  }

  addQuestion(content){
    this.modalService.open(content, {}).result.then((result) => {
      console.log('nice')
    }, (reason) => {
      console.error('more modals more problems')
    });
  }
}

