import { Component, OnInit } from '@angular/core';

interface Food {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-reserva-inicio',
  templateUrl: './reserva-inicio.component.html',
  styleUrls: ['./reserva-inicio.component.css']
})
export class ReservaInicioComponent implements OnInit {
  modal: boolean = false;


  foods: Food[] = [
    {value: 'steak-0', viewValue: 'King'},
    {value: 'pizza-1', viewValue: 'KingDoble'},
    {value: 'tacos-2', viewValue: 'KingKing'}
  ];

  constructor() { }

  ngOnInit(): void {
  }

  change(){
    if(this.modal)
      this.modal=false;
    else
      this.modal=true;
  }

}
