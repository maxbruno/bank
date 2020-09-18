import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-list-account',
  templateUrl: './list-account.component.html'
})
export class ListAccountComponent implements OnInit {

  accounts: any;
  errorMessage: string;

  constructor(private accountService: AccountService) { }

  ngOnInit() {
    this.getAccounts();
  }

  getAccounts(): void {
    this.accountService.getAccounts()
      .subscribe(
        data => {
          this.accounts = data;
        },
        error => {
          this.errorMessage = error;
        });
  }
}
