import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroInternacaoComponent } from './cadastro-internacao.component';

describe('CadastroInternacaoComponent', () => {
    let component: CadastroInternacaoComponent;
    let fixture: ComponentFixture<CadastroInternacaoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
        declarations: [CadastroInternacaoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
      fixture = TestBed.createComponent(CadastroInternacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
