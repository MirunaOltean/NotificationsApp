import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Category } from '../category';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss']
})
export class CategoriesComponent implements OnInit {

  categories: Category[] ;
  @Output() emitSelectedCategory = new EventEmitter<Category>();

  constructor(private categoryService: CategoryService) { 
      this.categories= this.categoryService.getCategories();
  }

  ngOnInit(): void {
  }

  selectedCategory(category :Category | null){
    if(category != null){
    this.emitSelectedCategory.emit(category);
    }
    else{
      this.emitSelectedCategory.emit(<Category>{name:'All', id:'0'})
    }
  }
}
