# 🏥 SmartClinic – Clinic Appointment Management System

SmartClinic is a web-based Clinic Appointment Management System developed using ASP.NET Core MVC. It helps manage patient information, doctor details, and clinic appointments.

## 🚀 Features

- Schedule new patient appointments.
- View all scheduled appointments.
- Select patients and doctors.
- Cancel appointments.
- Validate appointment dates.
- Display appointment status.
- Store data using SQLite database.
- Track the last booked appointment using Session.

## 🛠️ Technologies Used

- **Frontend:** HTML, CSS, Bootstrap, Razor Views
- **Backend:** C#
- **Framework:** ASP.NET Core MVC
- **Database:** SQLite
- **ORM:** Entity Framework Core
- **IDE:** Visual Studio / VS Code

## 📂 Project Structure

```text
SmartClinic/
├── Controllers/
│   └── AppointmentController.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Models/
│   ├── Appointment.cs
│   ├── Doctor.cs
│   └── Patient.cs
├── Views/
│   ├── Appointment/
│   │   ├── Create.cshtml
│   │   └── Index.cshtml
│   └── Shared/
├── wwwroot/
│   └── css/
├── Program.cs
├── appsettings.json
└── SmartClinic.csproj
```

## ⚙️ Installation and Setup

### 1. Clone the repository

```bash
git clone https://github.com/YuvrajSojal/SmartClinic-ASPNetCore.git
```

### 2. Open the project folder

```bash
cd SmartClinic-ASPNetCore
```

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Run the application

```bash
dotnet run --framework net8.0
```

### 5. Open in browser

Use the localhost URL displayed in your terminal.

## 💾 Database

SmartClinic uses SQLite with Entity Framework Core. The database is created automatically when the application starts.

## 🎯 Project Objective

The main objective of this project is to simplify clinic appointment management and demonstrate practical knowledge of ASP.NET Core MVC, C#, Entity Framework Core, and database operations.

## 👨‍💻 Developer

**Yuvraj Sojal**

B.Tech Computer Science Engineering

GitHub: [YuvrajSojal](https://github.com/YuvrajSojal)

---



