import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransferenciaContactoComponent } from './transferencia-contacto.component';

describe('TransferenciaContactoComponent', () => {
  let component: TransferenciaContactoComponent;
  let fixture: ComponentFixture<TransferenciaContactoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TransferenciaContactoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TransferenciaContactoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
