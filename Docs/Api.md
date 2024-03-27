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
    "password":"kevin1234!",
    "birth":"2002-06-10"
}
```

#### Register Response

```json
200 OK
```

```json
{
  "id": "cc3c4f01-000d-4e70-970b-8f9ad5a75393",
  "firstName": "kevin",
  "lastName": "manzano",
  "email": "kevin@gmail.com",
  "birth": "2002-06-10T00:00:00",
  "points": 0,
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJjYzNjNGYwMS0wMDBkLTRlNzAtOTcwYi04ZjlhZDVhNzUzOTMiLCJnaXZlbl9uYW1lIjoia2V2aW4iLCJmYW1pbHlfbmFtZSI6Im1hbnphbm8iLCJqdGkiOiI3NzMzMWQ5NC1jNWFkLTRkZmItODkxOS0wZDUyMGFkZjk5MjUiLCJleHAiOjE3MTAxMTc1MzMsImlzcyI6IkNpbmVtYXgiLCJhdWQiOiJDaW5lbWF4In0.tgwyAeQbBSg7AN_cpfZx8iPoDfyyMeV3CwwnoDlNMs4"
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
  "id": "cc3c4f01-000d-4e70-970b-8f9ad5a75393",
  "firstName": "kevin",
  "lastName": "manzano",
  "email": "kevin@gmail.com",
  "birth": "2002-06-10T00:00:00",
  "points": 0,
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJjYzNjNGYwMS0wMDBkLTRlNzAtOTcwYi04ZjlhZDVhNzUzOTMiLCJnaXZlbl9uYW1lIjoia2V2aW4iLCJmYW1pbHlfbmFtZSI6Im1hbnphbm8iLCJqdGkiOiJlODFiMDI4Mi1lMzk5LTRkOTYtOTAyYy0yNzk5YjhiMGRlZjEiLCJleHAiOjE3MTAxMTc1ODYsImlzcyI6IkNpbmVtYXgiLCJhdWQiOiJDaW5lbWF4In0.T-c8BFgti1ofdxWwswG_zQCD69Yc8bdMXRU3cx6s4N8"
}
```

## Movies

### Create

```js
POST {{host}}/movies
```

#### Create Request

```json
Authorization: Bearer {{token}}
{
    "name":"Lucy3",
    "description":"Best peli",
    "Duration":"02:30:00",
    "Premiere":"2024-04-01T00:00:00",
    "IconURL":"https://ejemplo.com/icon.png",
    "TrailerURL":"https://ejemplo.com/trailer.mp4"
}
```

#### Create Response

```json
200 OK
```

```json
{
  "id": "0b764348-2285-4f24-a42b-0fdec37e5997",
  "name": "Lucy5",
  "description": "Best peli",
  "duration": "02:30:00",
  "premiere": "2024-04-01T00:00:00",
  "iconURL": "https://ejemplo.com/icon.png",
  "trailerURL": "https://ejemplo.com/trailer.mp4"
}
```

### Read

```js
GET {{host}}/movies
```

#### Read Request

```json
{
}
```

#### Read Response

```json
200 OK
```

```json
[
  {
    "id": "983b0528-f9ce-411a-85a5-879593940247",
    "name": "Lucy",
    "description": "Best peli",
    "duration": "02:30:00",
    "premiere": "2024-04-01T00:00:00",
    "iconURL": "https://ejemplo.com/icon.png",
    "trailerURL": "https://ejemplo.com/trailer.mp4"
  },
  {
    "id": "1cfcfc2c-e77f-4fa9-b083-230a423acc17",
    "name": "Lucy2",
    "description": "Best peli",
    "duration": "02:30:00",
    "premiere": "2024-04-01T00:00:00",
    "iconURL": "https://ejemplo.com/icon.png",
    "trailerURL": "https://ejemplo.com/trailer.mp4"
  },
  {
    "id": "09ff618d-3b6c-4b70-9c6e-e5ede37ed037",
    "name": "Lucy3",
    "description": "Best peli",
    "duration": "02:30:00",
    "premiere": "2024-04-01T00:00:00",
    "iconURL": "https://ejemplo.com/icon.png",
    "trailerURL": "https://ejemplo.com/trailer.mp4"
  },
  {
    "id": "0b764348-2285-4f24-a42b-0fdec37e5997",
    "name": "Lucy5",
    "description": "Best peli",
    "duration": "02:30:00",
    "premiere": "2024-04-01T00:00:00",
    "iconURL": "https://ejemplo.com/icon.png",
    "trailerURL": "https://ejemplo.com/trailer.mp4"
  }
]
```
