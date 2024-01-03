import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

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
}
