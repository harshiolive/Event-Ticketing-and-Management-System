import { Component } from '@angular/core';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-events',
  standalone: true,
  imports: [FormsModule,HttpClientModule],
  templateUrl: './events.component.html',
  styleUrl: './events.component.css'
})
export class EventsComponent {
  searchQuery: string = '';
  selectedCategory: string = '';
  events = [
    { id: 1, name: 'Music Concert', date: new Date('2024-12-25'), location: 'Downtown Arena', category: 'Music' },
    { id: 2, name: 'Tech Conference', date: new Date('2024-12-20'), location: 'Tech Hall A', category: 'Technology' },
    { id: 3, name: 'Art Exhibition', date: new Date('2024-12-30'), location: 'City Gallery', category: 'Art' },
  ];

  filteredEvents = [...this.events];

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.filterEvents(); // Initial filtering
  }

  filterEvents(): void {
    this.filteredEvents = this.events.filter((event) => {
      const matchesQuery = event.name.toLowerCase().includes(this.searchQuery.toLowerCase());
      const matchesCategory = this.selectedCategory ? event.category === this.selectedCategory : true;
      return matchesQuery && matchesCategory;
    });
  }

  viewEvent(eventId: number): void {
    this.router.navigate(['/events', eventId]);
  }
}
