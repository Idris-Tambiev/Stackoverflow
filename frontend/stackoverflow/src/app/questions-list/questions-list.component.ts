import { Component, OnInit } from '@angular/core';
import { Question } from '../interfaces/question';
import { All } from 'src/app/interfaces/all';
import { QuestionsService } from '../services/questions.service';

@Component({
  selector: 'app-questions-list',
  templateUrl: './questions-list.component.html',
  styleUrls: ['./questions-list.component.css'],
})
export class QuestionsListComponent implements OnInit {
  pagesCount: number = 1;
  currentPage: number = 1;
  questions: Question[] = [];
  allQuestions: Question[] = [];
  constructor(private httpService: QuestionsService) {}
  value: any;
  displayedColumns: string[] = ['id', 'questionText', 'answersCount', 'date'];

  ngOnInit(): void {
    this.getAllQuestions(1);
  }

  getAllQuestions(page: number) {
    this.httpService.getQuestions(1, page).subscribe((data) => {
      this.pagesCount = Math.ceil(data.countQuestions / 5);
      this.questions = data.questionsArray;
      console.log(this.pagesCount);
    });
  }

  searchQuestion(event: any) {
    this.value = event.target.value;
  }

  findQuestion() {
    if (this.value !== '' && this.value !== undefined) {
      this.httpService.find(this.value, 1).subscribe((data) => {
        this.pagesCount = Math.ceil(data.countQuestions / 5);
        this.questions = data.questionsArray;
        this.currentPage = 1;
        console.log(data.countQuestions);
      });
    } else {
      this.getAllQuestions(1);
    }
  }

  counter(i: number) {
    return new Array(i);
  }
  clickOnPage(event: any) {
    this.currentPage = event.target.value;
    this.getAllQuestions(event.target.value);
  }
}
