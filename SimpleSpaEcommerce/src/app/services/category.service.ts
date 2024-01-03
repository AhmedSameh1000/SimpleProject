import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  constructor(private httpClient: HttpClient) {}

  CreateCategory(categoryName: any) {
    return this.httpClient.post(
      `https://localhost:7186/api/Category/CreateCategory?categoryName=${categoryName}`,
      {}
    );
  }
  GetCategories() {
    return this.httpClient.get(
      `https://localhost:7186/api/Category/GetCategories`
    );
  }
}
