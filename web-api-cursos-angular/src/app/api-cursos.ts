import { HttpClient } from '@angular/common/http';
import { inject, Service } from '@angular/core';
import { environment } from '../environments/environment.development';
import { Curso } from './models/Curso';
import { Observable } from 'rxjs';

@Service()
export class ApiCursos {

    private readonly httpClient: HttpClient = inject(HttpClient);
    private url: string = environment.apiUrl;

  Create(curso: Curso): Observable<Curso>{
    return this.httpClient.post<Curso>(this.url, curso);
  }

  Read(): Observable<Curso[]>{    
    return this.httpClient.get<Curso[]>(this.url);
  }

  ReadById(id: number): Observable<Curso>{
    return this.httpClient.get<Curso>(`${this.url}/${id}`);
  }

  Update(curso: Curso): Observable<Curso>{
    return this.httpClient.put<Curso>(`${this.url}/${curso.id}`, curso);
  }

  Delete(id: number): Observable<void>{
    return this.httpClient.delete<void>(`${this.url}/${id}`);
  }  

}
