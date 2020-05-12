import { Component, OnInit } from '@angular/core';
import { Habitacion } from 'src/app/models/habitacion';
import { HabitacionService } from 'src/app/services/habitacion.service';

@Component({
  selector: 'app-habitacion-consulta',
  templateUrl: './habitacion-consulta.component.html',
  styleUrls: ['./habitacion-consulta.component.css']
})
export class HabitacionConsultaComponent implements OnInit {

  habitaciones:Habitacion[];
  habitacion:Habitacion;
  searchText:string;
  constructor(private habitacionService: HabitacionService) { }

  ngOnInit() {
    this.habitacionService.get().subscribe(result => {
      this.habitaciones = result;
    });
  }

}
