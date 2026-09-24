import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CursosNovo } from './cursos-novo';

describe('CursosNovo', () => {
  let component: CursosNovo;
  let fixture: ComponentFixture<CursosNovo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CursosNovo],
    }).compileComponents();

    fixture = TestBed.createComponent(CursosNovo);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
