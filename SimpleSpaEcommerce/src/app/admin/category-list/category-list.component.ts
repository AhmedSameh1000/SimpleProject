import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CategoryService } from 'src/app/services/category.service';
import { CreateCategoryComponent } from '../create-category/create-category.component';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css'],
})
export class CategoryListComponent {
  constructor(
    private MatiDialog: MatDialog,
    private ServiceCategory: CategoryService
  ) {}
  ngOnInit(): void {
    this.LoadCategories();
  }
  CategoryList = [];

  OpenCreateCategory() {
    let OpenedModel = this.MatiDialog.open(CreateCategoryComponent, {
      width: '60%',
      height: '30%',
      disableClose: true,
    });
    OpenedModel.afterClosed().subscribe({
      next: (Res) => {
        if (Res) {
          this.LoadCategories();
        }
      },
    });
  }

  LoadCategories() {
    this.ServiceCategory.GetCategories().subscribe({
      next: (response: any) => {
        console.log(response);
        this.CategoryList = response.data;
      },
    });
  }
  ColumnsDisplay = ['CategoryId', 'CategoryName'];
}
