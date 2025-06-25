import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CarritoService } from '../../services/carrito.service';
import { LibrosService, LibroDTO } from '../../services/libros.service';
import { OnInit } from '@angular/core';
import { NgIf, NgFor } from '@angular/common';

@Component({
  selector: 'app-pagina-principal',
  imports: [FormsModule, RouterLink, CommonModule],
  templateUrl: './pagina-principal.component.html',
  styleUrl: './pagina-principal.component.css'
})
export class PaginaPrincipalComponent implements OnInit {
  private _terminoBusqueda: string = '';

  private libros: LibroDTO[] = [];

  private librosMostrados: LibroDTO[] = [];

  private paginaActual: number = 1;

  private librosPorPagina: number = 5;

  private paginas: number[] = [];

  private mensajeAlerta: string = '';

  private _mensajeError: string = '';

  public get terminoBusqueda(): string {
    return this._terminoBusqueda;
  }

  public set terminoBusqueda(valor: string) {
    this._terminoBusqueda = valor;
  }

  public getLibros() {
    return this.libros;
  }

  public getLibrosMostrados() {
    return this.librosMostrados;
  }

  public getPaginaActual() {
    return this.paginaActual;
  }

  public getLibrosPorPagina() {
    return this.librosPorPagina;
  }

  public getPaginas() {
    return this.paginas;
  }

  public getMensajeAlerta() {
    return this.mensajeAlerta;
  }

  public get mensajeError(): string {
    return this._mensajeError;
  }

  public set mensajeError(valor: string) {
    this._mensajeError = valor;
  }
  
  constructor(
    private carritoService: CarritoService,
    private librosService: LibrosService
  ) { }

  ngOnInit() {
    this.librosService.obtenerLibros().subscribe({
      next: (libros) => {
        this.libros = libros;
        console.log('Libros cargados:', this.libros);
        this.buscarLibros(); 
      },
      error: (error) => {
        this._mensajeError = error.error?.message || 'No se pudieron cargar los libros desde el servidor.';
      }
    });
  }

  agregarAlCarrito(libro: LibroDTO) {
    const carrito = this.carritoService.obtenerCarrito();

    if (carrito.length >= 5) {
      this.mensajeAlerta = 'No puedes agregar más de 5 libros al carrito.';
      return;
    }

    if (carrito.some(c => c.id === libro.id)) {
      this.mensajeAlerta = 'Este libro ya está en el carrito.';
      return;
    }

    this.carritoService.agregarLibro(libro);
    this.mensajeAlerta = '';
    this.paginaActual = 1;
    this.buscarLibros();  // actualiza la vista
  }

  cerrarAlerta() {
    this.mensajeAlerta = '';
  }

  actualizarLibrosMostrados(listaFiltrada: LibroDTO[]) {
    const librosDisponibles = listaFiltrada.filter(libro =>
      !this.carritoService.obtenerCarrito().some(c => c.id === libro.id)
    );

    const startIndex = (this.paginaActual - 1) * this.librosPorPagina;
    const endIndex = startIndex + this.librosPorPagina;

    this.librosMostrados = librosDisponibles.slice(startIndex, endIndex);

    // Actualizar paginación con los libros disponibles
    const totalPaginas = Math.ceil(librosDisponibles.length / this.librosPorPagina);
    this.paginas = Array.from({ length: totalPaginas }, (_, i) => i + 1);
  }

  buscarLibros() {
    const filtrados = this.libros.filter(libro =>
      libro.titulo.toLowerCase().includes(this.terminoBusqueda.toLowerCase()) ||
      libro.autor.toLowerCase().includes(this.terminoBusqueda.toLowerCase())
    );

    console.log('Libros filtrados:', filtrados);
    this.actualizarLibrosMostrados(filtrados);
  }

  irAPagina(numero: number) {
    if (numero < 1 || numero > this.paginas.length) return;
    this.paginaActual = numero;
    this.buscarLibros();
  }
}
