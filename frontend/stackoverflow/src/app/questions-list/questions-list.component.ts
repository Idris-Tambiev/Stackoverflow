import { Component, OnInit } from '@angular/core';
import { Interface } from 'node:readline';

Interface Question{

}

@Component({
  selector: 'app-questions-list',
  templateUrl: './questions-list.component.html',
  styleUrls: ['./questions-list.component.css']
})

export class QuestionsListComponent implements OnInit {
  questions:Question[]=[]
  constructor() { }

  ngOnInit(): void {
  }

}
