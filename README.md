# Paperless currency converter

Paperless currency converter is an app that can convert currency(show rates by date-year and month).

## Installation

Build the app and run the Paperless.Main project.

## Usage

### The code-

The app is build with 3 project in the solution:
1. Paperless.Core - The Business logic of the project (class project)
  a. Model - all the objects model in the app
  b. Services - Interfaces and implementations - Singelton httpclient + currency call and all the logic.
  c. I'm using the free currency exchange rate API - "https://currencies.apps.grandtrunk.net"
3. Paperless.Main - The Main project (console app Azure Function App)
  a. Function1.cs - this is the end point of the app, it calls the service by DI and getting the currencies converter data
5. Paperless.test - The Unitest project.

## License

[MIT](https://choosealicense.com/licenses/mit/)
