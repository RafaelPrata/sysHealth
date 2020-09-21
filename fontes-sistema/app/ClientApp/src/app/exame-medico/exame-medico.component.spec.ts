import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExameMedicoComponent } from './exame-medico.component';

describe('ExameMedicoComponent', () => {
  let component: ExameMedicoComponent;
  let fixture: ComponentFixture<ExameMedicoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExameMedicoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExameMedicoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
