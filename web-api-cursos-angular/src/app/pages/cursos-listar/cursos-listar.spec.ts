import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CursosListar } from './cursos-listar';

describe('CursosListar', () => {
  let component: CursosListar;
  let fixture: ComponentFixture<CursosListar>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CursosListar],
    }).compileComponents();

    fixture = TestBed.createComponent(CursosListar);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
