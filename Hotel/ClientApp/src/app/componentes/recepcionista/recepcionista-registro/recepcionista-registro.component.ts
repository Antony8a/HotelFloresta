import { Component, OnInit } from '@angular/core';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { Recepcionista } from 'src/app/models/recepcionista';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RecepcionistaService } from 'src/app/services/recepcionista.service';

@Component({
  selector: 'app-recepcionista-registro',
  templateUrl: './recepcionista-registro.component.html',
  styleUrls: ['./recepcionista-registro.component.css']
})
export class RecepcionistaRegistroComponent implements OnInit {

  formGroup: FormGroup;
  recepcionista:Recepcionista;
  constructor(
    private recepcionistaService: RecepcionistaService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit(){
    this.buildForm();
  }
  private buildForm() {
    this.recepcionista = new Recepcionista();
    this.recepcionista.identificacion = '';
    this.recepcionista.nombre = '';
    this.recepcionista.edad = 0;
    this.recepcionista.sexo = '';
    this.recepcionista.direccion = '';
    this.recepcionista.celular = '';
    this.recepcionista.correo = '';
    this.recepcionista.usuario = '';
    this.recepcionista.password = '';
    this.formGroup = this.formBuilder.group({
      identificacion: [this.recepcionista.identificacion, Validators.required],
      nombre: [this.recepcionista.nombre, Validators.required],
      edad: [this.recepcionista.edad, Validators.required],
      sexo: [this.recepcionista.sexo, Validators.required],
      direccion: [this.recepcionista.direccion, Validators.required],
      celular: [this.recepcionista.celular, Validators.required],
      correo: [this.recepcionista.correo, Validators.required],
      usuario: [this.recepcionista.usuario, Validators.required],
      password: [this.recepcionista.password, Validators.required],
    });
  }

  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }

  add() {
    this.recepcionista = this.formGroup.value;
    this.recepcionistaService.post(this.recepcionista).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'recepcionista creada!!! :D';
        this.recepcionista = p;
      }
    });

  }

  get control() { return this.formGroup.controls; }
}
