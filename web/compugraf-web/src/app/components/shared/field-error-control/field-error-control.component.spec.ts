import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FieldErrorControlComponent } from './field-error-control.component';

describe('FieldErrorControlComponent', () => {
  let component: FieldErrorControlComponent;
  let fixture: ComponentFixture<FieldErrorControlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FieldErrorControlComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FieldErrorControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
