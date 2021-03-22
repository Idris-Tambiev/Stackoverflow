import { Component, OnInit } from '@angular/core';
import { Question } from '../interfaces/question';
import { All } from 'src/app/interfaces/all'
import { QuestionsService } from '../services/questions.service';

@Component({
  selector: 'app-questions-list',
  templateUrl: './questions-list.component.html',
  styleUrls: ['./questions-list.component.css'],
})
export class QuestionsListComponent implements OnInit {
  pagesCount: number = 1
  questions: Question[] = [];
  allQuestions: Question[] = [];
  constructor(private httpService: QuestionsService) { }
  value: any;
  displayedColumns: string[] = ['id', 'questionText', 'answersCount', 'date'];

  ngOnInit(): void {
    this.getAllQuestions(1);
  }

  getAllQuestions(page: number) {
    this.httpService.getQuestions(1, page).subscribe((data) => {
      this.pagesCount = Math.ceil(data.countQuestions / 5)
      this.questions = data.questionsArray
      console.log(this.pagesCount);
    });
  }

  searchQuestion(event: any) {
    this.value = event.target.value;
    console.log(this.value);
  }

  findQuestion() {
    if (this.value !== '' && this.value !== undefined) {
      let value2 = this.value;
      this.questions = this.allQuestions.filter(function (item) {
        return item.questionText.toUpperCase().includes(value2.toUpperCase());
      });
    }
  }

  counter(i: number) {
    return new Array(i);
  }
  clickOnPage(event: any) {
    this.getAllQuestions(event.target.value)
  }
}
