import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PaymentService {
  private baseUrl = 'https://localhost:7031/api/Payments'; // Replace with your API endpoint

  constructor(private http: HttpClient) {}

  // Create a payment session or initiate payment
  createPaymentSession(data: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/create-session`, data);
  }

  // Confirm the payment
  confirmPayment(paymentIntentId: string): Observable<any> {
    return this.http.post(`${this.baseUrl}/confirm-payment`, { paymentIntentId });
  }
}
