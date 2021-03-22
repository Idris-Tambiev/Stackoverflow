import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Answer } from '../interfaces/answer';
import { environment } from 'src/environments/environment';

@Injectable()
export class AnswersService {
  configUrl: string = environment.Url;
  constructor(private http: HttpClient) { }

  getAnswers(questionId: number, page: number): Observable<Answer[]> {
    return this.http.get<Answer[]>(
      this.configUrl + '/api/answers/' + questionId + '/' + page
    );
  }
  postNewAnswer(answer: Answer): Observable<string> {
    return this.http.post(this.configUrl + '/api/answers', answer, {
      responseType: 'text',
    });
  }

}
