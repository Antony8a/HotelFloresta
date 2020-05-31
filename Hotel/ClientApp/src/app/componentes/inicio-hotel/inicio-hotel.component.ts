import { Component, OnInit } from '@angular/core';
import { NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-inicio-hotel',
  templateUrl: './inicio-hotel.component.html',
  styleUrls: ['./inicio-hotel.component.css']
})
export class InicioHotelComponent implements OnInit {

  images = [944, 1011, 984].map((n) => `https://picsum.photos/id/${n}/900/500`);
  fechaprueba:string;
  pdia:string;
  pmes:string;
  paño:string;
  
  constructor() { }

  ngOnInit(){
    this.asignarfecha();
  }
  asignarfecha(){
    var toma = new Date();
    this.pdia = toma.getDate().toString();
    this.pmes = (toma.getMonth()+1).toString();
    this.paño = toma.getFullYear().toString();
    this.fechaprueba = this.paño + "/" + this.pmes + "/" + this.pdia;
  }

}
