import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Answer } from '../interfaces/answer';
import { environment } from 'src/environments/environment';

@Injectable()
export class AnswersService {
  configUrl: string = environment.Url;
  constructor(private http: HttpClient) {}

  getAnswers(questionId: number): Observable<Answer[]> {
    return this.http.get<Answer[]>(
      this.configUrl + '/api/answers/' + questionId
    );
  }
}
