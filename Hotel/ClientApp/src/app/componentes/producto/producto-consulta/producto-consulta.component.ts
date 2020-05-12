import { Component, OnInit } from '@angular/core';
import { Producto } from 'src/app/models/producto';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-producto-consulta',
  templateUrl: './producto-consulta.component.html',
  styleUrls: ['./producto-consulta.component.css']
})
export class ProductoConsultaComponent implements OnInit {

  productos:Producto[];
  producto:Producto;
  searchText:string;
  constructor(private productoService: ProductoService) { }

  ngOnInit() {
    this.productoService.get().subscribe(result => {
      this.productos = result;
    });
  }

}
