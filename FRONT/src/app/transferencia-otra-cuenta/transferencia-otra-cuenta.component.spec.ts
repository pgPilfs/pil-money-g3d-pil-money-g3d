import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransferenciaOtraCuentaComponent } from './transferencia-otra-cuenta.component';

describe('TransferenciaOtraCuentaComponent', () => {
  let component: TransferenciaOtraCuentaComponent;
  let fixture: ComponentFixture<TransferenciaOtraCuentaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TransferenciaOtraCuentaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TransferenciaOtraCuentaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
