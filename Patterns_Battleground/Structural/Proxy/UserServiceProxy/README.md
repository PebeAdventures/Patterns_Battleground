# 🛡️ AuthorizedUserServiceProxy (Proxy Pattern Example)

## 📘 Overview

This project demonstrates the **Proxy design pattern** using a user system, where we add an authorization layer to an existing service (`RealUserService`) without modifying its implementation.

---

## 🎯 Purpose of the Proxy Pattern

The **Proxy** acts as an intermediary that:
- implements the same interface as the real service (`IUserService`),
- controls access to `RealUserService` (e.g., by validating a token),
- can log, delay, block, or modify requests.

---

## 🧩 Structure

```csharp
// Interface
public interface IUserService
{
    UserProfile GetProfile(string userId, string token);
}

// Real service (simulated)
public class RealUserService : IUserService { ... }

// Proxy with authorization
public class AuthorizedUserServiceProxy : IUserService { ... }
```

---

## 🔍 How it works

1. The client calls `proxy.GetProfile("userId", token)`.
2. `AuthorizedUserServiceProxy` validates the token (e.g., only `"12345"` is valid).
3. If the token is valid – it delegates the request to `RealUserService`.
4. If the token is invalid – it throws an `UnauthorizedAccessException`.

---

## 🧪 Tests

- ✅ `GetProfile_WhenTokenIsValid_ShouldReturnExpectedUserProfile`
- ❌ `GetProfile_WhenTokenIsInvalid_ShouldThrowUnauthorizedAccessException`

These tests verify that:
- the proxy properly delegates to the real service when access is allowed,
- it blocks the call when the token is invalid.

---

## 💡 Educational Insight

The **Proxy** pattern enables you to **inject technical logic (like authorization)** without changing existing domain code. This is a common approach for access control, logging, lazy loading, or caching.

---

## 📁 Folder Structure

- `Core/` – interfaces and the `UserProfile` model
- `Services/` – contains `RealUserService`
- `Proxy/` – contains `AuthorizedUserServiceProxy`
- `Tests/` – XUnit tests

---

## ✅ Purpose

This project is part of the **Pattern Battlegrounds** collection – a hands-on guide to design patterns in C#.
