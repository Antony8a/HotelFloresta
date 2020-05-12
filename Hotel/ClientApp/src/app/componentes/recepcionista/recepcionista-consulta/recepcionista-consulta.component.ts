import { Component, OnInit } from '@angular/core';
import { Recepcionista } from 'src/app/models/recepcionista';
import { RecepcionistaService } from 'src/app/services/recepcionista.service';

@Component({
  selector: 'app-recepcionista-consulta',
  templateUrl: './recepcionista-consulta.component.html',
  styleUrls: ['./recepcionista-consulta.component.css']
})
export class RecepcionistaConsultaComponent implements OnInit {

  recepcionistas:Recepcionista[];
  recepcionista:Recepcionista;
  searchText:string;
  constructor(private recepcionistaService: RecepcionistaService) { }

  ngOnInit() {
    this.recepcionistaService.get().subscribe(result => {
      this.recepcionistas = result;
    });
  }

}
