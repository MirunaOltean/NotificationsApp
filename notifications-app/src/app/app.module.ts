import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule} from '@angular/material/input';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatIconModule} from '@angular/material/icon';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AnnouncementComponent } from './announcement/announcement.component';
import { CategoriesComponent } from './categories/categories.component';
import { HomeComponent } from './home/home.component';
import { ByAuthorPipe } from './by-author.pipe';
import { AddAnnouncementComponent } from './add-announcement/add-announcement.component';
import { AnnouncementService } from './services/announcement.service';
import { EditAnnouncementComponent } from './edit-announcement/edit-announcement.component';
import { NotificationServiceService } from './services/notification-service.service';

@NgModule({
  declarations: [
    AppComponent,
    AnnouncementComponent,
    CategoriesComponent,
    HomeComponent,
    ByAuthorPipe,
    AddAnnouncementComponent,
    EditAnnouncementComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    HttpClientModule
  ],
  providers: [AnnouncementService, NotificationServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
