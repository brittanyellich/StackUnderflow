import {Component, OnInit} from '@angular/core';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {

  closeResult: string;
  public questions;

  constructor(public http: HttpClient, private modalService: NgbModal) {
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

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
}

