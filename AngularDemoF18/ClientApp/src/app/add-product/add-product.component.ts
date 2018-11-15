import { Component, OnInit } from '@angular/core';
import { Product } from '../product/product.component';
import { ProductService } from '../product.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  model = {};
  result: any;
  posted = false;

  constructor(private service: ProductService, private router: Router) { }

  ngOnInit() {
  }

  onsubmit(form: NgForm) {
    //console.log(this.model);
    this.service.postProduct(this.model as Product)
      .subscribe(result => {
        this.result = result;
        console.log(result);
        this.posted = true;
        form.reset();
      },
      error => console.log(error)
      )
  }

}
