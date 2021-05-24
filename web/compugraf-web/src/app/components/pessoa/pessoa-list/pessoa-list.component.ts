import { Component, OnInit } from '@angular/core';
import { faTimes, faPen } from '@fortawesome/free-solid-svg-icons';
import { PessoaService } from 'src/app/services/pessoa.service';
import { Pessoa } from '../../../models/Pessoa';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { PessoaExcluirModalComponent } from '../pessoa-excluir-modal/pessoa-excluir-modal.component';

@Component({
  selector: 'app-pessoa-list',
  templateUrl: './pessoa-list.component.html',
  styleUrls: ['./pessoa-list.component.css']
})
export class PessoaListComponent implements OnInit {
  faPen = faPen
  faTimes = faTimes
  bsModalRef: BsModalRef;
  pessoas: Pessoa[] = new Array<Pessoa>();

  constructor(private pessoaService: PessoaService,private modalService: BsModalService) { 
    this.pessoaService.atualizarPessoas.subscribe(atualizar => {
      if(atualizar) this.selecionar();
    })
  }

  ngOnInit(): void {
    this.selecionar();
  }

  selecionar(pagina:number = 0, quantidade:number = 10){
    this.pessoaService.listar(pagina, quantidade)
    .subscribe(resp => {
        this.pessoas =  resp == null ? [] : resp.data; 
    });
  }

  excluir(pessoa: Pessoa) {
    const options = {
      initialState: {
        title: "Usuário - Exclusão",
        pessoa: pessoa
      },
      backdrop: true,
      ignoreBackdropClick: true,
    };

    this.bsModalRef = this.modalService.show(PessoaExcluirModalComponent, options);
    this.bsModalRef.content.btnCancelar = 'Cancelar';
    this.bsModalRef.content.btnSalvar = 'Confirmar';
  }
}
