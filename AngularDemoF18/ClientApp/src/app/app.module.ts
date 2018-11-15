import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ProductComponent } from './product/product.component';
import { ProductlistComponent } from './productlist/productlist.component';
import { HomeComponent } from './home/home.component';
import { AddProductComponent } from './add-product/add-product.component';

const appRoutes: Routes = [
  { path: 'product', component: ProductComponent },
  { path: 'products', component: ProductlistComponent }
]

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    ProductlistComponent,
    HomeComponent,
    AddProductComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
