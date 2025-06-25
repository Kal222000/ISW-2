import { Injectable } from '@angular/core';
import { LibroDTO } from '../services/libros.service';


@Injectable({
  providedIn: 'root'
})
export class CarritoService {
  private librosEnCarrito: LibroDTO[] = [];

  obtenerCarrito(): LibroDTO[] {
    return this.librosEnCarrito;
  }

  agregarLibro(libro: LibroDTO) {
    if (!this.librosEnCarrito.some(l => l.id === libro.id)) {
      this.librosEnCarrito.push(libro);
    }
  }

  eliminarLibro(ID: number) {
    this.librosEnCarrito = this.librosEnCarrito.filter(l => l.id !== ID);
  }

  limpiarCarrito() {
    this.librosEnCarrito = [];
  }
}
