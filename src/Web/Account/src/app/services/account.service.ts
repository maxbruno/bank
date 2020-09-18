import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import * as Op from 'rxjs/operators';
import { TransactionModel } from 'src/app/components/form-transaction/transactionModel';
import { BaseService } from 'src/app/services/base.service';
import { catchError } from "rxjs/operators";


@Injectable({
  providedIn: 'root'
})
export class AccountService extends BaseService {
  baseUrl: string = 'http://localhost:4100/api/Account';

  constructor(private http: HttpClient) { super() }

  getAccounts(): Observable<any> {
    return this.http
      .get<any>(this.baseUrl, super.GetHeaderJson())
      .pipe(catchError(super.serviceError));
  }

  getTransactionByAccountID(id: any): Observable<any> {
    return this.http
      .get<any>(this.baseUrl + "/transactions/" + id, super.GetHeaderJson())
      .pipe(catchError(super.serviceError));
  }

  postTransaction(model: TransactionModel): Observable<any> {
    return this.http.post(this.baseUrl, model)
      .pipe(catchError(super.serviceError));
  }
}
