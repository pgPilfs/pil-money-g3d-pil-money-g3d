import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransferenciaCuentaPropiaComponent } from './transferencia-cuenta-propia.component';

describe('TransferenciaCuentaPropiaComponent', () => {
  let component: TransferenciaCuentaPropiaComponent;
  let fixture: ComponentFixture<TransferenciaCuentaPropiaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TransferenciaCuentaPropiaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TransferenciaCuentaPropiaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
