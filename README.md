# Banking Operations AI Assistant

A console-based AI assistant built with **C# and .NET** that uses **Groq's OpenAI-compatible API** and **Microsoft.Extensions.AI** to retrieve banking information through function calling.

## Features

* Groq API integration using the OpenAI .NET SDK
* Chat history for conversational context
* Streaming responses using `GetStreamingResponseAsync`
* Function calling with `AIFunctionFactory`
* Automatic tool invocation using `UseFunctionInvocation()`
* Banking operations for customer and account lookup

## Technologies

* C#
* .NET
* Microsoft.Extensions.AI
* OpenAI .NET SDK
* Groq API
* GPT-OSS 20B

## Available Tools

| Function           | Description                   |
| ------------------ | ----------------------------- |
| `GetCustomerById`  | Retrieves customer details    |
| `GetAccountBalance` | Retrieves account balance     |
| `FindAccountOwner` | Finds the owner of an account |

## How It Works

```text
User Query
    ↓
AI Model
    ↓
Tool Invocation (if required)
    ↓
BankingServices
    ↓
Tool Result
    ↓
AI Response
    ↓
Streaming + Chat History
```

## Setup

### 1. Clone the repository

```bash
git clone https://github.com/your-username/BankingOperationAIAssistant.git
cd BankingOperationAIAssistant
```

### 2. Configure your Groq API key

**Windows PowerShell:**

```powershell
$env:GROQ_API_KEY="your_groq_api_key"
```

**Linux / macOS:**

```bash
export GROQ_API_KEY="your_groq_api_key"
```

### 3. Run the project

```bash
dotnet restore
dotnet run
```

## Example

```text
You : What is the balance of account 1001?

AI : The current balance of account 1001 is ₹25,000.

You : Who owns account 1001?

AI : The account is owned by [Customer Name].
```

## Purpose

This project was created to practice **AI integration with .NET**, including chat history, streaming responses, and function calling, as part of my journey toward building a **Finacle-like banking system with AI capabilities**.

## Future Improvements

* Database integration
* More banking operations
* Authentication and authorization
* Transaction and ledger support
* Integration with ASP.NET Core



⭐ If you find this project useful, consider giving it a star!
