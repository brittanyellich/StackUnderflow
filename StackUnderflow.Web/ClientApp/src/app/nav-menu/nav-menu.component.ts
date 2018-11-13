import { Component } from '@angular/core';
import { Router } from "@angular/router";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  public loggedIn = false;

  constructor(private router: Router) {
    this.router.events.subscribe(val => this.isLoggedIn())
  }

  isLoggedIn() {
    if (localStorage.getItem('jwt')) {
      this.loggedIn = true;
    } else {
      this.loggedIn = false;
    }
  }

  logout() {
    localStorage.removeItem('jwt');
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
