# Cinemax API

- [Cinemax API](#cinemax-api)
  - [Auth](#auth)
        - [Register](#register)
            - [Register Request](#register-request)
            - [Register Response](#register-response)
        - [Login](#login)
            - [Login Request](#login-request)
            - [Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "firstName":"KEVIN",
    "lastName":"MANZANO",
    "email":"kevin@gmail.com",
    "password":"kevin1234!"
}
```

#### Register Response

```json
200 OK
```

```json
{
    "id":"d8184304-33-24u9...",
    "firstName":"KEVIN",
    "lastName":"MANZANO",
    "email":"kevin@gmail.com",
    "token":"eruh..ifdsihg"
}
```

### Login

```js
POST {{host}}/auth/login 
```

#### Login Request

```json
{
    "email":"kevin@gmail.com",
    "password":"kevin1234!"
}
```

#### Login Response

```json
200 OK
```

```json
{
    "id":"d8184304-33-24u9...",
    "firstName":"KEVIN",
    "lastName":"MANZANO",
    "email":"kevin@gmail.com",
    "password":"kevin1234!",
    "token":"eruh..ifdsihg"
}
```
