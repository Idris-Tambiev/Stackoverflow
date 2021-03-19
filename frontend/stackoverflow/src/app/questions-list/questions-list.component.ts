import { Component, OnInit } from '@angular/core';
import { Question } from '../interfaces/question';
import { QuestionsService } from '../services/questions.service';

@Component({
  selector: 'app-questions-list',
  templateUrl: './questions-list.component.html',
  styleUrls: ['./questions-list.component.css'],
})
export class QuestionsListComponent implements OnInit {
  questions: Question[] = [];
  allQuestions: Question[] = [];
  constructor(private httpService: QuestionsService) {}
  value: any;
  displayedColumns: string[] = ['id', 'questionText', 'answersCount', 'date'];

  ngOnInit(): void {
    this.getAllQuestions();
  }

  getAllQuestions() {
    this.httpService.getQuestions().subscribe((data) => {
      this.allQuestions = data;
      this.questions = data;
      console.log(this.questions);
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
}
