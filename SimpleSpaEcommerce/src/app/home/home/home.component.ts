import { Component } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  constructor(private ProductService: ProductService) {}
  ngOnInit(): void {
    this.loadproducts();
  }
  ProductList = [];
  loadproducts() {
    this.ProductService.GetProducts().subscribe({
      next: (res: any) => {
        console.log(res.data);
        this.ProductList = res.data;
      },
    });
  }
}
