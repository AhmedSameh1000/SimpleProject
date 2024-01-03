import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-create-category',
  templateUrl: './create-category.component.html',
  styleUrls: ['./create-category.component.css'],
})
export class CreateCategoryComponent {
  constructor(
    private dialogRef: MatDialogRef<CreateCategoryComponent>,
    private ServiceCategory: CategoryService
  ) {}
  ngOnInit(): void {
    this.CreateCategoryForm();
  }
  CategoryForm: FormGroup;

  CreateCategoryForm() {
    this.CategoryForm = new FormGroup({
      categoryName: new FormControl(null, [Validators.required]),
    });
  }
  Close() {
    this.dialogRef.close();
  }
  CreateCategory() {
    if (this.CategoryForm.invalid) {
      return;
    }
    this.ServiceCategory.CreateCategory(
      this.CategoryForm.value.categoryName
    ).subscribe({
      next: (res) => {
        console.log(res);
        this.dialogRef.close(true);
      },
    });
  }
}
