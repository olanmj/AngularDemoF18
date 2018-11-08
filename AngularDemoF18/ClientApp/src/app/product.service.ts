import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Product } from './product/product.component';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = 'api/products/';

  constructor(private http: HttpClient) { }

  getProduct(id: number) {
     return this.http.get<Product>(`${this.baseUrl}${id}`)
  }

  getProducts() {
    return this.http.get<Product[]>(this.baseUrl);
  }
}
