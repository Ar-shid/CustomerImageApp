# Customer Image App

This is a small ASP.NET Core MVC demo application that lets you create customers and upload images to their profiles.

## Features
- Create customers.
- Upload up to **10 images per customer** (images stored as Base64 in the database).
- Delete images.
- View images in a responsive Bootstrap carousel with thumbnails.

## Quick Start

1. **Clone or download** the repository.
2. **Open the solution** in Visual Studio 2022 (or later).
3. **Update** the `DefaultConnection` string in `appsettings.json` to point to your SQL Server.
4. **Run the application** (F5 or `dotnet run`).

The app automatically applies EF Core migrations on startup.

### Usage
1. Go to the **Customers** page (root `/` already redirects there).
2. Click **Add Customer** and enter a name.
3. Click on the new customer to view their profile.
4. Use the **Upload Images** form to select one or more image files (up to 10 total per customer).
5. View, navigate or delete images directly from the carousel.

That’s it — no extra setup needed.
