import { Component, OnInit } from '@angular/core';
import { PessoaService } from 'src/app/services/pessoa.service';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Pessoa } from 'src/app/models/Pessoa';
import { faTimes } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-pessoa-excluir-modal',
  templateUrl: './pessoa-excluir-modal.component.html',
  styleUrls: ['./pessoa-excluir-modal.component.css']
})
export class PessoaExcluirModalComponent implements OnInit {
  pessoa: Pessoa
  btnCancelar: string;
  btnSalvar: string;
  title: string;
  faTimes = faTimes;

  constructor(public bsModalRef: BsModalRef, private pessoaService: PessoaService) { }

  ngOnInit(): void {
  }


  excluir() {
    this.pessoaService.excluir(this.pessoa)
      .subscribe(resp => {
        this.bsModalRef.hide();
        this.pessoaService.atualizarPessoas.emit(true);
      },
        e => {
          console.log(e.error);
        });
  }
}
