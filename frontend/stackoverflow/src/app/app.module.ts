import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { QuestionsListComponent } from './questions-list/questions-list.component';
import { QuestionsItemsComponent } from './questions-items/questions-items.component';
import { AddQuestionComponent } from './add-question/add-question.component';
import { QuestionPageComponent } from './question-page/question-page.component';
import { NewAnswerPageComponent } from './new-answer-page/new-answer-page.component';
import { HttpClientModule } from '@angular/common/http';
import { QuestionsService } from '../app/services/questions.service';
import { AnswersService } from '../app/services/answers.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';

const appRoutes: Routes = [
  { path: '', component: QuestionsListComponent },
  { path: 'question/:id', component: QuestionPageComponent },
  { path: 'create/question', component: AddQuestionComponent },
  { path: 'create/answer', component: NewAnswerPageComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    QuestionsListComponent,
    QuestionsItemsComponent,
    AddQuestionComponent,
    QuestionPageComponent,
    NewAnswerPageComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatInputModule,
    MatTableModule,
  ],
  providers: [QuestionsService, AnswersService],
  bootstrap: [AppComponent],
})
export class AppModule {}
