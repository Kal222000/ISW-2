import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
export interface CredencialesDTO {
  Carnet: number;
  Contrasena: string;
}

export interface NuevoUsuarioDTO {
  Nombre: string;
  ApellidoPaterno: string;
  ApellidoMaterno: string;
  FechaNacimiento: string; 
  Carnet: number;
  Contrasena: string;
}

@Injectable({
  providedIn: 'root'
})
export class AutentificacionService {
  private apiUrl = 'http://localhost:5273/api/usuario'; 
  constructor(private http: HttpClient) { }

  // Envía los datos al backend y espera la respuesta
  login(credenciales: CredencialesDTO): Observable<any> {
    return this.http.post(`${this.apiUrl}/ValidarUsuario`, credenciales);
  }

  crearUsuario(nuevoUsuario: NuevoUsuarioDTO): Observable<boolean> {
    return this.http.post<boolean>(`${this.apiUrl}/CreacionCliente`, nuevoUsuario);
  }

}
