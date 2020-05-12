import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ClienteInicioProvicionalComponent } from './cliente-inicio-provicional.component';

describe('ClienteInicioProvicionalComponent', () => {
  let component: ClienteInicioProvicionalComponent;
  let fixture: ComponentFixture<ClienteInicioProvicionalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ClienteInicioProvicionalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClienteInicioProvicionalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
