import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConteudoHomeComponent } from './componentes/conteudo-home/conteudo-home.component';

import { HomeRoutingModule } from './home-routing.module';

@NgModule({
  declarations: [
    ConteudoHomeComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule
  ]
})
export class HomeModule { }
