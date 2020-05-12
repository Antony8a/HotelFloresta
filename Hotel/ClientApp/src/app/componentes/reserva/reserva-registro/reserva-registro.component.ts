import { Component, OnInit } from '@angular/core';
import { ReservaService } from 'src/app/services/reserva.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Reserva } from 'src/app/models/reserva';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Habitacion } from 'src/app/models/habitacion';
import { HabitacionService } from 'src/app/services/habitacion.service';

@Component({
  selector: 'app-reserva-registro',
  templateUrl: './reserva-registro.component.html',
  styleUrls: ['./reserva-registro.component.css']
})
export class ReservaRegistroComponent implements OnInit {

  formGroup: FormGroup;
  reserva:Reserva;
  habitaciones:Habitacion[];
  habitacion:Habitacion;
  constructor(
    private reservaService: ReservaService,
    private habitacionService: HabitacionService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

    ngOnInit(){
      this.habitacionService.get().subscribe(result => {
        this.habitaciones = result;});
      this.buildForm();
    }
    private buildForm() {
      this.reserva = new Reserva();
      this.formGroup = this.formBuilder.group({
        fechaInicio: [this.reserva.fechaInicio, Validators.required],
        fechaFin: [this.reserva.fechaFin, Validators.required],
        cantidadPersonas: [this.reserva.cantidadPersonas, Validators.required],
        idCliente: [this.reserva.idCliente, Validators.required],
        idHabitacion: [this.reserva.idHabitacion, Validators.required],
      });
    }
  
    onSubmit() {
      if (this.formGroup.invalid) {
        return;
      }
      this.add();
    }
  
    add() {
      this.reserva = this.formGroup.value;
      this.reservaService.post(this.reserva).subscribe(p => {
        if (p != null) {
          const messageBox = this.modalService.open(AlertModalComponent)
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Reseerva creada!!! :D';
          this.reserva = p;
        }
      });
  
    }
  
    get control() { return this.formGroup.controls; }

}
