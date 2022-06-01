import { TestBed } from '@angular/core/testing';

import { ImportadorService } from './importador.service';

describe('ImportadorService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ImportadorService = TestBed.get(ImportadorService);
    expect(service).toBeTruthy();
  });
});
