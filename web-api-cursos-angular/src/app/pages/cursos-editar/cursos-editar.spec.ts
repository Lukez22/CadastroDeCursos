import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CursosEditar } from './cursos-editar';

describe('CursosEditar', () => {
  let component: CursosEditar;
  let fixture: ComponentFixture<CursosEditar>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CursosEditar],
    }).compileComponents();

    fixture = TestBed.createComponent(CursosEditar);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
