import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductoInicioProvicionalComponent } from './producto-inicio-provicional.component';

describe('ProductoInicioProvicionalComponent', () => {
  let component: ProductoInicioProvicionalComponent;
  let fixture: ComponentFixture<ProductoInicioProvicionalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductoInicioProvicionalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductoInicioProvicionalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
