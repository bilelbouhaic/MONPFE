import { Component,NgModule } from '@angular/core';
import { Login } from '../login';
import { Register } from '../register';
import { JwtAuth } from '../jwtAuth';
import { FormsModule } from '@angular/forms';
import { AuthenticationService } from '../authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginDto =new Login();
  registerDto =new Register();
  jwtDto = new JwtAuth();

  
  constructor(private authService: AuthenticationService, private router: Router) {}

  register(registerDto: any): void {
    this.authService.register(registerDto).subscribe(
      response => {
        // Handle registration success
        console.log('Registration successful');
      },
      error => {
        // Handle registration error
        console.error('Registration failed');
      }
    );
  }

  login(loginDto: any): void {
    this.authService.login(loginDto).subscribe(
      response => {
        // Store the JWT token in local storage
        localStorage.setItem('jwtToken', response.token);

        // Navigate to /Application
        this.router.navigate(['/Application/Calcul']);
      },
      error => {
        // Handle login error
        console.error('Login failed');
      }
    );
  }

getWilaya(){
  this.authService.getWilaya().subscribe((wilayadata:any)=>{
    console.log(wilayadata);
    
  })
}

}
