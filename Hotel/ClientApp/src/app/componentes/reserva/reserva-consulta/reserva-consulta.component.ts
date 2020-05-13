import { Component, OnInit } from '@angular/core';
import { Reserva } from 'src/app/models/reserva';
import { ReservaService } from 'src/app/services/reserva.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-reserva-consulta',
  templateUrl: './reserva-consulta.component.html',
  styleUrls: ['./reserva-consulta.component.css']
})
export class ReservaConsultaComponent implements OnInit {

  reservas:Reserva[];
  reserva:Reserva;
  searchText:number;
  closeResult: string;
  constructor(
    private reservaService: ReservaService,
    private modalService: NgbModal) { }

  ngOnInit(){
    this.reservaService.get().subscribe(result => {
      this.reservas = result;
    });
  }

  delete(identificacion: number) {
    this.reservaService.delete(identificacion).subscribe(p => {
      const messageBox = this.modalService.open(AlertModalComponent)
      messageBox.componentInstance.title = "Resultado Operación";
      messageBox.componentInstance.message = 'Reserva Eliminada!!! :)';
    });
  }

  openSm(content) {
    this.modalService.open(content, { size: 'sm' ,centered: true });
  }

}
