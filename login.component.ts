import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule,HttpClientModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginObj: Login;
  constructor(private http: HttpClient,private router:Router){
    this.loginObj = new Login();
  }

  onLogin(){
    this.router.navigateByUrl('/dashboard')
    this.http.post('https://', this.loginObj).subscribe((res:any)=>{
      if(res.result){
        alert("Login Success");
        this.router.navigateByUrl('/dashboard')
      }
      else{
        alert(res.message)
      }
    })
  }
  onSignup(){
    this.router.navigateByUrl('/signup');
  }
}

export class Login{
    EmailId: string;
    Password: string;
    constructor(){
      this.EmailId='';
      this.Password='';
    }
}