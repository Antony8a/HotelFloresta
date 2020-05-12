import { Pipe, PipeTransform } from '@angular/core';
import { Reserva } from '../models/reserva';

@Pipe({
  name: 'filtroReserva'
})
export class FiltroReservaPipe implements PipeTransform {

  transform(reserva: Reserva[], searchText: number): any {
    if (searchText == null) return reserva;
        return reserva.filter(p => p.idReserva);
    }

}
