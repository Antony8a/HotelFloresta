import { Component, OnInit } from '@angular/core';
import { Producto } from 'src/app/models/producto';
import { ProductoService } from 'src/app/services/producto.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-producto-consulta',
  templateUrl: './producto-consulta.component.html',
  styleUrls: ['./producto-consulta.component.css']
})
export class ProductoConsultaComponent implements OnInit {

  productos:Producto[];
  producto:Producto;
  searchText:string;
  closeResult: string;
  constructor(
    private productoService: ProductoService,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.productoService.get().subscribe(result => {
      this.productos = result;
    });
  }

  delete(identificacion: string) {
    this.productoService.delete(identificacion).subscribe(p => {
      const messageBox = this.modalService.open(AlertModalComponent)
      messageBox.componentInstance.title = "Resultado Operación";
      messageBox.componentInstance.message = 'Producto Eliminado!!! :)';
    });
  }

  openSm(content) {
    this.modalService.open(content, { size: 'sm' ,centered: true });
  }

}
