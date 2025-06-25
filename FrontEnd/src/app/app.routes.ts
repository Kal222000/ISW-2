// src/app/app.routes.ts
import { Routes } from '@angular/router';
import { LogInComponent } from './components/log-in/log-in.component';
import { CrearUsuarioComponent } from './components/crear-usuario/crear-usuario.component';
import { PaginaPrincipalComponent } from './components/pagina-principal/pagina-principal.component';
import { CarritoComponent } from './components/carrito/carrito.component';
import { HistorialComponent } from './components/historial/historial.component';

export const routes: Routes = [
  { path: '', component: LogInComponent },
  { path: 'crear-usuario', component: CrearUsuarioComponent },
  { path: 'pagina-principal', component: PaginaPrincipalComponent },
  { path: 'carrito', component: CarritoComponent },
  { path: 'historial', component: HistorialComponent }
];
