import { Component, OnInit } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Announcement } from '../announcement';
import { Category } from '../category';
import { AnnouncementService } from '../services/announcement.service';
import { NotificationServiceService } from '../services/notification-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  announcements: Announcement[] = [];
  notificationMessage: string = "";


  constructor(private announcementService: AnnouncementService, private notificationService: NotificationServiceService) {
    this.announcementService.getAnnouncements().subscribe(items => this.announcements = items);
  }

  ngOnInit(): void {
       this.notificationService.initWebSocket();
       this.notificationService.notificationSubject.subscribe(hasNotifications =>
       this.notificationMessage = hasNotifications ? "New notifications, please refresh the page" : "");
  }


  receiveCategory(category: Category) {

    if (category.name !== 'All')
      this.announcementService.getAnnouncementsByCategory(category.name).subscribe(items => this.announcements = items);
    else {
      this.announcementService.getAnnouncements().subscribe(items => this.announcements = items);
    }
  }
}


