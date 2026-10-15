# C# Weather API Console App

A .NET console application that retrieves current weather data from the Open-Meteo public API and converts the JSON response into a readable weather report.

## What It Does

The application asks the user for a city name, latitude, and longitude, then requests current weather conditions from Open-Meteo. It displays:

- weather condition
- temperature in Celsius and Fahrenheit
- apparent temperature / feels-like temperature
- relative humidity
- wind speed in km/h and mph

## Technical Concepts

- C# / .NET
- asynchronous programming with `async` / `await`
- `HttpClient` for REST API requests
- JSON deserialization with `System.Text.Json`
- custom response classes
- input handling and unit conversion
- conditional logic for weather-code interpretation

## API

The project uses the Open-Meteo forecast API and requests current temperature, apparent temperature, humidity, wind speed, and weather-code fields.

## Example Workflow

```text
User enters location
        ↓
Build Open-Meteo API request
        ↓
Send asynchronous HTTP request
        ↓
Deserialize JSON response
        ↓
Convert units and interpret weather code
        ↓
Display formatted weather report
```

## Run the Project

Open the solution in Visual Studio and run the console application, or use the .NET CLI from the project directory.

```bash
dotnet run
```

## Skills Demonstrated

`C#` · `.NET` · `REST APIs` · `HttpClient` · `JSON` · `Async/Await` · `Object-Oriented Programming`

## Project Note

This project was originally developed as a programming course assignment and is retained as a demonstration of working with public APIs and JSON data in C#.
