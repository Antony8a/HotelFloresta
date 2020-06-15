import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-inicio-cliente',
  templateUrl: './inicio-cliente.component.html',
  styleUrls: ['./inicio-cliente.component.css']
})
export class InicioClienteComponent implements OnInit {

  productoc: boolean;
  clientec: boolean;
  recepcionistac: boolean;
  habitacionc: boolean;
  reservasc: boolean;
  clienteRegistroc: boolean;
  alternkey: boolean = false;
  inicioo: boolean = true;

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router
  ) { }

  ngOnInit(): void {
    document.getElementById("client").style.backgroundColor = '#a53cb580';
  }

  CerrarSesion(){
    this.authenticationService.logout();
    this.router.navigate(['login']);
  }

  changeCliente() {

    if (this.clientec) {
      document.getElementById("client").style.backgroundColor = 'transparent';
      document.getElementById("reser").style.backgroundColor = 'transparent';
      this.reservasc = false;
      this.clientec = true;
    }
    else
    document.getElementById("reser").style.backgroundColor = 'transparent';
    document.getElementById("client").style.backgroundColor = '#a53cb580';
    this.clientec = true;
    this.reservasc = false;
  }

  changeReserva() {

    if (this.reservasc) {
      document.getElementById("client").style.backgroundColor = 'transparent';
      document.getElementById("reser").style.backgroundColor = 'transparent';
      this.clientec = false;
      this.reservasc = false;
    }
    else
    document.getElementById("client").style.backgroundColor = 'transparent';
    document.getElementById("reser").style.backgroundColor = '#a53cb580';
    this.clientec = false;
    this.reservasc = true;
  }

  altern(): void {
    if (this.alternkey == true)
      this.alternkey = false;
    else {
      this.alternkey = true;
    }
  }

}
