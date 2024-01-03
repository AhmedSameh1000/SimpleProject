import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CreateProductComponent } from '../create-product/create-product.component';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
})
export class ProductListComponent {
  constructor(private MatDialog: MatDialog) {}
  OpenCreateproduct() {
    this.MatDialog.open(CreateProductComponent, {
      width: '80%',
      height: '70%',
    });
  }
}
