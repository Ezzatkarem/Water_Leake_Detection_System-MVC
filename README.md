# 💧 Water Leak Detection System

![Stars](https://img.shields.io/github/stars/EzzatKarem/water-leak-detection?style=social)
![Forks](https://img.shields.io/github/forks/EzzatKarem/water-leak-detection?style=social)
![License](https://img.shields.io/badge/license-MIT-blue)
![ASP.NET](https://img.shields.io/badge/ASP.NET-Core%209.0-purple)
![SQL Server](https://img.shields.io/badge/SQL-Server-red)
![Arabic](https://img.shields.io/badge/lang-Arabic-green)

<p align="center">
  <img src="https://github.com/user-attachments/assets/3d922ace-80f2-4f00-a79d-d39775eb2130" 
       alt="Water Leak Detection System Screenshot" 
       width="800">
  <br>
  <em>الصفحة الرئيسية - Water Leak Detection System</em>
</p>

A full-stack web application built with ASP.NET Core MVC 
following the 3-Tier Architecture pattern, designed for a 
professional water leak detection company in Egypt.

## 📋 Table of Contents
- [Features](#-features)
- [Architecture](#-architecture)
- [Tech Stack](#-tech-stack)
- [Project Structure](#-project-structure)
- [Getting Started](#-getting-started)
- [Security](#-security-features)
- [Screenshots](#-screenshots)
- [Author](#-author)

## 🚀 Features

### Client Side
| Feature | Description |
|---------|-------------|
| 📝 Request Submission | Submit leak detection requests with problem type, description, and contact info |
| 🔍 Request Tracking | Track request status by ID or phone number |
| 📝 Add Notes | Add notes to existing requests with phone verification |
| 🖼️ Gallery | View company gallery of completed projects |
| 🎥 Videos | Watch YouTube videos showcasing work |
| 💬 Testimonials | Read client testimonials and reviews |
| 🌐 RTL Support | Arabic/English language support with full RTL/LTR |

### Admin Dashboard
| Feature | Description |
|---------|-------------|
| 🔐 Secure Login | ASP.NET Identity authentication with account lockout |
| 📊 Request Management | View and manage all incoming requests |
| 🔄 Status Updates | Update request status (Pending / In Progress / Done) |
| 🖼️ Gallery Management | Add/Remove images to gallery |
| 🎥 Video Management | Add/Remove YouTube videos |
| 💬 Testimonials | Add/Manage client testimonials |
| 👥 Admin Management | Add new admin accounts |

## 🏗️ Architecture

**3-Tier Architecture:**
- **Presentation Layer (PL)** → ASP.NET Core MVC Views & Controllers
- **Business Logic Layer (BLL)** → Services + ViewModels + Response Models
- **Data Access Layer (DAL)** → Repositories + Unit of Work + DbContext

## 🛠️ Tech Stack

### Backend
- **ASP.NET Core MVC** (.NET 9)
- **Entity Framework Core** 9.0
- **SQL Server** 2022
- **ASP.NET Core Identity** for authentication
- **Repository Pattern** with Unit of Work

### Frontend
- **Bootstrap 5.3** with RTL support
- **Font Awesome 6** icons
- **AOS** (Animate On Scroll) library
- **jQuery** 3.7.1
- **Responsive Design** (Mobile first)

### Development Tools
- **Visual Studio 2022**
- **SQL Server Management Studio**
- **Git** for version control
- **IIS Express** for local hosting

## 📁 Project Structure
Water-Leak-Detection/
│
├── Professonal.DAL/ # Data Access Layer
│ ├── Models/ # Entity Models
│ │ ├── Account.cs
│ │ ├── Comment.cs
│ │ ├── LeakRequest.cs
│ │ ├── MediaItem.cs
│ │ ├── Vedio.cs
│ │ └── ...
│ ├── Data/ # DbContext
│ │ └── AppDbContext.cs
│ ├── Repositories/ # Generic Repository
│ │ ├── IGenericRepository.cs
│ │ └── GenericRepository.cs
│ └── UnitOfWork/ # Unit of Work
│ ├── IUnitOfWork.cs
│ └── UnitOfWork.cs
│
├── Profissonal.PPL/ # Business Logic Layer
│ ├── ViewModels/ # View Models
│ │ ├── LeakRequestVM.cs
│ │ ├── CommentVM.cs
│ │ ├── VedioVM.cs
│ │ └── MediaItemVM.cs
│ ├── Response/ # Response Models
│ │ └── Response.cs
│ └── Services/ # Business Services
│ ├── Abstract/
│ │ ├── ILeakRequestService.cs
│ │ ├── ICommentService.cs
│ │ ├── IVedioService.cs
│ │ └── IMediaItemService.cs
│ └── Implement/
│ ├── LeakRequestService.cs
│ ├── CommentService.cs
│ ├── VedioService.cs
│ └── MediaItemService.cs
│
└── Profetional.pl/ # Presentation Layer
├── Controllers/ # MVC Controllers
│ ├── HomeController.cs
│ ├── AccountController.cs
│ ├── AdminController.cs
│ └── ...
├── Views/ # Razor Views
│ ├── Home/
│ ├── Account/
│ ├── Admin/
│ └── Shared/
├── Services/ # Account Service
│ └── AccountService.cs
├── wwwroot/ # Static Files
│ ├── css/
│ ├── js/
│ ├── lib/
│ └── images/
├── appsettings.json # Configuration
└── Program.cs # Entry Point
🔐 Security Features
Feature	Implementation
🔑 Authentication	ASP.NET Core Identity with cookie authentication
🛡️ Authorization	Role-based authorization for admin areas
🎭 Anti-Forgery	Anti-forgery tokens on all POST forms
📞 Phone Verification	Phone number verification for adding notes
🔒 Account Lockout	5 failed attempts = 15 minutes lockout
🔐 Password Policy	Min 6 chars, 1 uppercase, 1 number
🛡️ XSS Protection	Built-in Razor HTML encoding
🔒 SQL Injection	Entity Framework parameterized queries
📸 Screenshots
Home Page
<p align="center"> <img src="https://github.com/user-attachments/assets/3d922ace-80f2-4f00-a79d-d39775eb2130" alt="Home Page" width="800"> <br> <em>الصفحة الرئيسية - Hero section with services</em> </p>
Admin Dashboard
<p align="center"> <img src="https://via.placeholder.com/800x400/0091CA/ffffff?text=Admin+Dashboard+Screenshot" alt="Admin Dashboard" width="800"> <br> <em>لوحة تحكم المدير - إدارة الطلبات</em> </p>
Request Tracking
<p align="center"> <img src="https://via.placeholder.com/800x400/00BCD4/ffffff?text=Request+Tracking+Screenshot" alt="Request Tracking" width="800"> <br> <em>تتبع حالة الطلب - بحث برقم الهاتف</em> </p>
👨‍💻 Author
Ezzat Karem

GitHub: @EzzatKarem

LinkedIn: Ezzat Karem

Email: ezzat.karem@example.com
