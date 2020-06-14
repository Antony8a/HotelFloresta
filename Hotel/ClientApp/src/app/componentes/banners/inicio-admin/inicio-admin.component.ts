import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { first } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-inicio-admin',
  templateUrl: './inicio-admin.component.html',
  styleUrls: ['./inicio-admin.component.css']
})
export class InicioAdminComponent implements OnInit {

  productoc: boolean;
  clientec: boolean;
  recepcionistac: boolean;
  habitacionc: boolean;
  reservasc: boolean;
  clienteRegistroc: boolean;
  facturaC:boolean;
  alternkey: boolean = false;
  inicioo: boolean = true;
  loading = false;
  submitted = false;
  constructor(
    private authenticationService: AuthenticationService,private router: Router
  ) { }

  ngOnInit(): void {
    document.getElementById("ini").style.backgroundColor = '#a53cb580';
    
      
  }

  CerrarSesion(){
    this.authenticationService.logout();
    this.router.navigate(['login']);
  }

  
  Close() {
    
    if (this.inicioo = true) {
      this.recepcionistac = false;
      this.clientec = false;
      this.productoc = false;
      this.habitacionc = false;
      this.reservasc = false;
      this.facturaC = false;
      document.getElementById("ini").style.backgroundColor = '#a53cb580';
      document.getElementById("client").style.backgroundColor = 'transparent';
      document.getElementById("recep").style.backgroundColor = 'transparent';
      document.getElementById("reser").style.backgroundColor = 'transparent';
      document.getElementById("habit").style.backgroundColor = 'transparent';
      document.getElementById("prod").style.backgroundColor = 'transparent';
      document.getElementById("fact").style.backgroundColor = 'transparent';
    }else
    this.inicioo = false;
    this.recepcionistac = false;
    this.clientec = false;
    this.productoc = false;
    this.habitacionc = false;
    this.reservasc = false;
    this.facturaC = false;
  }

  changeProducto() {

    if (this.productoc) {
      document.getElementById("client").style.backgroundColor = 'transparent';
      document.getElementById("recep").style.backgroundColor = 'transparent';
      document.getElementById("reser").style.backgroundColor = 'transparent';
      document.getElementById("habit").style.backgroundColor = 'transparent';
      document.getElementById("ini").style.backgroundColor = 'transparent';
      document.getElementById("fact").style.backgroundColor = 'transparent';
      this.facturaC = false;
      this.recepcionistac = false;
      this.clientec = false;
      this.productoc = true;
      this.habitacionc = false;
      this.reservasc = false;
      this.inicioo = false;
    }

    else
      document.getElementById("client").style.backgroundColor = 'transparent';
    document.getElementById("recep").style.backgroundColor = 'transparent';
    document.getElementById("reser").style.backgroundColor = 'transparent';
    document.getElementById("habit").style.backgroundColor = 'transparent';
    document.getElementById("ini").style.backgroundColor = 'transparent';
    document.getElementById("prod").style.backgroundColor = '#a53cb580';
    document.getElementById("fact").style.backgroundColor = 'transparent';
    this.facturaC = false;
    this.clientec = false;
    this.productoc = true;
    this.recepcionistac = false;
    this.habitacionc = false;
    this.reservasc = false;
    this.inicioo = false;
  }

  changeCliente() {

    if (this.clientec) {
      document.getElementById("prod").style.backgroundColor = 'transparent';
      document.getElementById("recep").style.backgroundColor = 'transparent';
      document.getElementById("reser").style.backgroundColor = 'transparent';
      document.getElementById("habit").style.backgroundColor = 'transparent';
      document.getElementById("ini").style.backgroundColor = 'transparent';
      document.getElementById("fact").style.backgroundColor = 'transparent';
      this.facturaC = false;
      this.recepcionistac = false;
      this.clientec = true;
      this.productoc = false;
      this.habitacionc = false;
      this.reservasc = false;
      this.inicioo = false;
    }
    else
      document.getElementById("prod").style.backgroundColor = 'transparent';
    document.getElementById("recep").style.backgroundColor = 'transparent';
    document.getElementById("reser").style.backgroundColor = 'transparent';
    document.getElementById("habit").style.backgroundColor = 'transparent';
    document.getElementById("ini").style.backgroundColor = 'transparent';
    document.getElementById("client").style.backgroundColor = '#a53cb580';
    document.getElementById("fact").style.backgroundColor = 'transparent';
    this.facturaC = false;
    this.clientec = true;
    this.productoc = false;
    this.recepcionistac = false;
    this.habitacionc = false;
    this.reservasc = false;
    this.inicioo = false;
  }

  changeRecepcionista() {

    if (this.recepcionistac) {
      document.getElementById("prod").style.backgroundColor = 'transparent';
      document.getElementById("client").style.backgroundColor = 'transparent';
      document.getElementById("reser").style.backgroundColor = 'transparent';
      document.getElementById("habit").style.backgroundColor = 'transparent';
      document.getElementById("ini").style.backgroundColor = 'transparent';
      document.getElementById("fact").style.backgroundColor = 'transparent';
      this.facturaC = false;
      this.recepcionistac = true;
      this.clientec = false;
      this.productoc = false;
      this.habitacionc = false;
      this.reservasc = false;
      this.inicioo = false;
    }
    else
      document.getElementById("prod").style.backgroundColor = 'transparent';
    document.getElementById("client").style.backgroundColor = 'transparent';
    document.getElementById("reser").style.backgroundColor = 'transparent';
    document.getElementById("habit").style.backgroundColor = 'transparent';
    document.getElementById("ini").style.backgroundColor = 'transparent';
    document.getElementById("recep").style.backgroundColor = '#a53cb580';
    document.getElementById("fact").style.backgroundColor = 'transparent';
    this.facturaC = false;
    this.recepcionistac = true;
    this.clientec = false;
    this.productoc = false;
    this.habitacionc = false;
    this.reservasc = false;
    this.inicioo = false;
  }

