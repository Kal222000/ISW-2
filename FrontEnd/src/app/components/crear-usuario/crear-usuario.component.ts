import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NuevoUsuarioDTO, AutentificacionService } from '../../services/autentificacion.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-crear-usuario',
  imports: [FormsModule],
  templateUrl: './crear-usuario.component.html',
  styleUrl: './crear-usuario.component.css'
})
export class CrearUsuarioComponent {

  private nuevoUsuario: NuevoUsuarioDTO = {
    Nombre: '',
    ApellidoPaterno: '',
    ApellidoMaterno: '',
    FechaNacimiento: '',
    Carnet: 0, // ← Usa number si el backend espera un entero
    Contrasena: ''
  };

  private mensaje: string = '';
  private mostrarContrasena: boolean = false;
  //console.log("Datos a enviar:", this.getNuevoUsuario());
  
  constructor(
    private authService: AutentificacionService,
    private router: Router
  ) { }

  public getMensaje() {
    return this.mensaje;
  }

  public getNuevoUsuario() {
    return this.nuevoUsuario;
  }

  public getMostrarContrasena() {
    return this.mostrarContrasena;
  }

  public alternarMostrarContrasena() {
    this.mostrarContrasena = !this.mostrarContrasena;
  }

  public confirmarUsuario() {
    console.log("Datos a enviar:", this.nuevoUsuario);
    this.authService.crearUsuario(this.nuevoUsuario).subscribe({
      next: (respuesta) => {
        if (respuesta) {
          this.mensaje = 'Usuario creado exitosamente.';
          // Redirigir al login si quieres:
          this.router.navigate(['/']);
        } else {
          this.mensaje = 'No se pudo crear el usuario.';
        }
      },
      error: (error) => {
        console.error('Error creando usuario:', error);
        this.mensaje = error.error || 'Error del servidor al crear el usuario.';
      }
    });
    console.log(this.nuevoUsuario.FechaNacimiento)
    // Limpiar campos
    this.nuevoUsuario = {
      Nombre: '',
      ApellidoPaterno: '',
      ApellidoMaterno: '',
      FechaNacimiento: '',
      Carnet: 0,
      Contrasena: ''
    };
  }
}
