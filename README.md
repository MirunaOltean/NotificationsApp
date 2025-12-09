# 📣 Notifications App
A full-stack notifications and announcements system built with **C#/.NET 6**, **MongoDB**, **SignalR**, and a **TypeScript frontend**.  
Users can create, edit, categorize, and receive real-time notifications.

---

## 🚀 Overview
This application demonstrates a **full-stack implementation** with real-time communication. Key features include:

- A **backend** using **.NET 6** with controllers, services, and a SignalR hub  
- A **frontend** using **TypeScript** with modular components and services  
- Real-time notifications delivered via **SignalR**  
- CRUD operations for announcements and categories stored in **MongoDB**

The project is designed to showcase enterprise-style architecture and full-stack development practices.

---

## 🛠️ Tech Stack

### Backend (C#/.NET 6)
- ASP.NET Core 6  
- Controllers: `AnnouncementsController.cs`, `CategoryController.cs`  
- Services: `AnnouncementCollectionService.cs`, `IAnnouncementCollectionService.cs`, `ICollectionService.cs`  
- **SignalR**: `NotificationsHub.cs` for broadcasting notifications  
- MongoDB
- Dependency Injection  

### Frontend (TypeScript)
- TypeScript  
- Components:
  - `announcement`
  - `home`
  - `add-announcement`
  - `edit-announcement`
  - `categories`
- Services:
  - `announcement.service.ts` (CRUD for announcements)  
  - `category.service.ts` (CRUD for categories, category listing)  
  - `notification-service.service.ts` (connects to SignalR hub for real-time notifications)  
- Modular folder structure and API integration  

---

## ✨ Features

### Frontend
- View announcements in real time  
- Add, edit, and categorize announcements  
- Real-time updates via SignalR notifications  
- Component-based structure for scalability  

### Backend
- CRUD operations for announcements and categories  
- **SignalR hub** broadcasts notifications to all connected clients  
- Modular service layer for clean separation of concerns  
- MongoDB database integration  

---

