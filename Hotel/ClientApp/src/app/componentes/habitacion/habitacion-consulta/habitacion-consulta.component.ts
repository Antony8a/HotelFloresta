import { Component, OnInit } from '@angular/core';
import { Habitacion } from 'src/app/models/habitacion';
import { HabitacionService } from 'src/app/services/habitacion.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-habitacion-consulta',
  templateUrl: './habitacion-consulta.component.html',
  styleUrls: ['./habitacion-consulta.component.css']
})
export class HabitacionConsultaComponent implements OnInit {

  habitaciones:Habitacion[];
  habitacion:Habitacion;
  searchText:string;
  closeResult: string;
  constructor(
    private habitacionService: HabitacionService,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.habitacionService.get().subscribe(result => {
      this.habitaciones = result;
    });
  }

  delete(identificacion: string) {
    this.habitacionService.delete(identificacion).subscribe(p => {
      const messageBox = this.modalService.open(AlertModalComponent)
      messageBox.componentInstance.title = "Resultado Operación";
      messageBox.componentInstance.message = 'Habitacion Eliminada!!! :)';
      
    });
  }

  openSm(content) {
    this.modalService.open(content, { size: 'sm' ,centered: true });
  }

}
