import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { CurrencyMaskInputMode, NgxCurrencyModule } from "ngx-currency";
 
export const customCurrencyMaskConfig = {
  align: "left",
  allowNegative: false,
  allowZero: false,
  decimal: ".",
  precision: 3,
  prefix: "R$ ",
  suffix: "",
  thousands: ",",
  nullable: false,
  min: null,
  max: null,
  inputMode: CurrencyMaskInputMode.FINANCIAL
};

//Imports 
import { ListAccountComponent } from './components/list-account/list-account.component';
import { FormTransactionComponent } from './components/form-transaction/form-transaction.component';
import { DetailTransactionComponent } from './components/detail-transaction/detail-transaction.component';

@NgModule({
  declarations: [
    AppComponent,
    ListAccountComponent,
    FormTransactionComponent,
    DetailTransactionComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),
    NgxCurrencyModule.forRoot(customCurrencyMaskConfig)
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
