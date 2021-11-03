import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { ChaveMovimentacao } from 'src/app/_interfaces/ChaveMovimentacao';
import { MovimentacoesManuais } from 'src/app/_interfaces/MovimentacoesManuais';
import { ProdutoCosif } from 'src/app/_interfaces/ProdutoCosif';
import { Produtos } from 'src/app/_interfaces/Produtos';
import { MovimentacoesService } from 'src/app/_services/Movimentacoes.service';

/**CLASSE RESPONSÁVEL PELO COMPONENTE "ERROR STATE MATCHER" DO ANGULAR MATERIAL PARA VALIDAR O FORMULÁRIO */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-form-movimentacoes',
  templateUrl: './form-movimentacoes.component.html',
  styleUrls: ['./form-movimentacoes.component.css']
})
export class FormMovimentacoesComponent implements OnInit {

  @Input() functionFecharModal: () => void;
  @Input() movimentacaoId: ChaveMovimentacao;
  @ViewChild('inputMes') inputMes;

  //VARIÁVEIS GLOBAIS
  matcher: MyErrorStateMatcher;
  ErroValidacao = '';
  registerForm: FormGroup;
  movimentacao: MovimentacoesManuais;
  produtos: Produtos[];
  produtosCosif: ProdutoCosif[];
  public movimentacoesManuais: MovimentacoesManuais;

  //VARIÁVEIS DE CONTROLE
  progressBar2 = false;
  habilitarCampos = true;
  tituloModal = '';
  tipoProduto = '0';
  tipoProdutoCosif = '0';

  constructor(private serv: MovimentacoesService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validarForm();
    this.carregarProdutos();
    this.verificarMovimentacaoId();
  }

  verificarMovimentacaoId(){
    if(this.movimentacaoId.Ano != 0 && this.movimentacaoId.Mes != 0 
        && this.movimentacaoId.NumeroLancamento != 0 && this.movimentacaoId.codigoProduto != '0') {
      this.habilitarCampos = false;
      this.tituloModal = 'Visualizar Movimentação'
      this.visualizarDadosMovimentacao();    
    }
    else{
      this.habilitarCampos = true;
      this.tituloModal = 'Nova Movimentação'
    }
  }

  visualizarDadosMovimentacao(){
    this.serv.getMovimentacao(this.movimentacaoId).subscribe(result => {
      this.movimentacoesManuais = result;

      if(this.movimentacoesManuais != null) { 
        this.tipoProduto = this.movimentacoesManuais.codigoProduto;
        this.carregarProdutoCosif(this.tipoProduto);
        this.tipoProdutoCosif = this.movimentacoesManuais.codigoCosif;
        this.registerForm.patchValue(this.movimentacoesManuais);
      }
    }, error => { });
  }

  carregarProdutos(){
    this.serv.getProdutos().subscribe(result => {
      this.produtos = result;
    }, error => { });
  }

  carregarProdutoCosif(event: any){
    this.serv.getProdutoCosif(event).subscribe(result => {
      this.produtosCosif = result;
    }, error => { });
  }


  criarMovimentacao(){
    if(this.registerForm.valid && this.validarCampoMes()){
      this.progressBar2 = true;
      this.movimentacao = Object.assign({}, this.registerForm.value);
      
      this.serv.post(this.movimentacao).subscribe(response => {
        this.progressBar2 = false;
        this.functionFecharModal();
      }, error => {
        this.progressBar2 = false;
        this.ErroValidacao = error.error;
        ;
        
      });
    }
  }

  //VALIDAÇÕES DO FORMULÁRIO
  validarCampoMes(): boolean{
    var mes = this.inputMes.nativeElement.value;

    if(mes < 0 && mes > 12){
      this.ErroValidacao = 'É permitido inserir meses de 1 a 12.'
      return false;
    }

    return true;

  }
  validarForm(){
    this.registerForm = this.fb.group({
      mes: ['', Validators.required],
      ano: ['', Validators.required],
      CodigoProduto: ['', Validators.required],
      CodigoCosif: ['', Validators.required],
      valor: ['', Validators.required],
      descricao: ['', Validators.required],
    });

    this.matcher = new ErrorStateMatcher();
  }

  apenasNumeros(event: any): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;

  }

}
