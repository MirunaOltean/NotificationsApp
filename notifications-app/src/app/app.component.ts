import { Component, Input } from '@angular/core';
import { Category } from "./category";
import { Announcement } from './announcement';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'notifications-app';
}
