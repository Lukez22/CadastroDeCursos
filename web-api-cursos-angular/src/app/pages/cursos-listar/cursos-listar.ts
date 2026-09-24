import { CurrencyPipe, DatePipe } from '@angular/common';
import { Component, inject, signal, WritableSignal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { ApiCursos } from '../../api-cursos';
import { Curso } from '../../models/Curso';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  imports: [RouterLink, FormsModule, CurrencyPipe, DatePipe],
  selector: 'app-cursos-listar',
  styleUrl: './cursos-listar.css',
  templateUrl: './cursos-listar.html',
})
export class CursosListar {
  private readonly router: Router = inject(Router);
  private readonly apiCursos: ApiCursos = inject(ApiCursos);
  protected searchId: string = '';

  protected cursos: WritableSignal<Curso[]> = signal([]);

  RedirectToNovo(): void {
    this.router.navigate(['cursos/novo']);
  }

  Get() {
    if (this.searchId !== '') {
      this.apiCursos.ReadById(Number(this.searchId)).subscribe({
        next: (curso: Curso) => {
          this.cursos.set([curso]);
        },
        error: (erro: HttpErrorResponse) => {
          if (erro.status === 404) {
            alert('Curso não encontrado');
            this.cursos.set([]);
          }
        },
      });

      return;
    }

    this.apiCursos.Read().subscribe({
      next: (cursos: Curso[]) => {
        this.cursos.set(cursos);
      },
    });
  }

  Delete(id: number): void {
    if (confirm(`Deseja excluir o curso ${id}?`)) {
      this.apiCursos.Delete(id).subscribe({
        next: () => {
          alert('Curso excluído com sucesso! \nA tela será atualizada!');
          this.Get();
        },
        error: (erro: HttpErrorResponse) =>{
          if (erro.status === 400){
            alert('Não é possível excluir um curso ativo');
          }
          if (erro.status === 404){
            alert('O curso não foi encontrado');
          }
        }
      });
    }
  }
}
