import { Pipe, PipeTransform } from "@angular/core";
import { Factura } from "../models/factura";

@Pipe({
    name: 'filtroFactura'
  })
  export class FiltroFacturaPipe implements PipeTransform {
  
    transform(factura: Factura[], searchText: string): any {
      if (searchText == null) return factura;
          return factura.filter(p =>
            p.idReserva.toLowerCase().indexOf(searchText.toLowerCase()) !== -1 ||
            p.idFactura.toString().indexOf(searchText.toLowerCase()) !== -1);
      }
  }