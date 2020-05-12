import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservaInicioProvicionalComponent } from './reserva-inicio-provicional.component';

describe('ReservaInicioProvicionalComponent', () => {
  let component: ReservaInicioProvicionalComponent;
  let fixture: ComponentFixture<ReservaInicioProvicionalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReservaInicioProvicionalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReservaInicioProvicionalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
