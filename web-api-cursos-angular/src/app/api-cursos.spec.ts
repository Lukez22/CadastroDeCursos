import { TestBed } from '@angular/core/testing';
import { ApiCursos } from './api-cursos';

describe('ApiCursos', () => {
  let service: ApiCursos;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiCursos);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
