# Customer Image App

A small ASP.NET Core MVC application to create customers and upload/view images tied to each customer profile.

---

## ✨ Features
- Create customers.
- Upload up to **10 images per customer** (images stored Base64-encoded in the database).
- Delete images.
- View images in a responsive Bootstrap carousel with thumbnails.

---

## 🚀 Quick Start

1. **Clone or download** the repository.
2. **Open the solution** in Visual Studio 2022 (or later).
3. **Update** the `DefaultConnection` string in `appsettings.json` to point to your SQL Server instance.
4. **Build & run** the application (`F5` or `dotnet run`).

EF Core migrations are applied automatically on startup.

### Usage
1. Go to the **Customers** page (the root `/` redirects there).
2. Click **Add Customer** and enter a name.
3. Click on the new customer to view its profile.
4. Use the **Upload Images** form to select one or more image files (up to 10 total per customer).
5. View, navigate or delete images directly from the carousel.

---

## 🛠️ Technical Details

| Aspect              | Details |
|---------------------|---------|
| **Framework**       | ASP.NET Core 8.0 MVC |
| **Language**        | C# |
| **IDE**             | Visual Studio 2022 |
| **Frontend**        | Razor Views + Bootstrap 5 |
| **Icons**           | Bootstrap Icons |
| **Database**        | SQL Server (via Entity Framework Core) |
| **Migrations**      | EF Core Code-First |
| **File Storage**    | Images stored as Base64 strings in the database (no external file storage) |
| **Validation**      | Data Annotations on model properties |
| **Architecture**    | Standard MVC: Controllers handle HTTP, Views render UI, Models + DbContext handle data persistence |
