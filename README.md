
---

# 🌾 **Agri-Energy-Connect**

A Smart Agricultural Product Management Platform

Agri-Energy-Connect is a **modern web platform** built with **ASP.NET Core MVC** and **Identity**, empowering South African farmers and agricultural employees with efficient **product management** and **secure access control** through a user-friendly interface.

---

## 🧩 **Project Overview**

Designed for the **South African agriculture sector**, Agri-Energy-Connect enables:

* 🌱 **Farmers** to register, showcase, and manage their agricultural products.
* 🧑‍💼 **Employees (Admins)** to oversee system operations, manage farmer records, and maintain data integrity.

While regionally focused, the platform is scalable and adaptable for **global agricultural ecosystems**.

---

## 🚀 **Tech Stack**

| Technology                | Purpose                                 |
| ------------------------- | --------------------------------------- |
| **ASP.NET Core MVC**      | Web framework for dynamic applications  |
| **Entity Framework Core** | Database ORM for clean data operations  |
| **ASP.NET Identity**      | User authentication and role management |
| **Bootstrap 5**           | Responsive front-end UI framework       |
| **Razor Views**           | Server-rendered HTML templates          |
| **SQL Server**            | Primary relational database             |
| **LINQ & Lambda**         | Powerful data querying tools            |

---

## 👥 **User Roles & Access**

| 👤 **Role**                | 🔍 **Permissions**                                                       |
| -------------------------- | ------------------------------------------------------------------------ |
| 🧑‍💼 **Employee (Admin)** | Full system access: manage users, products, and configurations           |
| 👨‍🌾 **Farmer**           | Register/login, manage personal product listings, and view relevant data |

Role-based access is enforced using `[Authorize(Roles = "...")]` in both controllers and views to ensure a secure experience.

---

## 🔐 **Authentication & Authorization**

* ✅ **Secure Registration & Login**
* 🔐 **Password Hashing & Storage**
* 🧾 **Automatic Role Assignment on Signup**
* 🔒 **Protected Routes & Views by Role**

Authentication is powered by **ASP.NET Identity**, ensuring robust access control and user session management.

---

## 📦 **Key Features**

### 👨‍🌾 **Farmer Dashboard**

* Register and log in securely
* Upload, edit, and delete personal product entries
* Browse a filterable list of products (by date, type, etc.)

### 👩‍💼 **Employee Dashboard**

* View and manage all product listings
* Perform CRUD operations on farmers and records
* Configure product types and categories *(future-ready for extensibility)*

---

## 🎨 **UI/UX Design Highlights**

* ✨ **Modern, responsive design** with **Bootstrap 5**
* 📱 Optimized for desktop and mobile devices
* 📦 **Card-based layouts** for product and data display
* 🔍 Intuitive filters and sorting tools for quick access
* 🧭 Consistent navigation with clear CTA buttons and feedback messages

---

## 📁 **Simplified Folder Structure**

```plaintext
AgriEnergyConnect/
├── Controllers/        # MVC Controllers for logic
├── Models/             # Entity models for DB
├── Views/              # Razor pages per controller
├── Data/               # DB context and migrations
├── wwwroot/            # Static files (CSS, JS, images)
├── Services/           # Business logic and helpers
└── appsettings.json    # App configuration
```

---
