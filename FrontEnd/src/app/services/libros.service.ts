import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface LibroDTO {
  id: number;
  titulo: string;
  autor: string;
  favorito : string,
}

@Injectable({
  providedIn: 'root'
})
export class LibrosService {

  private apiUrl = 'http://localhost:5273/api/libro';

  constructor(private http: HttpClient) { }

  obtenerLibros(): Observable<LibroDTO[]> {
    return this.http.get<LibroDTO[]>(`${this.apiUrl}/DevolverLibros`);
  }

  MarcarFavorito(LibroDTO: LibroDTO): Observable<any> {
      return this.http.post(`${this.apiUrl}/Marcar`, LibroDTO);
  }
}
