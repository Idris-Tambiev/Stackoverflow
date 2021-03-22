import { Component, OnInit } from '@angular/core';
import { Question } from '../interfaces/question';
import { QuestionsService } from '../services/questions.service';

@Component({
  selector: 'app-questions-list',
  templateUrl: './questions-list.component.html',
  styleUrls: ['./questions-list.component.css'],
})
export class QuestionsListComponent implements OnInit {
  allLists: boolean = true;
  pagesCount: number = 1;
  currentPage: number = 1;
  currentFindedPage: number = 1;
  finds: number = 0;
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

  findQuestion(page: number) {
    if (this.value !== '' && this.value !== undefined) {
      this.httpService.find(this.value, page).subscribe((data) => {
        this.pagesCount = Math.ceil(data.countQuestions / 5);
        this.questions = data.questionsArray;
        console.log(data.countQuestions);
        this.currentPage = page;
        this.allLists = false;
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
    if (this.allLists) this.getAllQuestions(event.target.value);
    else {
      this.findQuestion(event.target.value);
    }
  }
}
