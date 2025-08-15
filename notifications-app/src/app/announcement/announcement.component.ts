import { Component, Input, OnInit } from '@angular/core';
import { Announcement } from '../announcement';
import { Category } from '../category';
import { ByAuthorPipe } from '../by-author.pipe';
import { AnnouncementService } from '../services/announcement.service';
import { Route, Router } from '@angular/router';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-announcement',
  templateUrl: './announcement.component.html',
  styleUrls: ['./announcement.component.scss']
})
export class AnnouncementComponent implements OnInit {

  @Input('announc') announcement : Announcement = {
    id: "",
    categoryId: '0', 
    category: "",
    author: "",
    message: "",
    description: "",
    title: "",
    imageUrl: ""
  };

  constructor(private announcementService: AnnouncementService, 
    private router: Router, private categoryService : CategoryService) { }

  ngOnInit(): void {
  }

  deleteEvent(id : string | undefined){
    this.announcementService.deleteAnnouncement(id).subscribe(() => { this.router.navigateByUrl("")});
  }

  getCategory(categoryId : string){
    return this.categoryService.getCategoryById(categoryId);
  }

}
