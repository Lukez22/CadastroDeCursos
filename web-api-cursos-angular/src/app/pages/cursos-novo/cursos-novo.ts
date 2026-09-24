import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiCursos } from '../../api-cursos';
import { Curso } from '../../models/Curso';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  imports: [FormsModule],
  selector: 'app-cursos-novo',
  styleUrl: './cursos-novo.css',
  templateUrl: './cursos-novo.html',
})
export class CursosNovo {

  private readonly router: Router = inject(Router);
  private readonly apiCursos: ApiCursos = inject(ApiCursos);

  protected readonly curso: Curso = { 
    nome: '',
    cargaHoraria: '',
    valor: '',
    dataInicio: '',
    online: '',
    ativo: ''
  };

  RedirectToCursos(): void{
    this.router.navigate(['cursos/listar']);
  }

  Create(): void{
    this.apiCursos.Create(this.curso).subscribe({
      next: (curso: Curso) => {
        alert('Curso cadastrado com sucesso!');
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
