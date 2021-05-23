import { Component, OnInit } from '@angular/core';
import { faTimes, faPen } from '@fortawesome/free-solid-svg-icons';
import { PessoaService } from 'src/app/services/pessoa.service';
import { Pessoa } from '../../../models/Pessoa';

@Component({
  selector: 'app-pessoa-list',
  templateUrl: './pessoa-list.component.html',
  styleUrls: ['./pessoa-list.component.css']
})
export class PessoaListComponent implements OnInit {
  faPen = faPen
  faTimes = faTimes

  pessoas: Pessoa[] = new Array<Pessoa>();

  constructor(private pessoaService: PessoaService) { 
    
  }

  ngOnInit(): void {
    this.selecionar();
  }

  selecionar(pagina:number = 0, quantidade:number = 10){
    this.pessoaService.listar(pagina, quantidade)
    .subscribe(resp => {
      this.pessoas =  resp.data as Pessoa[]; 
    })
  }
}
