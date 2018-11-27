import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Product } from './product/product.component';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private messageSource = new BehaviorSubject<Product>(null);
  currentMessage = this.messageSource.asObservable();

  constructor() { }

  changeMessage(prod: Product) {
    this.messageSource.next(prod);  
  }
}
