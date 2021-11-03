import { Component, Input, OnInit } from '@angular/core';
import { ChaveMovimentacao } from 'src/app/_interfaces/ChaveMovimentacao';
import { MovimentacoesService } from 'src/app/_services/Movimentacoes.service';

@Component({
  selector: 'app-exclusao-movimentacao',
  templateUrl: './exclusao-movimentacao.component.html',
  styleUrls: ['./exclusao-movimentacao.component.css']
})
export class ExclusaoMovimentacaoComponent implements OnInit {

  @Input() functionFecharModal: () => void;
  @Input() movimentacaoId: ChaveMovimentacao;
  
  progressBar3 = false;
  ErroValidacao = ''
  constructor(private serv: MovimentacoesService) { }

  ngOnInit(): void {
  }

  deletarMovimentacao(){
    
      this.progressBar3 = true;
      
      this.serv.deletarMovimentacao(this.movimentacaoId).subscribe(response => {
        this.progressBar3 = false;
        this.functionFecharModal();
      }, error => {
        this.progressBar3 = false;
        this.ErroValidacao = error.error;
        ;
        
      });
    
  }

}
