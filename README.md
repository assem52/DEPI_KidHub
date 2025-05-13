




# 📘 Yala Learn – Educational Platform (MVP)

**Yala Learn** is a full-stack Arabic educational platform designed to deliver accessible, high-quality learning experiences. It supports **free** and **premium** courses, a secure **payment gateway**, and clean, scalable architecture following best practices in modern web development.

---

## 🌟 Features

- ✅ User Registration & JWT Authentication
- ✅ Role-based Access (User / Admin)
- ✅ Browse Free and Premium Courses
- ✅ Secure Payment Integration via **Paymob**
- ✅ Course & Lesson Management
- ✅ Cloud-based Media Upload via **Cloudinary**
- ✅ Clean Architecture with Repository Pattern
- ✅ API Documentation using Swagger
- 🔜 Planned: Lesson Ratings, Reviews, Quizzes, and React UI

---

## 🧱 Project Architecture – Clean Architecture

The platform is structured using **Clean Architecture**, separating responsibilities across four main layers:



📦 YalaLearn\
┣ 📂 YalaLearn.API → Presentation Layer (Controllers, DTOs, Auth) \
┣ 📂 YalaLearn.Domain → Core Entities, Interfaces (Course, Lesson, etc.)\
┣ 📂 YalaLearn.Data → EF Core DbContext, Repository Implementations\
┣ 📂 YalaLearn.Infrastructure → External Integrations (Paymob, Cloudinary, etc.)


This design ensures **Separation of Concerns**, **Single Responsibility**, and easy **scalability** or **testing**.

---

## 📦 Repository Pattern

We applied the **Repository Pattern** to keep data access logic clean and reusable:

- A **generic `IRepository<T>` interface** defines common operations (Get, Add, Update, Delete).
- Each entity like `Course`, `Lesson`, etc., has its own repository implementing that interface.
- Helps reduce code repetition and supports **unit testing** and **dependency injection**.

---

## ☁️ Cloudinary Integration

Cloudinary is used to handle **image and video uploads**:

- Admin can upload thumbnails, video previews, or lesson media.
- Media is stored and retrieved securely via **Cloudinary API**.
- Cloudinary settings are stored in `appsettings.json` and injected via `ICloudinaryService`.

---

## 🔐 Authentication & Authorization

- Users log in using **JWT tokens**.
- **ASP.NET Core Identity** manages users and roles.
- Role-based access:
  - **User**: Access free/premium content based on subscription.
  - **Admin**: Full content & user management.

---

## 💳 Payment Flow (Paymob Integration)

1. User clicks “Enroll” on a premium course.
2. Backend calls `IPaymobService` to:
   - Authenticate with Paymob API
   - Create an order
   - Generate a payment key
   - Return an **iframe URL** to complete the payment.
3. User is redirected to Paymob’s hosted payment page.

---

## 🧪 API Testing with Swagger

Swagger is enabled for easy API testing:


✅ Tested endpoints:

- `/api/auth/register`, `/api/auth/login`
- `/api/users`, `/api/roles`  
- `/api/courses`, `/api/lessons`
- `/api/payment/create-payment`
- Add **Bearer {JWT}** in the Authorize button to test secured routes.

---

## 🌐 UI Flow

1. **Landing Page** – Introduction + CTA buttons.
2. **Login / Register** – User authentication via API.
3. **Courses Page** – Displays all available courses (filtered by access).
4. **Payment Flow** – For premium courses, redirects to Paymob checkout.
5. **Lesson Page** – Displays lesson content (future: add ratings & quizzes).

---

## 🚀 Deployment

Deployed using **ASPMonster** for .NET apps:

- ✅ Free hosting for .NET Core & SQL Server
- ✅ Easy setup with GitHub integration
- ✅ Simple database setup and config
- ✅ Great for MVPs, student projects, and low-traffic production apps

---

## 🔮 Roadmap (Post-MVP)

- ✅ Admin Panel UI
- ✅ Enhanced UI using React.js
- ✅ Lesson Ratings & Reviews
- ✅ Interactive Quizzes & Assignments
- ✅ Certificate Generation
- ✅ Instructor Dashboard
- ✅ Mobile App (React Native / Flutter)

---

## 📂 How to Run Locally

1. Clone the repo:
   ```bash
   git clone https://github.com/your-username/yala-learn.git

2. Update the connection string and Cloudinary/Paymob keys in appsettings.json.
3. Apply EF Core migrations:
   ```bash
   dotnet ef database update

4. Run the app:
   ```bash
   dotnet run
5. Open in browser:
   ```bash
   https://localhost:5001/swagger
## 🧰 Tech Stack Summary

| Feature       | Tech Used                   |
| ------------- | --------------------------- |
| Backend API   | ASP.NET Core Web API        |
| ORM           | Entity Framework Core       |
| Auth          | ASP.NET Core Identity + JWT |
| Media Hosting | Cloudinary                  |
| Payments      | Paymob Integration          |
| Documentation | Swagger (OpenAPI)           |
| Database      | SQL Server                  |
| Hosting       | ASPMonster                  |


📬 Contact
For inquiries
assem654321@gamil.com


---
