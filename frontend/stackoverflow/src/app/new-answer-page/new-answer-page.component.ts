import { Component, OnInit } from '@angular/core';
import { Answer } from 'src/app/interfaces/answer';
import { AnswersService } from 'src/app/services/answers.service';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-new-answer-page',
  templateUrl: './new-answer-page.component.html',
  styleUrls: ['./new-answer-page.component.css'],
})
export class NewAnswerPageComponent implements OnInit {
  answer: Answer = {
    id: 0,
    answerText: '',
    questionid: 0,
    date: '',
  };
  idQuestion: number;

  constructor(
    private httpAnswerService: AnswersService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    this.idQuestion = Number(routeParams.get('id'));
  }
  getAnswer(event: any) {
    if (event.target.value !== '') {
      this.answer.answerText = event.target.value;
    }
  }

  createNewAnswer() {
    if (this.answer.answerText !== '' && this.answer.answerText !== '') {
      this.answer.questionid = this.idQuestion;
      this.httpAnswerService.postNewAnswer(this.answer).subscribe(
        (response: string) => {
          console.log(response);
        },
        (error) => console.log(error)
      );
    }
  }
}
