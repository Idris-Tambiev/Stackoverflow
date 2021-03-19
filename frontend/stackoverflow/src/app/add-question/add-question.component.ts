import { Component, OnInit } from '@angular/core';
import { Question } from 'src/app/interfaces/question';
import { QuestionsService } from 'src/app/services/questions.service';
@Component({
  selector: 'app-add-question',
  templateUrl: './add-question.component.html',
  styleUrls: ['./add-question.component.css'],
})
export class AddQuestionComponent implements OnInit {
  constructor(private httpService: QuestionsService) {}
  newText: string;
  newQuestion: Question = {
    id: 0,
    description: '',
    questionText: '',
    date: '',
    answersCount: 0,
  };
  newDescription: string;

  ngOnInit(): void {}

  getTitle(event: any) {
    this.newText = event.target.value;
    if (this.newText !== '') {
      this.newQuestion.questionText = this.newText;
    }
  }
  getDescription(event: any) {
    this.newDescription = event.target.value;
    if (this.newDescription !== '') {
      this.newQuestion.description = this.newDescription;
    }
  }
  createNewQuestion() {
    if (
      this.newQuestion.description !== '' &&
      this.newQuestion.questionText !== ''
    ) {
      this.newQuestion.answersCount = 0;
      this.newQuestion.date = Date.now().toString();
      this.httpService.postNewQuestion(this.newQuestion).subscribe(
        (response: string) => {
          console.log(response);
        },
        (error) => console.log(error)
      );
    }
  }
}
