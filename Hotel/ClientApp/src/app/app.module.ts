import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ClienteConsultaComponent } from './componentes/cliente/cliente-consulta/cliente-consulta.component';
import { ClienteRegistroComponent } from './componentes/cliente/cliente-registro/cliente-registro.component';
import { ClienteEditaComponent } from './componentes/cliente/cliente-edita/cliente-edita.component';
import { ProductoConsultaComponent } from './componentes/producto/producto-consulta/producto-consulta.component';
import { ProductoRegistroComponent } from './componentes/producto/producto-registro/producto-registro.component';
import { ProductoEditaComponent } from './componentes/producto/producto-edita/producto-edita.component';
import { ReservaConsultaComponent } from './componentes/reserva/reserva-consulta/reserva-consulta.component';
import { ReservaRegistroComponent } from './componentes/reserva/reserva-registro/reserva-registro.component';
import { ReservaEditaComponent } from './componentes/reserva/reserva-edita/reserva-edita.component';
import { AppRoutingModule } from './app-routing.module';
import { AlertModalComponent } from './@base/alert-modal/alert-modal.component';
import { FiltroClientePipe } from './pipe/filtro-cliente.pipe';
import { FiltroRecepcionistaPipe } from './pipe/filtro-recepcionista.pipe';
import { FiltroHabitacionPipe } from './pipe/filtro-habitacion.pipe';
import { FiltroProductoPipe } from './pipe/filtro-producto.pipe';
import { FiltroReservaPipe } from './pipe/filtro-reserva.pipe';
import { RecepcionistaConsultaComponent } from './componentes/recepcionista/recepcionista-consulta/recepcionista-consulta.component';
import { RecepcionistaRegistroComponent } from './componentes/recepcionista/recepcionista-registro/recepcionista-registro.component';
import { RecepcionistaEditaComponent } from './componentes/recepcionista/recepcionista-edita/recepcionista-edita.component';
import { HabitacionConsultaComponent } from './componentes/habitacion/habitacion-consulta/habitacion-consulta.component';
import { HabitacionRegistroComponent } from './componentes/habitacion/habitacion-registro/habitacion-registro.component';
import { HabitacionEditaComponent } from './componentes/habitacion/habitacion-edita/habitacion-edita.component';
import { BannerAdminComponent } from './componentes/banners/banner-admin/banner-admin.component';
import { BannerClienteComponent } from './componentes/banners/banner-cliente/banner-cliente.component';
import { BannerRecepcionistaComponent } from './componentes/banners/banner-recepcionista/banner-recepcionista.component';
import { InicioHotelComponent } from './componentes/inicio-hotel/inicio-hotel.component';
import { LoginComponent } from './componentes/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ClienteConsultaComponent,
    ClienteRegistroComponent,
    ClienteEditaComponent,
    RecepcionistaConsultaComponent,
    RecepcionistaRegistroComponent,
    RecepcionistaEditaComponent,
    HabitacionConsultaComponent,
    HabitacionRegistroComponent,
    HabitacionEditaComponent,
    ProductoConsultaComponent,
    ProductoRegistroComponent,
    ProductoEditaComponent,
    ReservaConsultaComponent,
    ReservaRegistroComponent,
    ReservaEditaComponent,
    AlertModalComponent,
    FiltroClientePipe,
    FiltroRecepcionistaPipe,
    FiltroHabitacionPipe,
    FiltroProductoPipe,
    FiltroReservaPipe,
    BannerAdminComponent,
    BannerClienteComponent,
    BannerRecepcionistaComponent,
    InicioHotelComponent,
    LoginComponent,
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
    ]),
    NgbModule,
    AppRoutingModule
  ],
  entryComponents:[AlertModalComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
