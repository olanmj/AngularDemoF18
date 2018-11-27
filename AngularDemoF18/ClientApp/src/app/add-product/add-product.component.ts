import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Product } from '../product/product.component';
import { ProductService } from '../product.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { DataService } from '../data.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  // model must be a typed object in order for the production
  // build to work when publishing to Azure
  model = new Product();
  result: any;
  posted = false;
  prod = null;

  @Output() onAdd = new EventEmitter<Product>();

  constructor(private service: ProductService,
    private router: Router,
    private dataService: DataService) { }

  ngOnInit() {
    this.dataService.currentMessage.subscribe(p => {
     
    });
  }

  onsubmit(form: NgForm) {
    //console.log(this.model);
    this.service.postProduct(this.model as Product)
      .subscribe(result => {
        this.result = result;
        console.log(result);
        this.posted = true;
        form.reset();
       // this.onAdd.emit(this.model);
        this.dataService.changeMessage(this.model);
      },
      error => console.log(error)
      )
  }

}
