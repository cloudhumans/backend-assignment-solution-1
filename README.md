# CloudHumans Assignment

### Useful Commands

- Running the application (from the project root)
```sh
docker build -t cloudhumans-assignment .
docker run -p 8080:80 cloudhumans-assignment
```

Access it on http://localhost:8080 (you will see swagger's home page)

- Running the unit tests

```sh
docker build --target build-env -t cloudhumans-assignment .
```
