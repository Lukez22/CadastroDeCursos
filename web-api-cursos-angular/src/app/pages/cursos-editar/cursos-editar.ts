import { Component, inject, signal, WritableSignal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiCursos } from '../../api-cursos';
import { Curso } from '../../models/Curso';
import { FormsModule } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  imports: [FormsModule],
  selector: 'app-cursos-editar',
  styleUrl: './cursos-editar.css',
  templateUrl: './cursos-editar.html',
})
export class CursosEditar {

  private readonly router: Router = inject(Router);
  private readonly apiCursos: ApiCursos = inject(ApiCursos);
  private readonly activedRoute: ActivatedRoute = inject(ActivatedRoute);

  private id: number = 0;

  protected curso: WritableSignal<Curso> = signal({} as Curso)
  
  RedirectToCursos(): void{
    this.router.navigate(['cursos/listar']);
  }

  ngOnInit(): void{
    this.id = Number(this.activedRoute.snapshot.paramMap.get('id'));
    this.apiCursos.ReadById(this.id).subscribe({
      next: (curso: Curso) => {
        curso.dataInicio = curso.dataInicio?.split('T')[0] ?? '';
        this.curso.set(curso);              
      }
    });
  }

  Update(){
    this.apiCursos.Update(this.curso()).subscribe({
      next: (curso: Curso) => {
        alert('Curso alterado com sucesso!');
        this.RedirectToCursos();
      },
      error:(erro: HttpErrorResponse) =>{
        if (erro.status === 400 ){
          alert("Os dados não foram preenchidos corretamente");
          return;
        }
        if (erro.status === 500 ){
          alert("Erro no servidor");
          return;
        }
      }
    })
  }
}
