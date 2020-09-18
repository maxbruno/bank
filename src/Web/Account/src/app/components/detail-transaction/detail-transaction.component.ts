import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/services/account.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-detail-transaction',
  templateUrl: './detail-transaction.component.html'
})
export class DetailTransactionComponent implements OnInit {

  transactions: any;
  errorMessage: string;

  constructor(private accountService: AccountService,
    private route: ActivatedRoute,
  ) { }

  ngOnInit() {
    this.getTransactionsByAccountID(this.route.snapshot.paramMap.get('id'));
  }

  getTransactionsByAccountID(id): void {
    this.accountService.getTransactionByAccountID(id)
      .subscribe(
        data => {
          this.transactions = data;
        },
        error => {
          this.errorMessage = error;
        });
  }
}
