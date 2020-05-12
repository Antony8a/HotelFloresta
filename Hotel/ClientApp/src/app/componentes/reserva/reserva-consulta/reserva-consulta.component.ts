import { Component, OnInit } from '@angular/core';
import { Reserva } from 'src/app/models/reserva';
import { ReservaService } from 'src/app/services/reserva.service';

@Component({
  selector: 'app-reserva-consulta',
  templateUrl: './reserva-consulta.component.html',
  styleUrls: ['./reserva-consulta.component.css']
})
export class ReservaConsultaComponent implements OnInit {

  reservas:Reserva[];
  reserva:Reserva;
  searchText:number;
  constructor(private reservaService: ReservaService) { }

  ngOnInit(){
    this.reservaService.get().subscribe(result => {
      this.reservas = result;
    });
  }

}
