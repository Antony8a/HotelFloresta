import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { HabitacionService } from 'src/app/services/habitacion.service';
import { ReservaService } from 'src/app/services/reserva.service';
import { Habitacion } from 'src/app/models/habitacion';

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
  prueba:string;

  habitaciones: Habitacion[];
  foods: Food[] = [
    {value: 'steak-0', viewValue: 'King'},
    {value: 'pizza-1', viewValue: 'KingDoble'},
    {value: 'tacos-2', viewValue: 'KingKing'}
  ];

  constructor(private location: Location,
    private habitacionService: HabitacionService,
    private reservaService: ReservaService,
    ) { }

  ngOnInit(): void {
    this.traerHabitaciones();
  }

  traerHabitaciones() {
    this.habitacionService.get().subscribe(result => {
      this.habitaciones = result;

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

  pruebaDatapic(pic1:Date, pic2:Date){
    this.prueba = (pic1+" "+pic2);
  }

}
