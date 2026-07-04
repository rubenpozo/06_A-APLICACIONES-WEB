import { Component } from '@angular/core';
import { AuthService } from '../services/auth';

@Component({
  selector: 'app-login',
  templateUrl: './login.html',
  styleUrls: ['./login.css']
})
export class LoginComponent {
  username = '';
  password = '';
  message = '';

  constructor(private authService: AuthService) {}

  login() {
    this.authService.login(this.username, this.password).subscribe({
      next: (res) => {
        // Guardar sesión
        this.authService.saveSession(res.username, res.token);
        this.message = '✅ Login exitoso';
      },
      error: () => {
        this.message = '❌ Credenciales inválidas';
      }
    });
  }
}
