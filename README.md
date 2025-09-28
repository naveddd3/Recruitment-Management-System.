# Recruitment Management System (Backend)

A backend server for a Recruitment Management System built with **.NET Core**, **Entity Framework Core**, **JWT Authentication**, and following **Clean Architecture** principles. This system allows applicants to upload resumes, apply for jobs, and lets admins manage job openings and applicant data.

---

## Features

### Applicant
- Create and manage profile
- Upload resumes (PDF & DOCX only)
- View available job openings
- Apply for job openings

### Admin
- Create and manage job openings
- View all uploaded resumes
- View extracted data from resumes

---

## Tech Stack
- **Language & Framework:** C#, .NET 8
- **Database:** SQL Server (EF Core)
- **Authentication:** JWT-based authentication
- **Architecture:** Clean Architecture with Repository Pattern
- **Resume Processing:** Integrated with a third-party API to extract resume data

---

## Project Structure (Clean Architecture)
**RecruitmentManagementSystem/
```bash
├── src/
│ ├── Application/ # Business logic, services, DTOs, interfaces
│ ├── Domain/ # Entities, value objects
│ ├── Infrastructure/ # EF Core DbContext, repository implementations
│ ├── API/ # Controllers, Program.cs, DI setup
├── Tests/ # Unit tests (if implemented)
└── README.md
```

## Getting Started
### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server (local or remote)
- IDE like Visual Studio / VS Code
- Postman (optional, for API testing)

### Installation
1. Clone the repository  
```bash
git clone <repo-url>
cd RecruitmentManagementSystem
```
# Resume Processing System

## Resume Processing
- Only **PDF** and **DOCX** formats are allowed.
- Uploaded resumes are sent to a **third-party API** for processing.
- Extracted information (**Name, Email, Skills, Experience**) is stored in the database.

## Folder Organization
- **Domain**: Core entities (`User`, `Resume`, `Job`, `Application`)  
- **Application**: Interfaces, services, DTOs, use-cases  
- **Infrastructure**: EF Core context, repository implementations  
- **API**: Controllers, DI configuration, middleware  

## Notes
- Passwords are **securely hashed**.  
- **Role-based authorization** implemented.  
- **Error handling** and validations included.  

## Future Improvements
- Add **unit and integration tests**.  
- Add **email notifications** for job applications.  
- Implement **resume search & filtering** for admins.  
- Implement **pagination** for job listings.  

## Contact
- Developed by: **Mohd Naved**  
- Email: **mohammadnaved1517@gmail.com**  
- GitHub: **https://github.com/naveddd3**
