import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  passwordError: string = '';

  onSubmit() {
     this.passwordError = '';
    const password = this.password;

    if (!password || password.length < 6) {
      this.passwordError = 'Password must be at least 6 characters long.';
      return;
    }
    if (!/[A-Z]/.test(password)) {
      this.passwordError = 'Password must contain at least one uppercase letter.';
      return;
    }
    if (!/[a-z]/.test(password)) {
      this.passwordError = 'Password must contain at least one lowercase letter.';
      return;
    }
    if (!/[0-9]/.test(password)) {
      this.passwordError = 'Password must contain at least one number.';
      return;
    }
    if (!/[!@#$%^&*(),.?":{}|<>]/.test(password)) {
      this.passwordError = 'Password must contain at least one Symbol.';
      return;
    }
    console.log('Email:', this.email);
    console.log('Password:', this.password);
  }
}