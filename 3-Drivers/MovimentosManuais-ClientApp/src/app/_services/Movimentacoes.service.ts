import {HttpClient} from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ChaveMovimentacao } from '../_interfaces/ChaveMovimentacao';
import { MovimentacoesManuais } from '../_interfaces/MovimentacoesManuais';
import { ProdutoCosif } from '../_interfaces/ProdutoCosif';
import { Produtos } from '../_interfaces/Produtos';

@Injectable()
export class MovimentacoesService {
    baseUrl = 'http://localhost:5000/';


    constructor(private http: HttpClient) { }

    getAllMovimentacoes(): Observable<MovimentacoesManuais[]> {
        return this.http.get<MovimentacoesManuais[]>(`${this.baseUrl}MovimentacoesManuais/`)
    }
    getMovimentacao(movimentacaoId: ChaveMovimentacao): Observable<MovimentacoesManuais> {
        return this.http.get<MovimentacoesManuais>(`${this.baseUrl}MovimentacoesManuais/GetById/${movimentacaoId.Mes}/${movimentacaoId.Ano}/${movimentacaoId.NumeroLancamento}/${movimentacaoId.codigoProduto}`);
    }
    
    getProdutos(): Observable<Produtos[]> {
        return this.http.get<Produtos[]>(`${this.baseUrl}Produtos/`)
    }

    getProdutoCosif(codigoProduto: string): Observable<ProdutoCosif[]> {
        return this.http.get<ProdutoCosif[]>(`${this.baseUrl}ProdutosCosif/${codigoProduto}`)
    }
    
    post(movimentacao: MovimentacoesManuais) {
        return this.http.post(`${this.baseUrl}MovimentacoesManuais/`, movimentacao);
    }

    deletarMovimentacao(movimentacao: ChaveMovimentacao) {
        return this.http.delete(`${this.baseUrl}MovimentacoesManuais/${movimentacao.Mes}/${movimentacao.Ano}/${movimentacao.NumeroLancamento}/${movimentacao.codigoProduto}`);
    }

}
