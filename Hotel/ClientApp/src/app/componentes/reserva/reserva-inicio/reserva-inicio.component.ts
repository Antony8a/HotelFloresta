import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { HabitacionService } from 'src/app/services/habitacion.service';
import { ReservaService } from 'src/app/services/reserva.service';
import { Habitacion } from 'src/app/models/habitacion';
import { Reserva } from 'src/app/models/reserva';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';

interface Food {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-reserva-inicio',
  templateUrl: './reserva-inicio.component.html',
  styleUrls: ['./reserva-inicio.component.css']
})
export class ReservaInicioComponent implements OnInit {

  modal: boolean = false;
  prueba1:Date;
  prueba2:Date;
  baderilla:number=0;
  validadorFechasIguales:number = 0;

  //esto es de la gestion de reserva
  formGroup: FormGroup;
  reserva:Reserva;
  habitaciones:Habitacion[];
  habitacionesDisponibles:Habitacion[] = [];
  habitacion:Habitacion;
  reservas:Reserva[];
    //
      eventsInicio: string[] = [];
      eventsFin: string[] = [];
    //

  //esto es de la gestion de reserva

  foods: Food[] = [
    {value: 'steak-0', viewValue: 'King'},
    {value: 'pizza-1', viewValue: 'KingDoble'},
    {value: 'tacos-2', viewValue: 'KingKing'}
  ];

  constructor(
    private location: Location,
    private reservaService: ReservaService,
    private habitacionService: HabitacionService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit(): void {
    this.traerHabitaciones();
    this.traerReservas();
  }

  traerHabitaciones() {
    this.habitacionService.get().subscribe(result => {
      this.habitaciones = result;
    });
  }

  traerReservas(){
    this.reservaService.get().subscribe(result =>{
      this.reservas = result;
    });
  }

  change(){
    if(this.modal)
      this.modal=false;
    else
      this.modal=true;
  }

  goBack(){
    // window.history.back();
    this.location.back();
  }

  //gestionando reservas
  addEventInicio(type: string, event: MatDatepickerInputEvent<Date>) {
    this.prueba1 = event.value;
    this.eventsInicio.push(`${type}: ${event.value}`);
  }

  addEventFin(type: string, event: MatDatepickerInputEvent<Date>) {
    this.eventsFin.push(`${type}: ${event.value}`);
    this.prueba2 = event.value;
  }

  comprobadorfechas(){
    this.traerReservas();    
    this.traerHabitaciones();
    this.habitacionesDisponibles = this.habitaciones;
    this.habitaciones.forEach(hab=>{
      alert(''+hab.idHabitacion);
      this.reservas.forEach(item => {        
        var toma1 =new Date(this.prueba1);
        var toma2 =new Date(this.prueba2);
        var fechaI = new Date(item.fechaInicio);
        var fechaF = new Date(item.fechaFin);        
        if(toma1 > fechaI && toma1 < fechaF && hab.idHabitacion==item.idHabitacion ||
           toma2 > fechaI && toma2 < fechaF && hab.idHabitacion==item.idHabitacion ){
            for(var i = this.habitacionesDisponibles.length - 1; i >= 0; i--) {
              if(this.habitacionesDisponibles[i].idHabitacion === item.idHabitacion) {
                 this.habitacionesDisponibles.splice(i, 1);
              }
            }
          }
      });    
    });
  }

  // onSubmit() {
  //   if (this.formGroup.invalid) {
  //     return;
  //   }
  //   var unu = this.comprobadorfechas();
  //   var uwu = this.fechaCorrecta();
  //   if(unu>=1){
  //     const messageBox = this.modalService.open(AlertModalComponent)
  //       messageBox.componentInstance.title = "Resultado Operación";
  //       messageBox.componentInstance.message = 'Ya hay una reserva en esta fecha :c';        
  //   }else if(uwu>=1){                
  //     const messageBox = this.modalService.open(AlertModalComponent)
  //     messageBox.componentInstance.title = "Resultado Operación";
  //     messageBox.componentInstance.message = 'la fecha final debe ser mayor a la fecha inicial';
  //   }else{
  //     this.add();
  //   }
  // }
  
  fechaCorrecta():number{
    this.reserva=this.formGroup.value;
    var toma1 =new Date(this.reserva.fechaInicio);
    var toma2 =new Date(this.reserva.fechaFin);

    if(toma1>toma2){
      this.validadorFechasIguales=this.validadorFechasIguales+1;
    }
    return this.validadorFechasIguales;
  }

  add(){
    const messageBox = this.modalService.open(AlertModalComponent)
    messageBox.componentInstance.title = "Resultado Operación";
    messageBox.componentInstance.message = 'la fecha final debe ser mayor a la fecha inicial';
  }

}
