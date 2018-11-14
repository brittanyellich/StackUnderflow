import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from '../../environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public user = {};
  public confirmPassword: string;
  public error;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
  }

  register() {
    if (this.confirmPassword !== this.user['Password']) {
      this.error = 'Passwords do not match';
      return false;
    }
    this.http.post(`${environment.apiUrl}auth/register`, this.user).subscribe(data => {
      console.log(data);
      this.router.navigate(['/']);
    }, err => {
      console.log(err);
    });
  }

}
