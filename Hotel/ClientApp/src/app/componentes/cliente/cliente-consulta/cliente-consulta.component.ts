import { Component, OnInit } from '@angular/core';
import { Cliente } from 'src/app/models/cliente';
import { ClienteService } from 'src/app/services/cliente.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-cliente-consulta',
  templateUrl: './cliente-consulta.component.html',
  styleUrls: ['./cliente-consulta.component.css']
})
export class ClienteConsultaComponent implements OnInit {

  clientes:Cliente[];
  cliente:Cliente;
  searchText: string;
  closeResult: string;
  constructor(
    private clienteService: ClienteService,
    private modalService: NgbModal) { } 

  ngOnInit() {
    this.clienteService.get().subscribe(result => {
      this.clientes = result;
    });
  }

  delete(identificacion: string) {
    this.clienteService.delete(identificacion).subscribe(p => {
      const messageBox = this.modalService.open(AlertModalComponent)
      messageBox.componentInstance.title = "Resultado Operación";
      messageBox.componentInstance.message = 'Cliente Eliminado!!! :)';
    });
  }

  openSm(content) {
    this.modalService.open(content, { size: 'sm' ,centered: true });
  }

}
