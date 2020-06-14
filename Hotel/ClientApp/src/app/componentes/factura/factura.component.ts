import { Component, OnInit } from '@angular/core';
import { FacturaService } from 'src/app/services/factura.service';
import { FormBuilder } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Factura } from 'src/app/models/factura';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-factura',
  templateUrl: './factura.component.html',
  styleUrls: ['./factura.component.css']
})
export class FacturaComponent implements OnInit {

  factura:Factura;
  facturas:Factura[];
  searchText:any;
  _idFactura:number;_idReserva:string;_total:number;

  constructor(
    private facturaService: FacturaService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit(){
    this.traerFacturas();
  }

  traerFacturas(){
    this.facturaService.get().subscribe(result => {
      this.facturas = result;
    });
  }

  consultarId(identificacion:number){
    this.facturaService.getId(identificacion).subscribe(p => {
      if (p != null) {
        this.mapearFactura(p);
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Factura Encontrada!!! :)';
      }
    });
  }

  mapearFactura(_Factura:Factura){
    this._idFactura= _Factura.idFactura;
    this._idReserva= _Factura.idReserva;
    this._total= _Factura.total;
  }

  openScrollableContent(longContent) {
    this.modalService.open(longContent, { size: 'lg', scrollable: true, centered: true });
  }

}
