import { Routes } from '@angular/router';
import { Home } from './pages/home/home';
import { CursosListar } from './pages/cursos-listar/cursos-listar';
import { CursosNovo } from './pages/cursos-novo/cursos-novo';
import { CursosEditar } from './pages/cursos-editar/cursos-editar';
import { Error404 } from './pages/error-404/error-404';

export const routes: Routes = [
    {path:'', redirectTo:'home', pathMatch:'full'},
    {path: 'home', component: Home},
    {path:'cursos/listar', component: CursosListar},
    {path:'cursos/novo', component: CursosNovo},
    {path:'cursos/editar/:id', component: CursosEditar},
    {path:'**', component: Error404}
];
