import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import {MatAccordion} from '@angular/material/expansion';
import {MatDialog} from '@angular/material/dialog';
import { MovimentacoesManuais } from 'src/app/_interfaces/MovimentacoesManuais';
import { MovimentacoesService } from 'src/app/_services/Movimentacoes.service';
import { ChaveMovimentacao } from 'src/app/_interfaces/ChaveMovimentacao';


@Component({
  selector: 'app-lista-movimentacoes',
  templateUrl: './lista-movimentacoes.component.html',
  styleUrls: ['./lista-movimentacoes.component.css']
})
export class ListaMovimentacoesComponent implements OnInit {
  
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatAccordion) accordion: MatAccordion;
  
  //VARIÁVEIS GLOBAIS
  displayedColumns: string[] = ['NumeroLancamento', 'Mes', 'Ano', 'CodigoProduto', 'DescricaoProduto', 'Descricao', 'Valor', 'ConsultarDados', 'DeletarRegistro'];
  dataSource = new MatTableDataSource<MovimentacoesManuais>();
  movimentacoes$: MovimentacoesManuais[];
  chaveMovimentacao: ChaveMovimentacao;

  //VARIÁVEIS DE CONTROLE
  panelOpenState = false;
  statusSelect = '';
  progressBar = false;
  progressBar2 = false;
  
  fechandoModal = (): void => {
    this.dialog.closeAll();
    this.progressBar = true;
    this.panelOpenState = !this.panelOpenState;
    this.getMovimentacoes();
  }

  constructor(private serv: MovimentacoesService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.progressBar = true;
    this.getMovimentacoes();
  }

  getMovimentacoes(){

    this.serv.getAllMovimentacoes().subscribe(result => {
      this.movimentacoes$ = result;
      this.configurarListagem(this.movimentacoes$);
      this.panelOpenState = true;
      this.progressBar = false;
    }, error => {
      console.log(error);
    });

  }

  //FUNÇÕES PARA CONFIGURAÇÃO E FUNCIONAMENTO DA TELA

  configurarListagem(response: any){
    this.movimentacoes$ = response;
    this.dataSource.data = response;
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    this.dataSource.filterPredicate = (data: any, filter) => {
      const dataStr = JSON.stringify(data).toLowerCase();
      return dataStr.indexOf(filter) != -1;
    }
  }

  aplicarFiltroLista(event: Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if(this.dataSource.paginator){
      this.dataSource.paginator.firstPage();
    }
  }

  openDialog(template: TemplateRef<any>, visualizacao: boolean){
    
    if(!visualizacao) {
      this.chaveMovimentacao = {
        Mes: 0,
        Ano: 0,
        NumeroLancamento: 0,
        codigoProduto: '0'
      };
    }

    this.dialog.open(template, {
      width: '800px;',
      height: '400px;',
      panelClass: 'my-dialog',
      disableClose: true
    });
  }

  visualizarRegistro(mes: number, ano: number, numeroLancamento: number, codigoProduto: string, template: TemplateRef<any>){
    this.chaveMovimentacao = {
      Mes: mes,
      Ano: ano,
      NumeroLancamento: numeroLancamento,
      codigoProduto: codigoProduto
    };
    this.openDialog(template, true);
  }

}
