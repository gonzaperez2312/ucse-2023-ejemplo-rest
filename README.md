# Documentación API

## Get users
```
curl --location 'http://localhost:5133/usuarios'
```

## Get user by id
```
curl --location 'http://localhost:5133/usuarios/20'
```

## Post user
```
curl --location 'http://localhost:5133/usuarios' \
--header 'Content-Type: application/json' \
--data-raw '{
  "Nombre": "Gonza",
  "Apellido": "Lovera",
  "CorreoElectronico": "gonza@example.com"
}'
```

## Put user
```
curl --location --request PUT 'http://localhost:5133/usuarios/3' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Id": "3",
    "Nombre": "Gonzalo",
    "Apellido": "Perez",
    "CorreoElectronico": "gonza@example.com"
}'
```

## Delete user
```
curl --location --request DELETE 'http://localhost:5133/usuarios/3' \
--data ''
```
