import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ViaCep} from '../models/ViaCep'
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BuscaCepService {

  constructor(private http: HttpClient) { }

  buscarPorCep(cep:string){
     return this.http.get<ViaCep>(`${environment.VIACEP_API_URL}/${cep}/json`);
  }
}
