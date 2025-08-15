import { Injectable } from "@angular/core";
import { Category } from "../category";


@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  
  categories:Category[] = [
    {name: "General", id: "0"},
    {name: "Course", id: "1"},
    {name: "Laboratory", id: "2"},
  ]

  constructor() { }

  getCategories(){
    return this.categories;
  }

  getCategoryById(categoryId: string) {
    return this.categories.find(item => item.id === categoryId);
  }

}
