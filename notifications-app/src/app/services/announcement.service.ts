import { HttpClient, HttpHeaders } from '@angular/common/http';
import { isNgTemplate } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { UrlHandlingStrategy } from '@angular/router';
import { map, Observable, of } from 'rxjs';
import { Announcement } from '../announcement';
import { Category } from '../category';

@Injectable({
  providedIn: 'root'
})
export class AnnouncementService {

  readonly baseURL = "https://localhost:44322/Announcements";
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };


  constructor(private httpClient: HttpClient) { }


  getAnnouncements() {
    return this.httpClient.get<Announcement[]>(this.baseURL, this.httpOptions);
  }

  addAnnouncement(item: Announcement) {
    return this.httpClient.post(this.baseURL, item, this.httpOptions);
  }

  editAnnouncement(item: Announcement){
    return this.httpClient.put(`${this.baseURL}/${item.id}`, item);
  }

  getAnnouncementByID(id: string | null ){
    return this.httpClient.get<Announcement[]>(this.baseURL, this.httpOptions).pipe(map(announcements => {
      return announcements.filter(item => item.id === id);
    }));
  }

  getAnnouncementsByCategory(category : string ){
    return this.httpClient.get<Announcement[]>(this.baseURL, this.httpOptions).pipe(map(announcements => {
      return announcements.filter(item => item.category === category);
    }));
  }



  deleteAnnouncement(id: string | undefined) {
    return this.httpClient.delete<Announcement[]>(`${this.baseURL}/${id}`, this.httpOptions);
  }
}
