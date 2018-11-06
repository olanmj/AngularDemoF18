import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Product } from '../product/product.component';

@Component({
  selector: 'app-productlist',
  templateUrl: './productlist.component.html',
  styleUrls: ['./productlist.component.css']
})
export class ProductlistComponent implements OnInit {
  products: Product[];

  constructor(private service: ProductService) { }

  ngOnInit() {
    this.service.getProducts().subscribe(data => this.products = data);
  }

}
