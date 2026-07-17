# Delivery Service

Веб-приложение для оформления и просмотра заказов доставки.

---
## Требования

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Git](https://git-scm.com/) 

---
##  Установка и запуск

### 1. Проверьте версию .NET

```bash
dotnet --version
Должно быть: `9.0.xxx`
```

## 2. Клонирование репозитория

```bash
git clone <url-репозитория>
cd DeliveryService
```

### 3. Восстановление зависимостей

```bash
dotnet restore
```

### 4. Применение миграций базы данных

```bash
dotnet ef database update
```

### 5. Запуск приложения

```bash
dotnet run
```

### 6. Открытие в браузере

Приложение будет доступно по адресу:

```
http://localhost:5000
```