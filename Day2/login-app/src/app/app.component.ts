import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoginComponent } from './login/login.component'; // Import LoginComponent

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ LoginComponent], // Import LoginComponent here
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'GCET';
}
