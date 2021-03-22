import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { QuestionsService } from 'src/app/services/questions.service';
import { AnswersService } from 'src/app/services/answers.service';
import { Answer } from 'src/app/interfaces/answer';
import { Question } from 'src/app/interfaces/question';
@Component({
  selector: 'app-question-page',
  templateUrl: './question-page.component.html',
  styleUrls: ['./question-page.component.css'],
})
export class QuestionPageComponent implements OnInit {
  answers: Answer[] = [];
  pagesCount: number = 1
  question: Question;
  idQuestion: number;
  displayedColumns: string[] = ['id', 'AnswerText', 'Date', 'Questionid'];

  constructor(
    private route: ActivatedRoute,
    private httpQuestionService: QuestionsService,
    private httpAnswerService: AnswersService
  ) { }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    this.idQuestion = Number(routeParams.get('id'));
    this.getQuestion();
  }
  getQuestion() {
    this.httpQuestionService.getQuestion(this.idQuestion).subscribe((data) => {
      this.question = data;
      this.pagesCount = Math.ceil(data.answersCount / 5)
      this.getAnswers(1);
    });
  }

  getAnswers(pageNumber: number) {
    this.httpAnswerService.getAnswers(this.idQuestion, pageNumber).subscribe((data) => {
      this.answers = data;
      console.log(this.question.answersCount);
    });
  }

  counter(i: number) {
    return new Array(i);
  }

  clickOnPage(event: any) {
    this.getAnswers(event.target.value)
  }
}
