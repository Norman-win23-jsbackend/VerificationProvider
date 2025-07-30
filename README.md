# ✅ VerificationProvider

**VerificationProvider** is a microservice built with **.NET 8** and **Azure Functions**, designed for handling verification workflows.  
It supports operations like sending verification codes, validating tokens, and managing verification status across various systems.

---

## 🚀 Features

- 🔐 Generate and validate verification codes  
- 📤 Integrate with SMS, email, or third-party providers  
- ⚙️ Serverless architecture using **Azure Functions**  
- 🧱 Modular and lightweight, suitable for microservice environments  
- 📦 Can be used for onboarding, login, email verification, or 2FA

---

## 📁 Project Structure

```

VerificationProvider/
├── Program.cs                 # Entry point for the app
├── host.json                 # Azure Functions runtime config
├── local.settings.json       # Dev-only settings (excluded from repo)
├── VerificationProvider.csproj # .NET project configuration
└── Functions/                # Azure Functions for verification logic

````

---

## 🛠️ Getting Started

### 1. Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)  
- [Azure Functions Core Tools](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local)

### 2. Setup & Run

```bash
git clone https://github.com/Norman-Deen/VerificationProvider.git
cd VerificationProvider
func start
````

Local endpoint:

```
http://localhost:7071
```

---

## ☁️ Azure Integration

* Works with Azure Functions & Event Grid
* Can pull secrets from Azure Key Vault
* Designed to be consumed by other providers (e.g., Email, User, Account)

---

## 🔐 Security Notes

* Store secrets securely in Azure or environment variables
* Never commit `local.settings.json`
* Use encryption and token expiry validation in production

---

## 📄 License

Provided for learning and modular service implementation.
Licensed under [MIT License](LICENSE).

---

**Nour Tinawi**

[LinkedIn](https://www.linkedin.com/in/nour-tinawi) • [Portfolio](https://www.pure-art.co) • [GitHub](https://github.com/Norman-Deen)
