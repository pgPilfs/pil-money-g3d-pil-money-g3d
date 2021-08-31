import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovPesosComponent } from './mov-pesos.component';

describe('MovPesosComponent', () => {
  let component: MovPesosComponent;
  let fixture: ComponentFixture<MovPesosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovPesosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovPesosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
