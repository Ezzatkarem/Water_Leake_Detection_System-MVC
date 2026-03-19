# 💧 Water Leak Detection System

![Stars](https://img.shields.io/github/stars/EzzatKarem/water-leak-detection?style=social)
![Forks](https://img.shields.io/github/forks/EzzatKarem/water-leak-detection?style=social)
![License](https://img.shields.io/badge/license-MIT-blue)
![ASP.NET](https://img.shields.io/badge/ASP.NET-Core%209.0-purple)
![SQL Server](https://img.shields.io/badge/SQL-Server-red)

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
- Submit leak detection requests with problem type, description, and contact info
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
- **Presentation Layer (PL)** → ASP.NET Core MVC
- **Business Logic Layer (BLL)** → Services + ViewModels
- **Data Access Layer (DAL)** → Repositories + Unit of Work

## 🛠️ Tech Stack

- **ASP.NET Core MVC** (.NET 9)
- **Entity Framework Core**
- **SQL Server**
- **ASP.NET Core Identity**
- **Bootstrap 5.3**
- **Font Awesome 6**
- **AOS** (Animate On Scroll)

## 📁 Project Structure
