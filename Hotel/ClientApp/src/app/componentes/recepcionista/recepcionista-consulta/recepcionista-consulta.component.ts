import { Component, OnInit } from '@angular/core';
import { Recepcionista } from 'src/app/models/recepcionista';
import { RecepcionistaService } from 'src/app/services/recepcionista.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-recepcionista-consulta',
  templateUrl: './recepcionista-consulta.component.html',
  styleUrls: ['./recepcionista-consulta.component.css']
})
export class RecepcionistaConsultaComponent implements OnInit {

  recepcionistas:Recepcionista[];
  recepcionista:Recepcionista;
  searchText:string;
  closeResult: string;
  constructor(
    private recepcionistaService: RecepcionistaService,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.recepcionistaService.get().subscribe(result => {
      this.recepcionistas = result;
    });
  }

  delete(identificacion: string) {
    this.recepcionistaService.delete(identificacion).subscribe(p => {
      const messageBox = this.modalService.open(AlertModalComponent)
      messageBox.componentInstance.title = "Resultado Operación";
      messageBox.componentInstance.message = 'Recepcionista Eliminada!!! :)';
    });
  }

  openSm(content) {
    this.modalService.open(content, { size: 'sm' ,centered: true });
  }

}