  changeReserva() {

    if (this.recepcionistac) {
      document.getElementById("prod").style.backgroundColor = 'transparent';
      document.getElementById("client").style.backgroundColor = 'transparent';
      document.getElementById("recep").style.backgroundColor = 'transparent';
      document.getElementById("habit").style.backgroundColor = 'transparent';
      document.getElementById("ini").style.backgroundColor = 'transparent';
      document.getElementById("fact").style.backgroundColor = 'transparent';
      this.facturaC = false;
      this.recepcionistac = true;
      this.clientec = false;
      this.productoc = false;
      this.habitacionc = false;
      this.reservasc = false;
      this.inicioo = false;
    }
    else
      document.getElementById("prod").style.backgroundColor = 'transparent';
    document.getElementById("client").style.backgroundColor = 'transparent';
    document.getElementById("recep").style.backgroundColor = 'transparent';
    document.getElementById("habit").style.backgroundColor = 'transparent';
    document.getElementById("ini").style.backgroundColor = 'transparent';
    document.getElementById("reser").style.backgroundColor = '#a53cb580';
    document.getElementById("fact").style.backgroundColor = 'transparent';
    this.facturaC = false;
    this.recepcionistac = false;
    this.clientec = false;
    this.productoc = false;
    this.habitacionc = false;
    this.reservasc = true;
    this.inicioo = false;
  }

  changeHabitacion() {
    if (this.habitacionc) {
      document.getElementById("prod").style.backgroundColor = 'transparent';
      document.getElementById("client").style.backgroundColor = 'transparent';
      document.getElementById("recep").style.backgroundColor = 'transparent';
      document.getElementById("reser").style.backgroundColor = 'transparent';
      document.getElementById("ini").style.backgroundColor = 'transparent';
      document.getElementById("fact").style.backgroundColor = 'transparent';
      this.facturaC = false;
      this.recepcionistac = false;
      this.clientec = false;
      this.productoc = false;
      this.habitacionc = true;
      this.reservasc = false;
      this.inicioo = false;
    }
    else
      document.getElementById("prod").style.backgroundColor = 'transparent';
    document.getElementById("client").style.backgroundColor = 'transparent';
    document.getElementById("recep").style.backgroundColor = 'transparent';
    document.getElementById("reser").style.backgroundColor = 'transparent';
    document.getElementById("ini").style.backgroundColor = 'transparent';
    document.getElementById("habit").style.backgroundColor = '#a53cb580';
    document.getElementById("fact").style.backgroundColor = 'transparent';
    this.facturaC = false;
    this.recepcionistac = false;
    this.clientec = false;
    this.productoc = false;
    this.habitacionc = true;
    this.reservasc = false;
    this.inicioo = false;
  }

  changeFactura() {
    if (this.facturaC) {
      document.getElementById("prod").style.backgroundColor = 'transparent';
      document.getElementById("client").style.backgroundColor = 'transparent';
      document.getElementById("recep").style.backgroundColor = 'transparent';
      document.getElementById("reser").style.backgroundColor = 'transparent';
      document.getElementById("ini").style.backgroundColor = 'transparent';
      document.getElementById("habit").style.backgroundColor = 'transparent';
      this.recepcionistac = false;
      this.clientec = false;
      this.productoc = false;
      this.habitacionc = false;
      this.reservasc = false;
      this.inicioo = false;
      this.facturaC = true;
    }
    else
      document.getElementById("prod").style.backgroundColor = 'transparent';
    document.getElementById("client").style.backgroundColor = 'transparent';
    document.getElementById("recep").style.backgroundColor = 'transparent';
    document.getElementById("reser").style.backgroundColor = 'transparent';
    document.getElementById("ini").style.backgroundColor = 'transparent';
    document.getElementById("habit").style.backgroundColor = 'transparent';
    document.getElementById("fact").style.backgroundColor = '#a53cb580';
    this.facturaC = true;
    this.recepcionistac = false;
    this.clientec = false;
    this.productoc = false;
    this.habitacionc = false;
    this.reservasc = false;
    this.inicioo = false;
  }

  changeRegistroCiente() {
    if (this.clienteRegistroc) {
      this.clienteRegistroc = true;
      this.recepcionistac = false;
      this.clientec = false;
      this.productoc = false;
      this.habitacionc = false;
      this.reservasc = false;
      this.inicioo = false;
      this.facturaC = false;
    }
    else
      this.clienteRegistroc = true;
    this.recepcionistac = false;
    this.clientec = false;
    this.productoc = false;
    this.habitacionc = true;
    this.reservasc = false;
    this.inicioo = false;
    this.facturaC = false;
  }

  altern(): void {
    if (this.alternkey == true)
      this.alternkey = false;
    else {
      this.alternkey = true;
    }
  }

}
