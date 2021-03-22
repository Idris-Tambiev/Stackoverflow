import { Component, OnInit } from '@angular/core';
import { Question } from 'src/app/interfaces/question';
import { QuestionsService } from 'src/app/services/questions.service';

@Component({
  selector: 'app-add-question',
  templateUrl: './add-question.component.html',
  styleUrls: ['./add-question.component.css'],
})
export class AddQuestionComponent implements OnInit {
  newQuestion: Question = {
    id: 0,
    questionText: '',
    description: '',
    date: '',
    answersCount: 0,
  };
  constructor(private httpService: QuestionsService) {}

  ngOnInit(): void {}

  getTitle(event: any) {
    if (event.target.value !== '') {
      this.newQuestion.questionText = event.target.value;
    }
  }

  getDescription(event: any) {
    if (event.target.value !== '') {
      this.newQuestion.description = event.target.value;
    }
  }

  createNewQuestion() {
    if (
      this.newQuestion.description !== '' &&
      this.newQuestion.questionText !== ''
    ) {
      this.httpService.postNewQuestion(this.newQuestion).subscribe(
        (response: string) => {
          console.log(response);
        },
        (error) => console.log(error)
      );
    }
  }
}
