تفضل! 👇

---

```
# 💧 Water Leak Detection System

A full-stack web application built with ASP.NET Core MVC 
following the 3-Tier Architecture pattern, designed for a 
professional water leak detection company in Egypt.

## 🚀 Features

### Client Side
- Submit leak detection requests with problem type,
  description, and contact info
- Track request status by ID or phone number
- Add notes to existing requests (phone verification required)
- View company gallery, videos, and client testimonials
- Arabic/English language support (RTL/LTR)

### Admin Dashboard
- Secure login with ASP.NET Identity
- View and manage all incoming requests
- Update request status (Pending / In Progress / Done)
- Add/Remove images to gallery
- Add/Remove YouTube videos
- Add/Manage client testimonials
- Control which comments are visible to clients
- Add new admin accounts

## 🏗️ Architecture

3-Tier Architecture:
- Presentation Layer (PL) → ASP.NET Core MVC
- Business Logic Layer (BLL) → Services + ViewModels
- Data Access Layer (DAL) → Repositories + Unit of Work

## 🛠️ Tech Stack

- ASP.NET Core MVC (.NET 9)
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- Bootstrap 5.3
- Font Awesome 6
- AOS (Animate On Scroll)

## 📁 Project Structure

├── Professonal.DAL
│   ├── Models
│   ├── Data (AppDbContext)
│   ├── Repositories
│   └── UnitOfWork
│
├── Profissonal.PPL (BLL)
│   ├── ViewModels
│   ├── Response
│   └── Services
│
└── Profetional.pl (PL)
    ├── Controllers
    ├── Views
    ├── Services (AccountService)
    └── wwwroot

## ⚙️ Getting Started

1. Clone the repository
git clone https://github.com/yourusername/water-leak-detection.git

2. Update connection string in appsettings.json
"DefaultConnection": "Server=.;Database=LeakDetectionDb;
Trusted_Connection=True;TrustServerCertificate=True"

3. Update admin credentials in appsettings.json
"AdminSettings": {
  "Email": "admin@leak.com",
  "Password": "YourStrongPassword"
}

4. Apply migrations
Add-Migration InitialCreate
Update-Database

5. Run the project
dotnet run

## 🔐 Security Features
- ASP.NET Identity authentication
- Anti-forgery token on all forms
- Phone verification for client notes
- Authorized admin routes
- Account lockout after failed attempts

## 📸 Screenshots
Coming soon...

## 👨‍💻 Author
Your Name
GitHub: @yourusername

## 📄 License
This project is licensed under the MIT License
```

---

غير بس:
- `yourusername` باسمك على GitHub
- `Your Name` باسمك
- ضيف Screenshots لما تخلص 🎯
