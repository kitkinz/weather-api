# 🌦️ Weather API
A simple C# .NET Web API that fetches and returns weather data from a third-party provider.

[Project Task on Roadmap.sh](https://roadmap.sh/projects/weather-api-wrapper-service)

## 🚀 Features
- Fetch real-time weather data from a 3rd party API [Visual Crossing Weather API](https://www.visualcrossing.com/weather-api)
- Use in-memory caching (e.g., Redis) to reduce unnecessary API calls  
- Configurable API keys and settings via environment variables  
- Automatic cache expiration (e.g., 1 hour) for fresh results

## 🛠️ Tech Stack
- **.NET 6+** (ASP.NET Core)  
- **Redis** (In-memory caching service)
- [**Docker**](https://docs.docker.com/) (Container for Redis)  

## Installation
Follow these steps to run this application:
1. Clone this repository:
```
git clone https://github.com/kitkinz/weather-api.git
```
2. Navigate to the project directory:
```
cd WeatherApi
```
3. Create and run a Redis server in the background:
```
docker run -d --name redis -p 6379:6379 redis
```
- Stop the Redis container: `docker stop redis`
- Start the Redis container: `docker start redis`
4. Restore dependencies:
```
dotnet restore
```
5. Build the project:
```
dotnet build
```
6. Run the app:
```
dotnet run
```

## Usage
Endpoint: `localhost:{port}/{city}`
<br />
You can use Postman to test the rate limiter for API requests but
make sure to comment out the checking of cached results in WeatherService.cs.