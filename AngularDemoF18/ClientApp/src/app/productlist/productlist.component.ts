import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Product } from '../product/product.component';
import { DataService } from '../data.service';

@Component({
  selector: 'app-productlist',
  templateUrl: './productlist.component.html',
  styleUrls: ['./productlist.component.css']
})
export class ProductlistComponent implements OnInit {
  products: Product[];
  total = 0;
  prod: Product;
  constructor(private service: ProductService, private dataService: DataService) { }

  ngOnInit() {
    this.service.getProducts().subscribe(data => {
      this.products = data;
      for (let p of this.products) {
        this.total += p.amountDue;
      }
    });
    this.dataService.currentMessage.subscribe((p: Product) => {
      if (p) {
        this.products.push(p);
        window.location.reload();
      }
    });
  }

 //onAdd(value) {
 //  this.products.push(value);
 //   window.location.reload();
 //   }
}
