/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MovimentacoesService } from './Movimentacoes.service';

describe('Service: Movimentacoes', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MovimentacoesService]
    });
  });

  it('should ...', inject([MovimentacoesService], (service: MovimentacoesService) => {
    expect(service).toBeTruthy();
  }));
});
