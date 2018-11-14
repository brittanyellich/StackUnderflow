import { AuthService } from './../providers/auth-service/auth.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { QuestionsComponent } from './questions/questions.component';
import { ResponsesComponent } from './responses/responses.component';
import { CommentsComponent } from './comments/comments.component';
import { QuestionComponent } from './question/question.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbModalStack } from '@ng-bootstrap/ng-bootstrap/modal/modal-stack';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    QuestionsComponent,
    ResponsesComponent,
    CommentsComponent,
    LoginComponent,
    QuestionComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      {
        path: 'questions',
        component: QuestionsComponent,
      },
      {
        path: 'questions/:id',
        component: QuestionComponent
      },
      { path: 'login', component: LoginComponent},
      { path: 'register', component: RegisterComponent}
      { path: 'responses/:id', component: ResponsesComponent}
    ])
  ],
  providers: [
    NgbModalStack,
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
