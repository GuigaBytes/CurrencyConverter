# Currency Converter CLI

## Overview
This Currency Converter is a simple Command Line Interface (CLI) application that uses the ExchangeRate-API to convert amounts from one currency to another. It's built with C# and is intended for users who prefer quick, command-line interactions.

## Features
- Convert amounts between different currencies.
- Uses the ExchangeRate-API for up-to-date currency conversion rates.
- Simple and easy-to-use CLI.

## Getting Started

### Prerequisites
- .NET SDK
- An API key from ExchangeRate-API

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/GuigaBytes/CurrencyConverter.git
   ```
2. Navigate to the project directory:
   ```bash
   cd CurrencyConverter/CurrencyConverter
   ```
3. Copy the file named 'appsettings.json.example' in the project directory:
   ```bash
   cp appsettings.json.example appsettings.json
   ```
4. Open 'appsettings.json' and insert your API key from ExchangeRate-API.
5. Build the project:
   ```bash
   dotnet build
   ```

### Usage
Run the application with the following command format:
```bash
dotnet run <amount> <from> <to>
```
Or
```bash
dotnet run <from> <to>
```

### Example:
```bash
dotnet run 100 USD EUR
```
Or:
```bash
dotnet run USD EUR
```

### Testing
```bash
dotnet test
```
