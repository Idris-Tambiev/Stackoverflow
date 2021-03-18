import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { QuestionsListComponent } from './questions-list/questions-list.component';
import { QuestionsItemsComponent } from './questions-items/questions-items.component';
import { AddQuestionComponent } from './add-question/add-question.component';
import { QuestionPageComponent } from './question-page/question-page.component';
import { NewAnswerPageComponent } from './new-answer-page/new-answer-page.component';

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
  imports: [BrowserModule, RouterModule.forRoot(appRoutes)],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
