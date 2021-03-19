import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Question } from '../interfaces/question';
import { environment } from 'src/environments/environment';

@Injectable()
export class QuestionsService {
  configUrl: string = environment.Url;
  constructor(private http: HttpClient) {}

  getQuestions(): Observable<Question[]> {
    return this.http.get<Question[]>(this.configUrl + '/api/questions');
  }
  postNewQuestion(question: Question): Observable<string> {
    return this.http.post(this.configUrl + '/api/questions', question, {
      responseType: 'text',
    });
  }

  getQuestion(questionId: number): Observable<Question> {
    return this.http.get<Question>(
      this.configUrl + '/api/questions/' + questionId
    );
  }
}
