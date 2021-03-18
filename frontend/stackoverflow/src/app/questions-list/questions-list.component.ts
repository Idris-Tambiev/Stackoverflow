import { Component, OnInit } from '@angular/core';

export interface Question {
  id: number;
  text: string;
  description: string;
  count: number;
  date: string;
}

@Component({
  selector: 'app-questions-list',
  templateUrl: './questions-list.component.html',
  styleUrls: ['./questions-list.component.css'],
})
export class QuestionsListComponent implements OnInit {
  questions: Question[] = [];
  constructor() {}

  ngOnInit(): void {}
}
