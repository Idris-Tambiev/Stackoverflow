import { Component, OnInit } from '@angular/core';
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
  question: Question;
  idQuestion: number;
  displayedColumns: string[] = ['id', 'AnswerText', 'Date', 'Questionid'];
  constructor(
    private route: ActivatedRoute,
    private httpQuestionService: QuestionsService,
    private httpAnswerService: AnswersService
  ) {}

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    this.idQuestion = Number(routeParams.get('id'));
    this.getQuestion();
  }
  getQuestion() {
    this.httpQuestionService.getQuestion(this.idQuestion).subscribe((data) => {
      this.question = data;
      console.log(data);
      this.getAnswers();
    });
  }
  getAnswers() {
    this.httpAnswerService.getAnswers(this.idQuestion).subscribe((data) => {
      this.answers = data;
    });
  }
}
