import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HabitacionInicioProvicionalComponent } from './habitacion-inicio-provicional.component';

describe('HabitacionInicioProvicionalComponent', () => {
  let component: HabitacionInicioProvicionalComponent;
  let fixture: ComponentFixture<HabitacionInicioProvicionalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HabitacionInicioProvicionalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HabitacionInicioProvicionalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
