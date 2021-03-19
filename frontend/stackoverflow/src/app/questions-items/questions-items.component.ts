import { Component, Input, OnInit } from '@angular/core';
import { Question } from 'src/app/interfaces/question';
@Component({
  selector: 'app-questions-items',
  templateUrl: './questions-items.component.html',
  styleUrls: ['./questions-items.component.css'],
})
export class QuestionsItemsComponent implements OnInit {
  constructor() {}
  @Input() questions: Question;
  ngOnInit(): void {}
}
