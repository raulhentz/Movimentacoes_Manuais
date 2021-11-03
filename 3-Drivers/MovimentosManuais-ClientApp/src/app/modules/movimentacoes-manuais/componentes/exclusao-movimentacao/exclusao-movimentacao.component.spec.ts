import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExclusaoMovimentacaoComponent } from './exclusao-movimentacao.component';

describe('ExclusaoMovimentacaoComponent', () => {
  let component: ExclusaoMovimentacaoComponent;
  let fixture: ComponentFixture<ExclusaoMovimentacaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExclusaoMovimentacaoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExclusaoMovimentacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
