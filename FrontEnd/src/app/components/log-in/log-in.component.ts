import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AutentificacionService, CredencialesDTO } from '../../services/autentificacion.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-log-in',
  imports: [FormsModule, RouterLink],
  templateUrl: './log-in.component.html',
  styleUrl: './log-in.component.css'
})

export class LogInComponent {

  private usuario: CredencialesDTO = { Carnet: 0, Contrasena: '' };
  private mensaje: string = '';
  private mostrarContrasena: boolean = false;
  constructor(
    private autentificacionService: AutentificacionService,
    private router: Router
  ) { }

  public getUsuario() {
    return this.usuario;
  }

  public getMensaje() {
    return this.mensaje;
  }

  public getMostrarContrasena() {
    return this.mostrarContrasena;
  }

  public alternarMostrarContrasena() {
    this.mostrarContrasena = !this.mostrarContrasena;
  }

  
  verificarCredenciales() {
    //this.router.navigate(['/pagina-principal']);

    const credenciales: CredencialesDTO = {
      Carnet: this.usuario.Carnet,
      Contrasena: this.usuario.Contrasena
    };
    //llamamos al metodo login
    //subscribe() se usa por que esperamos una respuesta del backend al usar Observable
    
    this.autentificacionService.login(credenciales).subscribe({
      //subscribe tiene dos posibles respuestas: next o error
      next: (respuesta) => {
        if (respuesta != null) {
          // Puedes guardar el usuario si quieres, y redirigir
          this.router.navigate(['/pagina-principal']);
        } else {
          this.mensaje = 'CI o contraseña incorrectos';
        }
      },
      error: (err: HttpErrorResponse) => {
        console.error('Error detalle:', err);

        if (err.error && typeof err.error === 'string') {
          // Si el backend devuelve un mensaje de error en texto plano
          this.mensaje = err.error;
        } else if (err.error && err.error.message) {
          // Si el backend devuelve un objeto JSON con propiedad message
          this.mensaje = err.error.message;
        } else {
          // Mensaje genérico para otros casos
          this.mensaje = `Error ${err.status}: ${err.statusText}`;
        }
      }
    });

    // Limpiar campos después del intento
    this.usuario.Carnet = 0;
    this.usuario.Contrasena = '';
   
  }
  
}
