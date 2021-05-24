import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BuscaCepService } from 'src/app/services/busca-cep.service';
import { PessoaService } from 'src/app/services/pessoa.service';
import { Pessoa } from '../../../models/Pessoa';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-pessoa-form',
  templateUrl: './pessoa-form.component.html',
  styleUrls: ['./pessoa-form.component.css']
})
export class PessoaFormComponent implements OnInit {
  form!: FormGroup;
  pessoa: Pessoa = new Pessoa();
  estados: any[] = [];
  estadoSelecionado: any = undefined;
  pessoaId: any;


  constructor(private router: Router, private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder,
    private viaCepService: BuscaCepService, private pessoaService: PessoaService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.pessoaId = this.activatedRoute.snapshot.paramMap.get('id');

    if (this.pessoaId) {
      this.pessoaService.obterPorId(this.pessoaId)
        .subscribe(resp => {
          if (resp.statusCode == 200)
            this.pessoa = resp.data as Pessoa;
        },
          e => {
            this.mostrarErro(e.error.statusCode, e.error.message);
          })
    }


    this.form = this.formBuilder.group({
      nome: [this.pessoa.nome, Validators.compose([Validators.required, Validators.minLength(3)])],
      sobrenome: [this.pessoa.sobrenome, Validators.compose([Validators.required, Validators.minLength(3)])],
      cpf: [this.pessoa.cpf, Validators.compose([Validators.required, Validators.minLength(11)])],
      nacionalidade: [this.pessoa.nacionalidade, Validators.compose([Validators.pattern('[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$'), Validators.required])],
      cep: [this.pessoa.cep, Validators.compose([Validators.required, Validators.minLength(8)])],
      estado: [this.pessoa.estado, Validators.required],
      cidade: [this.pessoa.cidade, Validators.compose([Validators.required, Validators.minLength(3)])],
      logradouro: [this.pessoa.logradouro, Validators.compose([Validators.required, Validators.minLength(3)])],
      email: [this.pessoa.email, Validators.compose([Validators.required, Validators.email])],
      telefone: [this.pessoa.telefone, Validators.compose([Validators.required, Validators.minLength(11)])],
    });

    this.carregarEstados();
  }


  aplicaCssErro(campo: any) {
    return {
      'is-invalid': this.verificaValidTouched(campo)
    }
  }

  verificaValidTouched(campo: any) {
    return !this.form.get(campo)?.valid && this.form.get(campo)?.touched;
  }

  carregarEstados() {
    this.estados = [
      { "nome": "Acre", "estado": "AC" },
      { "nome": "Alagoas", "estado": "AL" },
      { "nome": "Amapá", "estado": "AP" },
      { "nome": "Amazonas", "estado": "AM" },
      { "nome": "Bahia", "estado": "BA" },
      { "nome": "Ceará", "estado": "CE" },
      { "nome": "Distrito Federal", "estado": "DF" },
      { "nome": "Espírito Santo", "estado": "ES" },
      { "nome": "Goiás", "estado": "GO" },
      { "nome": "Maranhão", "estado": "MA" },
      { "nome": "Mato Grosso", "estado": "MT" },
      { "nome": "Mato Grosso do Sul", "estado": "MS" },
      { "nome": "Minas Gerais", "estado": "MG" },
      { "nome": "Pará", "estado": "PA" },
      { "nome": "Paraíba", "estado": "PB" },
      { "nome": "Paraná", "estado": "PR" },
      { "nome": "Pernambuco", "estado": "PE" },
      { "nome": "Piauí", "estado": "PI" },
      { "nome": "Rio de Janeiro", "estado": "RJ" },
      { "nome": "Rio Grande do Norte", "estado": "RN" },
      { "nome": "Rio Grande do Sul", "estado": "RS" },
      { "nome": "Rondônia", "estado": "RO" },
      { "nome": "Roraima", "estado": "RR" },
      { "nome": "Santa Catarina", "estado": "SC" },
      { "nome": "São Paulo", "estado": "SP" },
      { "nome": "Sergipe", "estado": "SE" },
      { "nome": "Tocantins", "estado": "TO" }
    ]
  }

  buscarPorCep() {
    let cep = this.pessoa.cep.replace("-", "");

    if (cep.length != 8) return;

    this.viaCepService.buscarPorCep(cep)
      .subscribe(resp => {
        console.log(resp);
        this.form.controls["cep"].setValue(resp.cep);
        this.form.controls["cidade"].setValue(resp.localidade);
        this.form.controls["estado"].setValue(resp.uf);
        this.form.controls["logradouro"].setValue(resp.logradouro);
      })
  }


  salvar() {
    let pessoa = this.form.value;
    if (this.pessoa.id == 0) {
      this.registrar(pessoa);
    } else {
      this.editar(this.pessoa);
    }
  }

  registrar(pessoa: Pessoa) {
    this.pessoaService.registrar(pessoa)
      .subscribe(resp => {
        if (resp.statusCode == 201) {
          this.mostrarSucesso(resp.message);
          this.router.navigate(["/pessoa"])
        } else {
          this.mostrarErro(resp.message, resp.statusCode.toString());
        }
      }, e => {
        this.mostrarErro(e.error.message, `Erro ${e.error.statusCode}`);
      })
  }

  editar(pessoa: Pessoa) {
    this.pessoaService.editar(pessoa)
      .subscribe(resp => {
        if (resp.statusCode == 200) {
          this.mostrarSucesso(resp.message);
          this.router.navigate(["/pessoa"])
        } else {
          this.mostrarErro( resp.message, resp.statusCode.toString());
        }
      }, e => {
        this.mostrarErro(e.error.message, e.error.statusCode);
      })
  }

  mostrarSucesso(msg: string) {
    this.toastr.success(msg, "Sucesso")
  }
  mostrarErro(code: string, msg: string) {
    this.toastr.error(code, msg)
  }

  letterOnly(event) {
    var charCode = event.keyCode;

    if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 8)

      return true;
    else
      return false;
  }
}
