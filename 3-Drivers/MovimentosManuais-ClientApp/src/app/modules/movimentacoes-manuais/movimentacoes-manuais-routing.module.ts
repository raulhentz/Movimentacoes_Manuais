import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListaMovimentacoesComponent } from './componentes/lista-movimentacoes/lista-movimentacoes.component';

const routes: Routes = [
  { path:'', component: ListaMovimentacoesComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MovimentacoesManuaisRoutingModule { }
