import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddProductComponent } from './components/add-product/add-product.component';
import { DetailsProductComponent } from './components/details-product/details-product.component';
import { ListProductComponent } from './components/list-product/list-product.component';
import { LoginProductComponent } from './components/login-product/login-product.component';

@NgModule({
  declarations: [
    AppComponent,
    AddProductComponent,
    DetailsProductComponent,
    ListProductComponent,
    LoginProductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
