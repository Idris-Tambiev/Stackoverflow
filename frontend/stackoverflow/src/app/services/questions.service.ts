import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Question } from '../interfaces/question';
import { All } from '../interfaces/all';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable()
export class QuestionsService {
  configUrl: string = environment.Url;
  constructor(private http: HttpClient) { }

  getQuestions(id: number, page: number): Observable<All> {
    return this.http.get<All>(this.configUrl + '/api/questions/' + id + '/' + page)
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
  findQuestion(text: string): Observable<Question> {
    return this.http.get<Question>(
      this.configUrl + '/api/questions/' + text
    );
  }
}
