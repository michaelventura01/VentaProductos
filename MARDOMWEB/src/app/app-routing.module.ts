import { TiendaComponent } from './tienda/tienda.component';
import { ProductosComponent } from './productos/productos.component';
import { ComprasComponent } from './compras/compras.component';
import { FacturasComponent } from './facturas/facturas.component';
import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule, Router } from '@angular/router';
import { LoginComponent } from './login/login.component';



const routes: Routes = [
  {path: '', component: LoginComponent },
  {path: 'facturas', component: FacturasComponent},
  {path: 'compras', component: ComprasComponent },
  {path: 'productos', component: ProductosComponent },
  {path: 'tienda', component: TiendaComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {


}
