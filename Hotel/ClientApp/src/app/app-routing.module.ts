import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { ClienteRegistroComponent } from './componentes/cliente/cliente-registro/cliente-registro.component';
import { ClienteConsultaComponent } from './componentes/cliente/cliente-consulta/cliente-consulta.component';
import { ClienteEditaComponent } from './componentes/cliente/cliente-edita/cliente-edita.component';
import { RecepcionistaRegistroComponent } from './componentes/recepcionista/recepcionista-registro/recepcionista-registro.component';
import { RecepcionistaConsultaComponent } from './componentes/recepcionista/recepcionista-consulta/recepcionista-consulta.component';
import { RecepcionistaEditaComponent } from './componentes/recepcionista/recepcionista-edita/recepcionista-edita.component';
import { ProductoEditaComponent } from './componentes/producto/producto-edita/producto-edita.component';
import { ProductoConsultaComponent } from './componentes/producto/producto-consulta/producto-consulta.component';
import { ProductoRegistroComponent } from './componentes/producto/producto-registro/producto-registro.component';
import { HabitacionRegistroComponent } from './componentes/habitacion/habitacion-registro/habitacion-registro.component';
import { HabitacionConsultaComponent } from './componentes/habitacion/habitacion-consulta/habitacion-consulta.component';
import { ReservaRegistroComponent } from './componentes/reserva/reserva-registro/reserva-registro.component';
import { HomeComponent } from './home/home.component';
import { HabitacionEditaComponent } from './componentes/habitacion/habitacion-edita/habitacion-edita.component';
import { ReservaConsultaComponent } from './componentes/reserva/reserva-consulta/reserva-consulta.component';
import { ReservaEditaComponent } from './componentes/reserva/reserva-edita/reserva-edita.component';
import { InicioAdminComponent } from './componentes/banners/inicio-admin/inicio-admin.component';

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent
  },
  
  // cliente-------------------------------------------------------------------------------------------------

  {
    path: 'clienteRegistro',
    component: ClienteRegistroComponent
  },
  {
    path: 'clienteConsulta',
    component: ClienteConsultaComponent
  },
  {
    path: 'clienteEdita/:id',
    component: ClienteEditaComponent
  },

  // recepcionista--------------------------------------------------------------------------------------
  {
    path: 'recepcionistaConsulta',
    component: RecepcionistaConsultaComponent 
  },
  {
    path: 'recepcionistaEdita/:id',
    component: RecepcionistaEditaComponent
  },
  {
    path: 'recepcionistaRegistro',
    component: RecepcionistaRegistroComponent 
  },

  // producto--------------------------------------------------------------------------------------------

  {
    path: 'productoEdita/:id',
    component: ProductoEditaComponent 
  },
  {
    path: 'productoConsulta',
    component: ProductoConsultaComponent 
  },
  {
    path: 'productoRegistra',
    component: ProductoRegistroComponent    
  },

  // habitacion-----------------------------------------------------------------------------------------

  {
    path: 'habitacionRegistro',
    component: HabitacionRegistroComponent
  },
  {
    path: 'habitacionConsulta',
    component: HabitacionConsultaComponent
  },  
  {
    path: 'habitacionEdita/:id',
    component: HabitacionEditaComponent
  },

  // reserva--------------------------------------------------------------------------------------------

  {
    path: 'reservaRegistro',
    component: ReservaRegistroComponent 
  },
  {
    path: 'reservaConsulta',
    component: ReservaConsultaComponent
  },
  {
    path: 'reservaEdita/:id',
    component: ReservaEditaComponent 
  },
  {
    path: 'inicioAdmin',
    component: InicioAdminComponent 
  },


]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
 
})
export class AppRoutingModule { }
