import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-inicio-admin',
  templateUrl: './inicio-admin.component.html',
  styleUrls: ['./inicio-admin.component.css']
})
export class InicioAdminComponent implements OnInit {

  productoc: boolean;
  clientec: boolean;
  recepcionistac:boolean;
  habitacionc:boolean;
  reservasc:boolean;
  clienteRegistroc:boolean;
  alternkey:boolean=false;

  constructor() { }

  ngOnInit(): void {
  }

  Close(){
    this.recepcionistac=false;
      this.clientec=false;
      this.productoc=false;
      this.habitacionc=false;
      this.reservasc=false;
  }

  changeProducto(){
    
    if(this.productoc){

      this.recepcionistac=false;
      this.clientec=false;
      this.productoc=true;
      this.habitacionc=false;
      this.reservasc=false;
    }
      
    else
    this.clientec=false;
      this.productoc=true;
      this.recepcionistac=false;
      this.habitacionc=false;
      this.reservasc=false;
  }

  changeCliente(){
    
    if(this.clientec){

      this.recepcionistac=false;
      this.clientec=true;
      this.productoc=false;
      this.habitacionc=false;
      this.reservasc=false;
    }  
    else
      this.clientec=true;
      this.productoc=false;
      this.recepcionistac=false;
      this.habitacionc=false;
      this.reservasc=false;
  }

  changeRecepcionista(){
    
    if(this.recepcionistac){

      this.recepcionistac=true;
      this.clientec=false;
      this.productoc=false;
      this.habitacionc=false;
      this.reservasc=false;
    }  
    else
    this.recepcionistac=true;
      this.clientec=false;
      this.productoc=false;
      this.habitacionc=false;
      this.reservasc=false;
  }

  changeReserva(){

    if(this.recepcionistac){

      this.recepcionistac=true;
      this.clientec=false;
      this.productoc=false;
      this.habitacionc=false;
      this.reservasc=false;
    }  
    else
    this.recepcionistac=false;
    this.clientec=false;
    this.productoc=false;
    this.habitacionc=false;
    this.reservasc=true;
  }

  changeHabitacion(){
    if(this.habitacionc){

      this.recepcionistac=false;
      this.clientec=false;
      this.productoc=false;
      this.habitacionc=true;
      this.reservasc=false;
    }  
    else
    this.recepcionistac=false;
    this.clientec=false;
    this.productoc=false;
    this.habitacionc=true;
    this.reservasc=false;
  }

  changeRegistroCiente(){
    if(this.clienteRegistroc){
      this.clienteRegistroc=true;
      this.recepcionistac=false;
      this.clientec=false;
      this.productoc=false;
      this.habitacionc=false;
      this.reservasc=false;
    }  
    else
    this.clienteRegistroc=true;
    this.recepcionistac=false;
    this.clientec=false;
    this.productoc=false;
    this.habitacionc=true;
    this.reservasc=false;
  }

  altern():void{
    if(this.alternkey==true)
      this.alternkey = false;
    else{
      this.alternkey = true;
    }
  }

}
