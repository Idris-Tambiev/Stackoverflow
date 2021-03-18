import { Component, OnInit } from '@angular/core';

export interface Answer {
  id: number;
  text: string;
  date: string;
}
@Component({
  selector: 'app-question-page',
  templateUrl: './question-page.component.html',
  styleUrls: ['./question-page.component.css'],
})
export class QuestionPageComponent implements OnInit {
  answers: Answer[] = [];
  constructor() {}

  ngOnInit(): void {}
}
