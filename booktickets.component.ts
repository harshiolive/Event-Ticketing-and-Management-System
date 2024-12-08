import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-ticket-booking',
  imports: [FormsModule,CurrencyPipe],
  standalone:true,
  templateUrl: './booktickets.component.html',
  styleUrls: ['./booktickets.component.css'],
})
export class BookticketsComponent {
  constructor(private router: Router) {}
  // Define events with prices
  events = [
    { id: 1, name: 'Music Concert', price: 50 },
    { id: 2, name: 'Art Exhibition', price: 75 },
    { id: 3, name: 'Tech Conference', price: 100 },
  ];

  // Ticket types
  ticketTypes = ['General Admission', 'VIP'];

  // Form data
  selectedEvent: any = null;
  ticketType: string = '';
  quantity: number = 1;
  totalPrice: number = 0;

  // Method to update total price dynamically
  updatePrice() {
    if (this.selectedEvent && this.quantity) {
      this.totalPrice = this.selectedEvent.price * this.quantity;
    } else {
      this.totalPrice = 0;
    }
  }

  // Method to handle form submission
  onSubmit() {
    console.log('Booking Details:', {
      event: this.selectedEvent,
      ticketType: this.ticketType,
      quantity: this.quantity,
      totalPrice: this.totalPrice,
    });
    alert('Booking successful!');
  }

  onBook(){
    this.router.navigateByUrl('/payment');
  }
}
