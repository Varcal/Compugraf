import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PessoaPageComponent } from 'src/app/pages/pessoa-page/pessoa-page.component';
import { PessoaFormComponent } from './pessoa-form/pessoa-form.component';
import { PessoaListComponent } from './pessoa-list/pessoa-list.component';

const routes: Routes = [
    {path: "pessoa", component: PessoaPageComponent, children:[
      {path:"pessoa", redirectTo:"", pathMatch: "full"},
      {path:"", component: PessoaListComponent},
      {path:"novo", component: PessoaFormComponent},
      {path:"editar/:id", component: PessoaFormComponent}
    ]}
]

@NgModule({
    imports:[RouterModule.forChild(routes)],
    exports:[RouterModule]
})

export class PessoaRoutingModule{}