import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddProductComponent } from './components/add-product/add-product.component';
import { DetailsProductComponent } from './components/details-product/details-product.component';
import { ListProductComponent } from './components/list-product/list-product.component';
import { LoginProductComponent } from './components/login-product/login-product.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'products', component: ListProductComponent },
  { path: 'products/:id', component: DetailsProductComponent },
  { path: 'add', component: AddProductComponent },
  { path: 'login', component: LoginProductComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
