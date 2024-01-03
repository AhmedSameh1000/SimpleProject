import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CategoryService } from 'src/app/services/category.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css'],
})
export class CreateProductComponent {
  constructor(
    private ServiceCategory: CategoryService,
    private ProductService: ProductService
  ) {}
  ngOnInit(): void {
    this.LoadCategories();
    this.CreateProductForm();
  }
  ProductForm: FormGroup;
  CreateProductForm() {
    this.ProductForm = new FormGroup({
      Name: new FormControl(null, [Validators.required]),
      Price: new FormControl(null, [Validators.required]),
      MinimumQuantity: new FormControl(null, [Validators.required]),
      DiscountRate: new FormControl(null, [Validators.required]),
      CategoryId: new FormControl(null, [Validators.required]),
      file: new FormControl('', [Validators.required]),
    });
  }
  Categorylist = [];

  LoadCategories() {
    this.ServiceCategory.GetCategories().subscribe({
      next: (Response: any) => {
        console.log(Response);
        this.Categorylist = Response.data;
      },
    });
  }

  CreateProduct() {
    let productDTO = this.GetProductFormData();
    this.ProductService.Createproduct(productDTO).subscribe({
      next: (res) => {
        console.log(res);
      },
    });
  }
  SelectImage($event: any) {
    this.ProductForm.get('file')?.setValue($event.target.files[0]);
  }

  private GetProductFormData(): any {
    let productDTO = new FormData();
    productDTO.append('Name', this.ProductForm.value['Name']);
    productDTO.append('Price', this.ProductForm.value['Price']);
    productDTO.append('DiscountRate', this.ProductForm.value['DiscountRate']);
    productDTO.append('CategoryId', this.ProductForm.value['CategoryId']);
    productDTO.append(
      'MinimumQuantity',
      this.ProductForm.value['MinimumQuantity']
    );
    productDTO.append(
      'file',
      this.ProductForm.value['file'],
      this.ProductForm.value['file'].name
    );

    return productDTO;
  }
}
