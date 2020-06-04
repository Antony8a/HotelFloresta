import { Component, OnInit } from '@angular/core';
import { Producto } from 'src/app/models/producto';
import { ProductoService } from 'src/app/services/producto.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-producto-consulta',
  templateUrl: './producto-consulta.component.html',
  styleUrls: ['./producto-consulta.component.css']
})
export class ProductoConsultaComponent implements OnInit {

  //esto es de consultar
  productos:Producto[];
  producto:Producto;
  searchText:string;
  closeResult: string;

  //esto es del editar
  formGroup: FormGroup;
  idn: string; public _nombre: string;public _tipo: string; public _precio: number; 

  constructor(
    private productoService: ProductoService,
    private formBuilder: FormBuilder,
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

  // Desde aquí comienza todo lo correspondiente al "EDITAR"

  openScrollableContent(longContent) {
    this.modalService.open(longContent, { size: 'lg', scrollable: true, centered: true });
  }

  consultaId(identificacion: string){
    this.idn=identificacion;
    this.productoService.getId(this.idn).subscribe(p => {
      if (p != null) {
        this.PintarInput(p);
        this.buildForm();
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Producto Encontrado!!! :)';
      }
    });
  }

  private PintarInput(producto1: Producto) {
    this._nombre= producto1.nombre;
    this._tipo = producto1.tipo;
    this._precio = producto1.precio;
  }


  private buildForm() {
    this.formGroup = this.formBuilder.group({
      idProducto: this.idn,
      nombre: [this._nombre, Validators.required],
      tipo: [this._tipo, Validators.required],
      precio: [this._precio, Validators.required],
    });
  }

  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.updateProducto();
  }
  
  updateProducto() {
    this.producto = this.formGroup.value;
    this.productoService.put(this.producto).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Producto Modificado!!! :)';
        this.producto = p;
      }
    });
  }

  get control() { return this.formGroup.controls; }
}