# KYH_WebApi_EN-DE_Crypt

<!-- Step 1 Main -->

1. First Make Prodject Folder structure:
```powershell
mkdir DotNet_KYH_API
cd DotNet_KYH_API
mkdir WebApi_EN-DE_Crypt
```
As one command:
```powershell
mkdir DotNet_KYH_API/WebApi_EN-DE_Crypt
```

2. Create Github Page *KYH_WebApi_EN-DE_Crypt* + Readme + First commit:
```powershell
echo "# KYH_WebApi_EN-DE_Crypt" >> README.md
git init
git add README.md
git commit -m "first commit"
git branch -M main
git remote add origin https://github.com/WANTEDSIMON/KYH_WebApi_EN-DE_Crypt.git
git push -u origin main
```

<!-- Step 2 For dev.1 -->

1. Make Github Actions Folder path + changes.yml:
*"chnages" for ReaMe -File*
*"test" For Tesin every thing
*"dev" For to test befor allowing Merge to Main
*"main" For allowing contetnt to go to AWS
```powershell
New-Item -ItemType File -Path .github\workflows\changes.yml -Force
New-Item -ItemType File -Path .github\workflows\test.yml
New-Item -ItemType File -Path .github\workflows\dev.yml
New-Item -ItemType File -Path .github\workflows\main.yml
```

2. Opened the project in Visual Studio:
```sh
start devenv .
```
> [!NOTE]
> Opened the project in VS Code:```code .```

3. Set up the yaml file "changes".

```YML
name: 🔄 Changes Branch - CI Check

on:
  push:
    branches:
      - changes  # Matches exact "changes"
      - changes_*  # Matches any branch that starts with "changes_"
    paths:
      - "README.md"  # Only runs if README.md is modified
  pull_request:
    branches:
      - changes
      - changes_*  # Matches branches like "changes_1", "changes_2"
    paths:
      - "README.md"

jobs:
  check-readme:
    runs-on: ubuntu-latest

    steps:
    - name: 🛠️ Checkout repository
      uses: actions/checkout@v3

    - name: ✅ Validate Markdown (README.md)
      run: echo "Markdown validation would be done here"

```

4. Make Basic yml for first "dev" push/commit
```YML
name: 🛠️ Dev Branch - Build

on:
  push:
    branches:
      - dev
  pull_request:
    branches:
      - dev

jobs:
  build: 
    runs-on: ubuntu-latest
    
    steps:
      - name: 🛠️ Checkout repository
        uses: actions/checkout@v3
      
      - name: 🔧 Set up .NET 8
        uses: actions/setup-dotnet@v3
        with:
          dotnet-version: '8.0'

      - name: 📦 Restore dependencies
        run: dotnet restore

      - name: 🏗️ Build the project
        run: dotnet build --configuration Debug

```

5. Ok, now let get all Dev changes beffore we add, Readme..(changes)
*Make branch dev.1*
```
git checkout -b dev.1
```

6. Add All GitHub Actions Workflow Files
```
git add .github/workflows/changes.yml
git add .github/workflows/dev.yml
git add .github/workflows/main.yml
git add .github/workflows/test.yml
```

7. Add commit message:
```
git commit -m "🔄 Added GitHub Actions workflows for main, test, changes, and dev branches"
```

8. Push the dev.1 Branch to Github
```
git push origin dev.1
```

9. Merge and Delete branch

<!-- Step 3 For changes.1 -->

1. Now add changes branch to add ReadMe update
*Make branch changes.1*
```
git checkout -b changes.1
```

2. Add README.md file
```
git add README.md
```

3. Add commit message:
```
git commit -m "🔄 Updated README.md"
```

4. Push the changes.1 Branch to Github
```
git push origin changes.1
```

5. Merge and Delete branch

<!-- Step 4 Extra - Fix YML -->

1. Realized I named the branch wrong, so I need to fix the yml file.
To contain more variations of the branch name changes.

2. So add this to YML file changes (To both sets of "branches:"):
```YML
      - Changes
      - changes
      - Changes_*
      - changes_*
      - Changes.*
      - changes.*
```

3. Make new dev.2 branch
```
git checkout -b dev.2
```

4. Add, commit and push the changes to Github
```
git add .github/workflows/changes.yml
git commit -m "🔄 Fixed branch name in changes.yml"
git push origin dev.2
```

5. Merge and Delete branch

<!-- Step 4 For Test ^ changes made in Step 4 Extra -->

1. Make branch changes.2
```
git checkout -b changes.2
```

2. Add README.md file
```
git add README.md
```

3. Add commit message:
```
git commit -m "🔄 Updated README.md"
```

4. Push the changes.2 Branch to Github
```
git push origin changes.2
```

5. Merge and Delete branch


<!-- Step 5 Extra  Realice wrong file structure -->

1. Move the .github folder to the root of the project
```powershell
mv .github WebApi_EN-DE_Crypt/
```

2. Move .git to root of the project
```
mv .git WebApi_EN-DE_Crypt/
```

3. Move README.md to root of the project
```
mv README.md WebApi_EN-DE_Crypt/
```
