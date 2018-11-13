import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from './../../providers/auth-service/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public userName: string;
  public password: string;
  public error: string;
  constructor(private auth: AuthService, private router: Router, private http: HttpClient) { }

  ngOnInit() {
  }

  login() {
    const credentials = {UserName: this.userName, Password: this.password};
    this.http.post('https://localhost:5001/api/auth/login', credentials, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }).subscribe(response => {
      const token = (<any>response).token;
      localStorage.setItem('jwt', token);
      this.router.navigate(['/']);
    }, err => {
      this.error = err;
      console.log(err);
    });
  }

}
