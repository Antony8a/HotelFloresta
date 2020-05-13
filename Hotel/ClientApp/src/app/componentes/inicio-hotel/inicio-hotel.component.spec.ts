import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InicioHotelComponent } from './inicio-hotel.component';

describe('InicioHotelComponent', () => {
  let component: InicioHotelComponent;
  let fixture: ComponentFixture<InicioHotelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InicioHotelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InicioHotelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
