

```markdown
# 📘 Yala Learn – Educational Platform (MVP)

**Yala Learn** is a full-stack Arabic educational platform designed to deliver accessible, high-quality learning experiences. It supports **free** and **premium** courses, a secure **payment gateway**, and clean, scalable architecture following best practices in modern web development.

---

## 🌟 Features

- ✅ User Registration & JWT Authentication
- ✅ Role-based Access (User / Admin)
- ✅ Browse Free and Premium Courses
- ✅ Secure Payment Integration via **Paymob**
- ✅ Clean Architecture with Repository Pattern
- ✅ API Documentation using Swagger
- 🔜 Planned: Lesson Ratings, Reviews, Quizzes, and React UI

---

## 🧱 Project Architecture

The project follows the **Clean Architecture** pattern, organized into logical layers:

```

📦 YalaLearn
┣ 📂 YalaLearn.API            → Presentation layer (Controllers, DTOs)
┣ 📂 YalaLearn.Domain         → Core entities & business logic interfaces
┣ 📂 YalaLearn.Data           → EF Core DbContext, Repositories
┣ 📂 YalaLearn.Infrastructure → External services (e.g., Paymob)

```

### Key Technologies:
| Feature        | Tech Used                    |
|----------------|------------------------------|
| API            | ASP.NET Core Web API         |
| ORM            | Entity Framework Core        |
| Auth           | ASP.NET Core Identity + JWT  |
| Payment        | Paymob Payment Gateway       |
| Database       | SQL Server                   |
| Object Mapping | AutoMapper                   |
| API Docs       | Swagger (OpenAPI)            |

---

## 🔐 Authentication & Authorization

- Users register and log in using **JWT tokens**.
- Role-based access:
  - **User**: Access free courses, upgrade to premium.
  - **Admin**: Manage courses, lessons, and users.

---

## 💳 Payment Flow (Paymob Integration)

1. User clicks “Enroll” on a premium course.
2. Backend calls `IPaymobService` to:
   - Get an auth token
   - Create a Paymob order
   - Generate payment key
   - Return the payment iframe URL to frontend
3. User completes payment and gets access to the content.

---

## 🧪 API Testing with Swagger

Swagger is enabled to test and explore the API:

```

[https://yourdomain.com/swagger](https://yourdomain.com/swagger)

````

Test endpoints like:

- `/api/auth/login`
- `/api/courses`
- `/api/payment/create-payment`
- `/api/lessons`
- Protected routes support **"Bearer {JWT}"** authentication.

---

## 🌐 UI Flow

1. **Landing Page** → Introduction and Get Started button  
2. **Login/Register Pages** → JWT-based authentication  
3. **Courses Page** → Browse courses and select  
4. **Payment Redirect** (for premium) → Paymob iframe

---

## 🚀 Deployment

- Hosted using **ASPMonster** – free hosting for .NET projects with SQL Server support.
- Benefits:
  - Free & easy to set up
  - Supports auto deployment from GitHub
  - Ideal for MVPs and student projects

---

## 🔮 Roadmap (Post-MVP)

- ✅ Admin Panel UI
- ✅ Enhanced UI using React.js
- ✅ Quizzes, Assignments & Certificates
- ✅ Lesson Ratings & Reviews
- ✅ Mobile App (React Native / Flutter)
- ✅ Instructor Dashboard

---

## 🤝 Team

- Project by passionate engineering students from **Zagazig University**
- Guided by real-world problem-solving and modern development practices

---

## 📂 How to Run Locally

1. Clone the repo:
   ```bash
   git clone https://github.com/your-username/yala-learn.git
````

2. Update your SQL Server connection string in `appsettings.json`.

3. Apply migrations:

   ```bash
   dotnet ef database update
   ```

4. Run the project:

   ```bash
   dotnet run
   ```

5. Navigate to `https://localhost:5001/swagger` to test the API.

---

## 📬 Contact

Want to collaborate or learn more?
Reach us on [LinkedIn](#), [Facebook](#), or shoot an email: **[team@yala-learn.com](mailto:team@yala-learn.com)**

---

> 💡 *This is just the beginning – we aim to make Yala Learn the leading Arabic learning platform for all learners.*

```

---

Let me know if you'd like me to generate a sample GitHub repo `structure` or `.gitignore`, or if you want to include images/screenshots or demo links.
```
