import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs';
import { Announcement } from '../announcement';
import { Category } from '../category';
import { AnnouncementService } from '../services/announcement.service';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-edit-announcement',
  templateUrl: './edit-announcement.component.html',
  styleUrls: ['./edit-announcement.component.scss']
})
export class EditAnnouncementComponent implements OnInit {

  announcement: Announcement = {
    title: "",
    message: "",
    description: "",
    author: "",
    imageUrl: "",
    id: "",
    categoryId: "",
    category: ""
  }
  categories: Category[];
  images: string[] = ['1.jpg', '2.jpg', '3.jpg', '4.jpg'];


  constructor(private announcementService: AnnouncementService, route: ActivatedRoute, private categoryService: CategoryService) {
    let id = route.snapshot.paramMap.get('id');
    this.categories = categoryService.getCategories();

    announcementService.getAnnouncementByID(id).subscribe(items => this.announcement = items[0]);
  }

  ngOnInit(): void {
  }


  editEvent() {
    this.announcement.categoryId = this.categories.find(category => category.name === this.announcement.category)?.id || '0';

    console.log(typeof(this.announcement.category));
    if (this.announcement.imageUrl == null) {
      this.announcement.imageUrl = "";
    }

    this.announcementService.editAnnouncement(this.announcement).subscribe();
  }
}
