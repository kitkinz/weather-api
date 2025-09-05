# 🌦️ Weather API
A simple C# .NET Web API that fetches and returns weather data from a third-party provider.  
Instead of maintaining our own dataset, this project integrates with external APIs (e.g., [Visual Crossing Weather API](https://www.visualcrossing.com/weather-api)).

[Project Task on Roadmap.sh](https://roadmap.sh/projects/weather-api-wrapper-service)

## 🚀 Features
- Fetch real-time weather data from a 3rd party API  
- Use in-memory caching (e.g., Redis) to reduce unnecessary API calls  
- Configurable API keys and settings via environment variables  
- Automatic cache expiration (e.g., 12 hours) for fresh results

## 🛠️ Tech Stack
- **.NET 6+** (ASP.NET Core Web API)  
- **Redis** (recommended for caching)  

## Installation
Follow these steps to run this application:
1. Clone this repository:
```
git clone https://github.com/kitkinz/expense-tracker.git
```
2. Navigate to the project directory:
```
cd ExpenseTracker
```
3. Restore dependencies:
```
dotnet restore
```
4. Build the project:
```
dotnet build
```
5. Run the app:
```
dotnet run
```

## Usage
### Example
```
to do
```