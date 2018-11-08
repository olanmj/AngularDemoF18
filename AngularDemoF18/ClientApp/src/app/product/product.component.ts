import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  product: Product;
 
  constructor(private service: ProductService) { }

  ngOnInit() {
    this.service.getProduct(1)
      .subscribe(data => {
        this.product = data;
      });
  }

}

export interface Product {
  productID: number,
  name: string,
  description: string, 
  category: string,
  quantity: number,
  price: number,
  amountDue: number
}
