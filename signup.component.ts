import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [FormsModule, HttpClientModule],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {
  user = { fullName: '', email: '', password: '', confirmPassword: '' };
  onSubmit() {
    if (this.user.password !== this.user.confirmPassword) {
      alert('Passwords do not match.');
      return;
    }

    // Replace 'your-backend-url' with the actual API endpoint
    // this.http.post('your-backend-url/api/signup', this.user).subscribe({
    //   next: (response) => {
    //     alert('Registration successful!');
    //     console.log(response);
    //   },
    //   error: (err) => {
    //     alert('Registration failed. Please try again.');
    //     console.error(err);
    //   },
    // });
  }
}
