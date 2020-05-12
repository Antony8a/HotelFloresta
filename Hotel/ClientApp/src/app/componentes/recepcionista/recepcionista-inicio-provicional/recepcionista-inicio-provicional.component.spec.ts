import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecepcionistaInicioProvicionalComponent } from './recepcionista-inicio-provicional.component';

describe('RecepcionistaInicioProvicionalComponent', () => {
  let component: RecepcionistaInicioProvicionalComponent;
  let fixture: ComponentFixture<RecepcionistaInicioProvicionalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecepcionistaInicioProvicionalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecepcionistaInicioProvicionalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
