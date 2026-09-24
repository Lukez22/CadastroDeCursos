import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  imports: [],
  selector: 'app-error-404',
  styleUrl: './error-404.css',
  templateUrl: './error-404.html',
})
export class Error404 {
  private readonly router: Router = inject(Router);

  RedirectToCursos(): void{
    this.router.navigate(['cursos/listar']);
  }
}
