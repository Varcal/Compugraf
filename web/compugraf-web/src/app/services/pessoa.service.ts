import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Pessoa } from '../models/Pessoa';
import { environment } from 'src/environments/environment';
import { ResponseModel } from '../models/ReponseModel';

@Injectable({
  providedIn: 'root'
})
export class PessoaService {

  constructor(private http: HttpClient) { }

  private readonly API_PESSOA = "v1/pessoa"


  registrar(pessoa: Pessoa) {
    return this.http.post<ResponseModel<Pessoa>>(`${environment.API_URL}/${this.API_PESSOA}`, pessoa);
  }

  editar(pessoa: Pessoa) {
    return this.http.put<ResponseModel<Pessoa>>(`${environment.API_URL}/${this.API_PESSOA}/${pessoa.id}`, pessoa);
  }

  listar(pagina: number, quantidade: number) {
    return this.http.get<ResponseModel<Array<Pessoa>>>(`${environment.API_URL}/${this.API_PESSOA}/${pagina}/${quantidade}`);
  }

  obterPorId(id:number) {
    return this.http.get<ResponseModel<Pessoa>>(`${environment.API_URL}/${this.API_PESSOA}/${id}`);
  }
}
