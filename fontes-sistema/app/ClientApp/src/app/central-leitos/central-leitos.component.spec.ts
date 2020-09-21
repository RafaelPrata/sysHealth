import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CentralLeitosComponent } from './central-leitos.component';

describe('CentralLeitosComponent', () => {
  let component: CentralLeitosComponent;
  let fixture: ComponentFixture<CentralLeitosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CentralLeitosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CentralLeitosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
