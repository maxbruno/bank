import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-form-transaction',
  templateUrl: './form-transaction.component.html'
})
export class FormTransactionComponent implements OnInit {
  isValidFormSubmitted: boolean = false;
  transactionForm = new FormGroup({
    transactionType: new FormControl('', Validators.required),
    value: new FormControl('', Validators.required),
    accountId: new FormControl('', Validators.required),
  });

  constructor(
    private accountService: AccountService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    let accountId = this.route.snapshot.paramMap.get('id');
    this.transactionForm.controls.accountId.setValue(accountId);
  }

  onFormSubmit() {
    if (this.transactionForm.invalid) {
      return;
    }
    this.accountService.postTransaction(this.transactionForm.value)
      .subscribe(data => {
        setTimeout(() => {
          this.transactionForm.reset();
          let toast = this.toastr.success('Transação realizada com sucesso!', 'Sucesso!');
          if (toast) {
            toast.onHidden.subscribe(() => {
              this.router.navigate(['/']);
            });
          }
        }, 1000);
      },
        error => {
          this.toastr.error('Ocorreu um erro!');
        }
      );
  }
}
