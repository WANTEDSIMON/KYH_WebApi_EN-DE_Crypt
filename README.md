# ASP.NET Core Web API for Base64 Encoding & Decoding

## Overview

This project is a minimal ASP.NET Core Web API that provides Base64 encoding and decoding services for text data. It allows users to encode plain text into Base64 format and decode Base64-encoded strings back to their original text representation. This API is designed for seamless text transformation, making it useful for data encoding in web applications, secure text transmission, and handling text-based data conversion.

---

## Table of Contents
- [Installation and Running Locally](#installation-and-running-locally)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Configuration](#configuration)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Installation and Running Locally

### Prerequisites
- .NET SDK (Download: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download))
- Git (Download: [https://git-scm.com/](https://git-scm.com/))
- Code Editor (VS Code or Visual Studio)

--- 

### Steps to Set Up the Project Locally

#### 1. **Create a New Project Locally**:
```sh
mkdir dotnet_WebApi
cd dotnet_WebApi
```

1. First, make a directory to work in,
2. Go to the folder we just created,

#### 2. **Set Up a Project Workspace**:
```sh
mkdir WebApi_EN-DE_Crypt
cd WebApi_EN-DE_Crypt
```
3. Create a folder to work in
4. Go to the new folder we just created
   
#### 3.**Enter code editor**;
6. Opened the project in Visual Studio:
```sh
start devenv .
```
> [!NOTE]
> Opened the project in VS Code:```code .```

#### 4.**Generate necessary Files**;
7. Generated a .gitignore file,
8. Added README.md file,
```sh
dotnet new gitignore
echo "# Web_Api_AES_ENDE_Crypt" >> README.md
```
The .gitignore file;
This was done to ensure that certain files and folders, such as `bin/` and `obj/` directories, are not added to version control. These folders contain build artifacts and temporary files that do not need to be tracked in Git.

The README;
README file for documentation of the project, to provide essential information on setup, usage, and contribution guidelines. 


#### 5. **Adding a Controller-Based Web API to the Project**
9. Create a ASP.NET Core Web API
```bash
dotnet new web
```
#### 6. **Run Program**
10. Run the code with:
```bash
dotnet run
```

#### 7. Add images folder + image to the project.
11. Making the folder commadn:
```bash
mkdir images_readme
```
img(dotnet run):

![New Endpoint](images_readme/img_dotnet-run.png)

img(first run):

![New Endpoint](images_readme/img_Hello_World.png)

#### 8. Created a new repository on GitHub:

- Go to GitHub and click on **New Repository**.
- Name the repository `KYH_WebApi_EN-DE_Crypt`.
- Do not add a **.gitignore** or **license** since they already exist locally.

--- 

--- 

The code Program.cs:
```
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
```
1. Initializes a web application
```var builder = WebApplication.CreateBuilder(args);```
Creates a WebApplicationBuilder with preconfigured defaults.
Sets up the necessary services for running the app

2. Builds the application instance
```var app = builder.Build();```
Compiles and prepares the web application to handle requests.

3. Defines a basic HTTP GET endpoint
```app.MapGet("/", () => "Hello World!");```
Creates an endpoint at / (root URL).
When accessed, it returns "Hello World!" as a response.

4. Starts the application
```app.Run();```
Runs the web server and begins listening for incoming HTTP requests.

---

---

<!-- Step 2 -->

1. Initialized a new Git repository:

```bash
git init
```

2. Staged all files for the initial commit:

```bash
git add .
```

3. Created the first commit with the `README.md` file:

```bash
git commit -m "first commit"
```

4. Renamed the default branch to `main`:

```bash
git branch -M main
```

5. Added the remote repository:

```bash
git remote add origin https://github.com/WANTEDSIMON/KYH_WebApi_EN-DE_Crypt.git
```

6. Pushed the code to GitHub:

```bash
git push -u origin main
```
---

<!-- Extra 1 -->

1. Made changes to the `README.md` file.


2. Created a new branch for small changes:
```bash
git checkout -b change.1
```

3. Git - add the changes:
```bash
git add .
```

4. Write commit message:
```bash
git commit -m "Updated README.md"
```

5. Push the changes to the remote repository:
```bash
git push origin change.1
```

6. Created a pull request on GitHub to merge the changes into the `main` branch.

---

<!-- Step 3 -->

1. Create new branch for small code update in the `Program.cs` file:
```bash
git checkout -b dev.1
```
2. Made changes to the `Program.cs` file.

2. Updated the default endpoint "app.MapGet("/", () => "Hello World!");" to "app.MapGet("/", () => "Hello Earth 🌎!");".
```bash
app.MapGet("/", () => "Hello Earth 🌎!");
```

3. Staged the file for the initial commit, used command:
```bash
git add Program.cs
```

4. Create commit message with the changes made:
```bash
git commit -m "Updated default endpoint"
```

5. Pushed the code to GitHub:
```bash
git push origin dev.1
```

image running the code:
![New Endpoint](images_readme/HelloEarth_img.png)

6. Created a pull request on GitHub to merge the changes into the `main` branch.

7. Merge the changes into the `main` branch via a pull request on GitHub.

---

<!-- Step 4 -->

1. Created a new branch for adding a new endpoint to the API:
```bash
git checkout -b dev.2
```

2. Add the new enpoint mapping to Program.cs.
```csharp
app.MapGet("/key", () => KeyGenerator.GenerateRandomKey());
```

3. Add file KeyGenerator.cs to the project.
```cmd
type NUL > KeyGenerator.cs
```

4. Added the following code to the KeyGenerator.cs file:
```csharp
using System;
using System.Security.Cryptography;
using System.Text;


namespace Key
{
    public class KeyGenerator
    {
        private const int KeyLength = 32; // AES-256 Key length

        public static string GenerateRandomKey()
        {
            byte[] key = new byte[KeyLength];
            RandomNumberGenerator.Fill(key);
            return Convert.ToBase64String(key);
        }
    }
}
```

5. Updare program.cs to include the KeyGenerator namespace:
```csharp
using System;
using Key;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello Earth 🌎!");

app.MapGet("/key", () => KeyGenerator.GenerateRandomKey());

app.Run();
```

6. Staged the files for the initial commit:
```bash
git add Program.cs
git add KeyGenerator.cs
```

7. Created a commit message with the changes made:
```bash
git commit -m "Added new endpoint for generating random key"
```

8. Pushed the code to GitHub:
```bash
git push origin dev.2
```

9. Created a pull request on GitHub to merge the changes into the `main` branch.

10. Merged the changes into the `main` branch via a pull request on GitHub.

<!-- Step 5 -->

1. Created a new branch for adding a new endpoint to the API:
```bash
git checkout -b dev.3
```

2. Add new c# file PasswordGenerator.cs to the project.
```cmd
type NUL > PasswordGenerator.cs
```

3. Added the following code to the PasswordGenerator.cs file:
```csharp
using System.Security.Cryptography;

public static class PasswordGenerator
{
    private const int DefaultPasswordLength = 12; // Default password length

    public static string GenerateSecurePassword(int length)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+-=[]{}|;:,.<>?";
        char[] password = new char[length];

        using var rng = RandomNumberGenerator.Create();
        byte[] randomBytes = new byte[length];
        rng.GetBytes(randomBytes);

        for (int i = 0; i < length; i++)
        {
            password[i] = chars[randomBytes[i] % chars.Length];
        }

        return new string(password);
    }

    public static int GetPasswordLength(HttpContext context)
    {
        int length = DefaultPasswordLength;
        if (context.Request.Query.TryGetValue("length", out var lengthValue) && int.TryParse(lengthValue, out int customLength))
        {
            length = customLength;
        }
        return length;
    }
}
```

4. Add the new enpoint mapping to Program.cs.
```csharp
app.MapGet("/password", (HttpContext context) =>
{
    int length = PasswordGenerator.GetPasswordLength(context);
    return Results.Text($"Generated Password: {PasswordGenerator.GenerateSecurePassword(length)}");
});
```

5. Add files to the staging area:
```bash
git add Program.cs
git add PasswordGenerator.cs
```

6. Create a commit message with the changes made:
```bash
git commit -m "Added new endpoint for generating password"
```

7. Push the code to GitHub:
```bash
git push origin dev.3
```

img running the code:
![New Endpoint](images_readme/password_img.png)

8. Create a pull request on GitHub to merge the changes into the `main` branch.
9. Merge the changes into the `main` branch via a pull request on GitHub.

---

<!-- Extra 2 -->

First add namspace Password in PasswordGenerator.cs
Tried to add namespace to the Password, to program.cs.

PasswordGenerator.cs line-3, 4, 36:
```csharp
namespace Password
{
}
```

Program.cs line-3:
```csharp
using Password;
```

Created a new branch for the changes:
```bash
git checkout -b change.2
```

Staged the files remaining:
```bash
git add .
```

Create a commit message with the changes made:
```bash
git commit -m "Added remaining files"
```

Push the code to GitHub:
```bash
git push origin change.2
```

---

<!-- Step 5 -->

1. Created a new branch for adding a new endpoint to the API:
```bash
git checkout -b dev.4
```

2. Add new enpoint mapping to Program.cs.
```csharp
using System.Text;
using Microsoft.Extensions.Primitives;

app.MapGet("/encode", (HttpContext context) =>
{
    if (!context.Request.Query.TryGetValue("text", out StringValues text) || text.Count == 0 ||
        !context.Request.Query.TryGetValue("key", out StringValues key) || key.Count == 0)
    {
        return Results.BadRequest("Error: Missing 'text' or 'key' parameter. Example: /encode?text=HelloWorld&key=MyKey");
    }

    string encodedText = Convert.ToBase64String(Encoding.UTF8.GetBytes(key.ToString() + text.ToString()));
    return Results.Text($"Encoded: {encodedText}");
});
```
Runnig the code for enpoint "password":
Using the "Text" I get for password enpoint in /encode enpoint.

3. Add files to the staging area:
```bash
git add Program.cs
```

4. Create a commit message with the changes made:
```bash
git commit -m "Added new endpoint for encoding text"
```

5. Push the code to GitHub:
```bash
git push origin dev.4
```

6. Create a pull request on GitHub to merge the changes into the `main` branch.
7. Merge the changes into the `main` branch via a pull request on GitHub.

img of first run:
![New Endpoint](images_readme/encode_img.png)


---

<!-- Step 6 -->

1. Created a new branch for adding the last endpoint to the API:
```bash
git checkout -b dev.5
```

2. Add the new enpoint mapping to Program.cs.
```csharp
app.MapGet("/decode", (HttpContext context) =>
{
    if (!context.Request.Query.TryGetValue("text", out StringValues encodedText) || encodedText.Count == 0 ||
        !context.Request.Query.TryGetValue("key", out StringValues key) || key.Count == 0)
    {
        return Results.BadRequest("Error: Missing 'text' or 'key' parameter. Example: /decode?text=U2VjcmV0S2V5SGVsbG8gd29ybGQ=&key=SecretKey");
    }

    try
    {
        byte[] decodedBytes = Convert.FromBase64String(encodedText.ToString());
        string decodedText = Encoding.UTF8.GetString(decodedBytes);

        if (decodedText.StartsWith(key.ToString()))
        {
            return Results.Text($"Decoded: {decodedText.Substring(key.ToString().Length)}");
        }

        return Results.BadRequest("Error: Key does not match.");
    }
    catch (FormatException)
    {
        return Results.BadRequest("Error: Invalid Base64 string.");
    }
});
```

img of first run:
![New Endpoint](images_readme/decode_img.png)

3. Add files to the staging area:
```bash
git add Program.cs
```

4. Create a commit message with the changes made:
```bash
git commit -m "Added new endpoint for decoding text"
```

5. Push the code to GitHub:
```bash
git push origin dev.5
```

6. Create a pull request on GitHub to merge the changes into the `main` branch.
7. Merge the changes into the `main` branch via a pull request on GitHub.

---

<!-- Extra 3 -->

1. Created a new branch for adding documentation to the project:
```bash
git checkout -b change.3
```

2. Add document changes to the project.
```bash
git add .
```

3. Create a commit message with the changes made:
```bash
git commit -m "Added documentation" 
```

4. Push the code to GitHub:
```bash
git push origin change.3
```

5. Create a pull request on GitHub to merge the changes into the `main` branch.
6. Merge the changes into the `main` branch via a pull request on GitHub.

---

step 7:

---

step 8:

1. Make GitHub acton for the project.

2. Created the GitHub Actions folder structure:
```bash
mkdir -p .github/workflows
```

3. Created a new workflow files:
```powershell
New-Item -ItemType File -Path .github\workflows\main.yml
```
```
New-Item -ItemType File -Path .github\workflows\test.yml
```
```
New-Item -ItemType File -Path .github\workflows\dev.yml
```

4. Added the following code to the `test.yml` file:
```yaml
name: Build and test in Docker

on:
  push:
    branches:
      - main

jobs:
  build_and_test:
    runs-on: ubuntu-latest

    steps:
      - name: Checkout code
        uses: actions/checkout@v3

      - name: Set up Docker Buildx
        uses: docker/setup-buildx-action@v2

      - name: Log in to Docker Hub
        uses: docker/login-action@v2
        with:
          username: ${{ secrets.DOCKER_USERNAME }}
          password: ${{ secrets.DOCKER_PASSWORD }}

      - name: Build Docker image
        uses: docker/build-push-action@v4
        with:
          context: .
          push: false
          tags: Web_Api_AES_ENDE_Crypt:latest

      - name: Run tests in Docker container
        run: |
          docker run --rm Web_Api_AES_ENDE_Crypt:latest dotnet test
```

6. Added the following code to the `dev.yml` file:
```yaml
name: DEV

on:
  workflow_run:
    workflows: ["Build and test in Docker"]
    types:
      - completed

jobs:
  build:
    if: ${{ github.event.workflow_run.conclusion == 'success' }}
    runs-on: ubuntu-latest

    steps:
      - name: Checkout code
        uses: actions/checkout@v3

      - name: setup dotnet
        uses: actions/setup-dotnet@v3
        with:
          dotnet-version: '9.x'

      - name: Build Project
        run: dotnet restore; dotnet publish -o site;

      - name: create zip file
        run: cd site; zip ../site.zip *;
```

7. Added the following code to the `main.yml` file:
```yaml
Added the following code to the `main.yml` file:
```yaml
name: Build and push to AWS

on:
  workflow_run:
    workflows: ["Build and test in Docker"]
    types:
      - completed

jobs:
  build:
    if: ${{ github.event.workflow_run.conclusion == 'success' }}
    runs-on: ubuntu-latest

    steps:
      - name: Checkout code
        uses: actions/checkout@v3

      - name: setup dotnet
        uses: actions/setup-dotnet@v3
        with:
          dotnet-version: '9.x'

      - name: Build Project
        run: dotnet restore; dotnet publish -o site;

      - name: create zip file
        run: cd site; zip ../site.zip *;

      - name: Deploy to AWS Elastic Beanstalk
        uses: einaregilsson/beanstalk-deploy@v21
        with:
          aws_access_key: ${{ secrets.AWS_ACCESS_KEY_ID }}
          aws_secret_key: ${{ secrets.AWS_SECRET_ACCESS_KEY }}
          region: us-east-1
          application_name: Calculator-Api
          environment_name: Calculator-Api-env
          version_label: ${{ github.run_id }}
          deployment_package: site.zip
```

---

<!-- Extra 3 dev -->

Working with the GitHub Actions files.

1. Created a new branch;
```bash
 git checkout -b dev.6
```

2. Adding the folowing files to the staging area;
*.github/*
*.github/workflows*
*Tests.cs*
*.github/workflows/test.yml*
*.github/workflows/dev.yml*
*.github/workflows/main.yml*

3. Realisnig the yml file "test.yml" need changing;
```bash
on:
  push:
    branches: 
    - '*Test*'
  pull_request:
    branches:
    - '*Test*'
```

5. Create a commit message with the changes made:
```bash
git git commit -m "Adding Test + CI/CD steps"
```

6. Push the code to GitHub:
```bash
git push origin dev.6
```

---

Were problems with dev.6

1. Created a new branch;
```bash
 git checkout -b dev.7
```

2. Adding the folowing files to the staging area;
*WebApi_EN-DE_Crypt.csproj*

3. with the following code:
	<ItemGroup>
		<PackageReference Include="Moq" Version="4.16.1" />
		<PackageReference Include="xunit" Version="2.4.2" />
		<PackageReference Include="xunit.runner.visualstudio" Version="2.4.3" />
		<PackageReference Include="Microsoft.AspNetCore.Mvc.Testing" Version="2.2.0" />
		<PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.12.0" />
	</ItemGroup>

step 9:

Set up AWS

