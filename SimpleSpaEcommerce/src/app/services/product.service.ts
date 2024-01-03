import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(private httpclient: HttpClient) {}

  Createproduct(product: any) {
    return this.httpclient.post(
      'https://localhost:7186/api/Product/CreateProduct',
      product
    );
  }
  GetProducts() {
    return this.httpclient.get(
      'https://localhost:7186/api/Product/GetProducts'
    );
  }
}
