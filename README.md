# 🧪 ASP.NET Web API – Controller CRUD Unit Testing

This project was created as a learning playground for practicing **Unit Testing in ASP.NET Web API Controllers**.  
The API provides a minimal **User management service** with basic **CRUD operations (Create, Read, Update, Delete)**.

## 🎯 Project goals

- Build a functional ASP.NET **Web API** for a `User` entity
- Implement clean **CRUD logic inside a Controller**
- Practice **controller-level unit testing**
- Mock dependencies using **FakeItEasy**
- Write tests using **xUnit**
- Validate controller responses using **FluentAssertions**
- Verify correct service/repository interactions

## ✅ Unit tests cover

- `GET` all users
- `GET` user by ID
- `POST` create a new user
- `PUT` update an existing user
- `DELETE` remove a user
- HTTP status code validation (`Ok`, `NotFound`, `Created`, `NoContent`, etc.)
- FakeItEasy mock behavior and interaction assertions

## 🛠 Tech stack & NuGet packages
- ASP.NET Web API
- C#
- xUnit
- FakeItEasy
- FluentAssertions

## 🔍 Notes

- No real database is required – all dependencies are faked/mocked
- Focus is on learning unit testing, faking behavior, and validating API controller responses

---

This project is for **educational purposes** and demonstrates how to properly unit test ASP.NET Web API controllers using fakes and expressive assertions.
