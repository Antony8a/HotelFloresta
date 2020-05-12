import { Component, OnInit } from '@angular/core';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { Cliente } from 'src/app/models/cliente';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-cliente-registro',
  templateUrl: './cliente-registro.component.html',
  styleUrls: ['./cliente-registro.component.css']
})
export class ClienteRegistroComponent implements OnInit {

  formGroup: FormGroup;
  cliente: Cliente;
  constructor(
    private clienteService: ClienteService, 
    private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.buildForm();
  }


  private buildForm() {
    this.cliente = new Cliente();
    this.cliente.identificacion = '';
    this.cliente.nombre = '';
    this.cliente.edad = 0;
    this.cliente.sexo = '';
    this.cliente.direccion = '';
    this.cliente.celular = '';
    this.cliente.correo = '';
    this.cliente.usuario = '';
    this.cliente.password = '';
    this.formGroup = this.formBuilder.group({
      identificacion: [this.cliente.identificacion, Validators.required],
      nombre: [this.cliente.nombre, Validators.required],
      edad: [this.cliente.edad, Validators.required],
      sexo: [this.cliente.sexo, Validators.required],
      direccion: [this.cliente.direccion, Validators.required],
      celular: [this.cliente.celular, Validators.required],
      correo: [this.cliente.correo, Validators.required],
      usuario: [this.cliente.usuario, Validators.required],
      password: [this.cliente.password, Validators.required],
    });
  }

  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }

  add() {
    this.cliente = this.formGroup.value;
    this.clienteService.post(this.cliente).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Cliente creado!!! :-)';
        this.cliente = p;
      }
    });

  }

  get control() { return this.formGroup.controls; }

}
