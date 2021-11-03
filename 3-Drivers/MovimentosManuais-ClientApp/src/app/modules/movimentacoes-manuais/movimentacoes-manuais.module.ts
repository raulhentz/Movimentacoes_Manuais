import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MovimentacoesManuaisRoutingModule } from './movimentacoes-manuais-routing.module';
import { ListaMovimentacoesComponent } from './componentes/lista-movimentacoes/lista-movimentacoes.component';
import { FormMovimentacoesComponent } from './componentes/form-movimentacoes/form-movimentacoes.component';

import { ReactiveFormsModule, FormsModule } from '@angular/forms';


import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatSelectModule} from '@angular/material/select';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatCardModule} from '@angular/material/card';
import {MatIconModule} from '@angular/material/icon';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatDialogModule} from '@angular/material/dialog';
import { MovimentacoesService } from 'src/app/_services/Movimentacoes.service';
import { ExclusaoMovimentacaoComponent } from './componentes/exclusao-movimentacao/exclusao-movimentacao.component';

@NgModule({
  declarations: [
    ListaMovimentacoesComponent,
    FormMovimentacoesComponent,
    ExclusaoMovimentacaoComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule, 
    FormsModule,
    MatCardModule,
    MatIconModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatExpansionModule,
    MatFormFieldModule,
    MatTableModule,
    MatPaginatorModule,
    MatDialogModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatTooltipModule,
    MovimentacoesManuaisRoutingModule
  ],
  providers: [
    MovimentacoesService
 ],
})
export class MovimentacoesManuaisModule { }
