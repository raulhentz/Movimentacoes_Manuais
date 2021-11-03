import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path:'', redirectTo:'home', pathMatch: 'full' },
  { path:'home', loadChildren: () => import('./modules/home/home.module').then(m => m.HomeModule) },
  { path:'movimentacoes', loadChildren: () => import('./modules/movimentacoes-manuais/movimentacoes-manuais.module').then(m => m.MovimentacoesManuaisModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
