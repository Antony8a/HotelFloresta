import { Component, OnInit } from '@angular/core';

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
  alternkey: boolean = false;
  inicioo: boolean = true;
  constructor() { }

  ngOnInit(): void {
    document.getElementById("ini").style.backgroundColor = '#a53cb580';
  }

  
  Close() {
    
    if (this.inicioo = true) {
      this.recepcionistac = false;
      this.clientec = false;
      this.productoc = false;
      this.habitacionc = false;
      this.reservasc = false;
      document.getElementById("ini").style.backgroundColor = '#a53cb580';
      document.getElementById("client").style.backgroundColor = 'transparent';
      document.getElementById("recep").style.backgroundColor = 'transparent';
      document.getElementById("reser").style.backgroundColor = 'transparent';
      document.getElementById("habit").style.backgroundColor = 'transparent';
      document.getElementById("prod").style.backgroundColor = 'transparent';
    }else
    this.inicioo = false;
    this.recepcionistac = false;
    this.clientec = false;
    this.productoc = false;
    this.habitacionc = false;
    this.reservasc = false;
  }

  changeProducto() {

    if (this.productoc) {
      document.getElementById("client").style.backgroundColor = 'transparent';
      document.getElementById("recep").style.backgroundColor = 'transparent';
      document.getElementById("reser").style.backgroundColor = 'transparent';
      document.getElementById("habit").style.backgroundColor = 'transparent';
      document.getElementById("ini").style.backgroundColor = 'transparent';
      this.recepcionistac = false;
      this.clientec = false;
      this.productoc = true;
      this.habitacionc = false;
      this.reservasc = false;
    }

    else
      document.getElementById("client").style.backgroundColor = 'transparent';
    document.getElementById("recep").style.backgroundColor = 'transparent';
    document.getElementById("reser").style.backgroundColor = 'transparent';
    document.getElementById("habit").style.backgroundColor = 'transparent';
    document.getElementById("ini").style.backgroundColor = 'transparent';
    document.getElementById("prod").style.backgroundColor = '#a53cb580';
    this.clientec = false;
    this.productoc = true;
    this.recepcionistac = false;
    this.habitacionc = false;
    this.reservasc = false;
  }

  changeCliente() {

    if (this.clientec) {
      document.getElementById("prod").style.backgroundColor = 'transparent';
      document.getElementById("recep").style.backgroundColor = 'transparent';
      document.getElementById("reser").style.backgroundColor = 'transparent';
      document.getElementById("habit").style.backgroundColor = 'transparent';
      document.getElementById("ini").style.backgroundColor = 'transparent';
      this.recepcionistac = false;
      this.clientec = true;
      this.productoc = false;
      this.habitacionc = false;
      this.reservasc = false;
    }
    else
      document.getElementById("prod").style.backgroundColor = 'transparent';
    document.getElementById("recep").style.backgroundColor = 'transparent';
    document.getElementById("reser").style.backgroundColor = 'transparent';
    document.getElementById("habit").style.backgroundColor = 'transparent';
    document.getElementById("ini").style.backgroundColor = 'transparent';
    document.getElementById("client").style.backgroundColor = '#a53cb580';
    this.clientec = true;
    this.productoc = false;
    this.recepcionistac = false;
    this.habitacionc = false;
    this.reservasc = false;
  }

  changeRecepcionista() {

    if (this.recepcionistac) {
      document.getElementById("prod").style.backgroundColor = 'transparent';
      document.getElementById("client").style.backgroundColor = 'transparent';
      document.getElementById("reser").style.backgroundColor = 'transparent';
      document.getElementById("habit").style.backgroundColor = 'transparent';
      document.getElementById("ini").style.backgroundColor = 'transparent';
      this.recepcionistac = true;
      this.clientec = false;
      this.productoc = false;
      this.habitacionc = false;
      this.reservasc = false;
    }
    else
      document.getElementById("prod").style.backgroundColor = 'transparent';
    document.getElementById("client").style.backgroundColor = 'transparent';
    document.getElementById("reser").style.backgroundColor = 'transparent';
    document.getElementById("habit").style.backgroundColor = 'transparent';
    document.getElementById("ini").style.backgroundColor = 'transparent';
    document.getElementById("recep").style.backgroundColor = '#a53cb580';
    this.recepcionistac = true;
    this.clientec = false;
    this.productoc = false;
    this.habitacionc = false;
    this.reservasc = false;
  }

  changeReserva() {

    if (this.recepcionistac) {
      document.getElementById("prod").style.backgroundColor = 'transparent';
      document.getElementById("client").style.backgroundColor = 'transparent';
      document.getElementById("recep").style.backgroundColor = 'transparent';
      document.getElementById("habit").style.backgroundColor = 'transparent';
      document.getElementById("ini").style.backgroundColor = 'transparent';
      this.recepcionistac = true;
      this.clientec = false;
      this.productoc = false;
      this.habitacionc = false;
      this.reservasc = false;
    }
    else
      document.getElementById("prod").style.backgroundColor = 'transparent';
    document.getElementById("client").style.backgroundColor = 'transparent';
    document.getElementById("recep").style.backgroundColor = 'transparent';
    document.getElementById("habit").style.backgroundColor = 'transparent';
    document.getElementById("ini").style.backgroundColor = 'transparent';
    document.getElementById("reser").style.backgroundColor = '#a53cb580';
    this.recepcionistac = false;
    this.clientec = false;
    this.productoc = false;
    this.habitacionc = false;
    this.reservasc = true;
  }

  changeHabitacion() {
    if (this.habitacionc) {
      document.getElementById("prod").style.backgroundColor = 'transparent';
      document.getElementById("client").style.backgroundColor = 'transparent';
      document.getElementById("recep").style.backgroundColor = 'transparent';
      document.getElementById("reser").style.backgroundColor = 'transparent';
      document.getElementById("ini").style.backgroundColor = 'transparent';
      this.recepcionistac = false;
      this.clientec = false;
      this.productoc = false;
      this.habitacionc = true;
      this.reservasc = false;
    }
    else
      document.getElementById("prod").style.backgroundColor = 'transparent';
    document.getElementById("client").style.backgroundColor = 'transparent';
    document.getElementById("recep").style.backgroundColor = 'transparent';
    document.getElementById("reser").style.backgroundColor = 'transparent';
    document.getElementById("ini").style.backgroundColor = 'transparent';
    document.getElementById("habit").style.backgroundColor = '#a53cb580';
    this.recepcionistac = false;
    this.clientec = false;
    this.productoc = false;
    this.habitacionc = true;
    this.reservasc = false;
  }

  changeRegistroCiente() {
    if (this.clienteRegistroc) {
      this.clienteRegistroc = true;
      this.recepcionistac = false;
      this.clientec = false;
      this.productoc = false;
      this.habitacionc = false;
      this.reservasc = false;
    }
    else
      this.clienteRegistroc = true;
    this.recepcionistac = false;
    this.clientec = false;
    this.productoc = false;
    this.habitacionc = true;
    this.reservasc = false;
  }

  altern(): void {
    if (this.alternkey == true)
      this.alternkey = false;
    else {
      this.alternkey = true;
    }
  }

}
