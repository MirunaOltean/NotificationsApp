import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Announcement } from '../announcement';
import { Category } from '../category';
import { AnnouncementService } from '../services/announcement.service';
import { CategoryService } from '../services/category.service';
import { NotificationServiceService } from '../services/notification-service.service';

@Component({
  selector: 'app-add-announcement',
  templateUrl: './add-announcement.component.html',
  styleUrls: ['./add-announcement.component.scss']
})
export class AddAnnouncementComponent implements OnInit {

  title:string = "";
  message:string = "";
  description= "";
  author: string = "";
  image: string ="1.jpg";
  categories:Category[];
  selectedCategory : Category =  <Category> {};
  images: string[] = ['1.jpg', '2.jpg','3.jpg','4.jpg'];

  constructor(private announcementsService: AnnouncementService, private categoryService: CategoryService,
    private notificationService: NotificationServiceService, private router: Router) {
    this.categories = categoryService.getCategories();
   }

  ngOnInit(): void {
  }

  addEvent(){
    const newAnnouncement: Announcement ={
      title: this.title,
      message: this.message,
      description: this.description,
      author: this.author,
      categoryId: this.selectedCategory.id,
      category: this.selectedCategory.name,
      imageUrl: this.image,
    }
    
    this.announcementsService.addAnnouncement(newAnnouncement).subscribe(r => {
      this.notificationService.sendMessage("BroadcastMessage", [r]);
      this.router.navigateByUrl('home');});
  }
  
}
