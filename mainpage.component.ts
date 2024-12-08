import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main',
  standalone: true,
  templateUrl: './mainpage.component.html',
  styleUrls: ['./mainpage.component.css'],
})
export class MainpageComponent implements OnInit {
  events = [
    {
      id: 1,
      name: 'Music Concert',
      date: new Date('2024-12-25'),
      location: 'Downtown Arena',
    },
    {
      id: 2,
      name: 'Tech Conference',
      date: new Date('2024-12-20'),
      location: 'Tech Hall A',
    },
    {
      id: 3,
      name: 'Art Exhibition',
      date: new Date('2024-12-30'),
      location: 'City Gallery',
    },
  ];

  constructor(private router: Router) {}

  
  ngOnInit(): void {}

  pressLogin(){
    this.router.navigateByUrl('/login');
  }

  pressSignup(){
    this.router.navigateByUrl('/signup');
  }

  browseEvents() {
    this.router.navigateByUrl('/events');
  }

  viewEvent(eventId: number) {
    this.router.navigate(['/events', eventId]);
  }
  bookTickets(){
    this.router.navigateByUrl('/booktickets');
  }
}
