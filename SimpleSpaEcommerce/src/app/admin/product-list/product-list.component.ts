import { ProductService } from 'src/app/services/product.service';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CreateProductComponent } from '../create-product/create-product.component';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
})
export class ProductListComponent implements OnInit {
  constructor(
    private MatDialog: MatDialog,
    private ProductService: ProductService
  ) {}
  ngOnInit(): void {
    this.loadproducts();
  }
  OpenCreateproduct() {
    this.MatDialog.open(CreateProductComponent, {
      width: '80%',
      height: '70%',
    });
  }
  ProductList = [];
  loadproducts() {
    this.ProductService.GetProducts().subscribe({
      next: (res: any) => {
        console.log(res.data);
      },
    });
  }
}
