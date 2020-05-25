import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-reserva-inicio',
  templateUrl: './reserva-inicio.component.html',
  styleUrls: ['./reserva-inicio.component.css']
})
export class ReservaInicioComponent implements OnInit {
  modal: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  change(){
    //this.paral = 
    if(this.modal)
      this.modal=false;
    else
      this.modal=true;
  }

}
