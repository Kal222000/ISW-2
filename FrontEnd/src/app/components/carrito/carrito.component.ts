import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { CarritoService } from '../../services/carrito.service';
import { LibroDTO } from '../../services/libros.service';

@Component({
  selector: 'app-carrito',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './carrito.component.html',
  styleUrl: './carrito.component.css'
})
export class CarritoComponent {
  private _libros: LibroDTO[] = [];

  public get libros(): LibroDTO[] {
    return this._libros;
  }

  public set libros(libros: LibroDTO[]) {
    this._libros = libros;
  }

  constructor(private carritoService: CarritoService) {
    this.actualizarLibros();
  }

  actualizarLibros() {
    this._libros = this.carritoService.obtenerCarrito();
  }

  eliminarDelCarrito(libro: LibroDTO) {
    this.carritoService.eliminarLibro(libro.id);
    this.actualizarLibros();
  }
}

