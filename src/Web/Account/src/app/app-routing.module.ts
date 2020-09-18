import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { ListAccountComponent } from './components/list-account/list-account.component';
import { FormTransactionComponent } from './components/form-transaction/form-transaction.component';
import { DetailTransactionComponent } from './components/detail-transaction/detail-transaction.component';

const routes: Routes = [
  { path: 'transaction-details/:id', component: DetailTransactionComponent },
  { path: 'create-transaction/:id', component: FormTransactionComponent },
  { path: 'list-accounts', component: ListAccountComponent },
  { path: '', pathMatch: 'full', redirectTo: 'list-accounts' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
