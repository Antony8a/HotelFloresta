import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-inicio-hotel',
  templateUrl: './inicio-hotel.component.html',
  styleUrls: ['./inicio-hotel.component.css']
})
export class InicioHotelComponent implements OnInit {

  images = [944, 1011, 984].map((n) => `https://picsum.photos/id/${n}/900/500`);
  constructor() { }

  ngOnInit(): void {
  }

}
