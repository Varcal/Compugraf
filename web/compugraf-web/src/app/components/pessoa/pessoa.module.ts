import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';

import { PessoaPageComponent } from 'src/app/pages/pessoa-page/pessoa-page.component';
import { PessoaFormComponent } from './pessoa-form/pessoa-form.component';
import { PessoaListComponent } from './pessoa-list/pessoa-list.component';
import { PessoaRoutingModule } from './pessoa-routing.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FieldErrorControlComponent } from '../shared/field-error-control/field-error-control.component';
import { BuscaCepService } from 'src/app/services/busca-cep.service';
import { NgxMaskModule, IConfig } from 'ngx-mask'
import { PessoaService } from 'src/app/services/pessoa.service';
import { PessoaExcluirModalComponent } from './pessoa-excluir-modal/pessoa-excluir-modal.component';

const maskConfig: Partial<IConfig> = {
  validation: false,
};

@NgModule({
  declarations: [    
    PessoaPageComponent,
    PessoaFormComponent,
    PessoaListComponent,
    FieldErrorControlComponent,
    PessoaExcluirModalComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    PessoaRoutingModule,
    FontAwesomeModule, 
    NgSelectModule,
    NgxMaskModule.forRoot(maskConfig)
  ],
  providers:[BuscaCepService, PessoaService]
})
export class PessoaModule { }
