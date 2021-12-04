# TheDialgaTeam.Core.Logger
## About this library
This library provides extensions for Serilog and LoggerTemplate.

## Installation
1. Setup nuget to download from github packages.

   * via dotnet cli (persistent)

       ```Shell
       dotnet nuget add source -n "github/TheDialgaTeam" -u <github_username> -p <github_token> --store-password-in-clear-text https://nuget.pkg.github.com/TheDialgaTeam/index.json
       ```

   * via nuget.config (per project)

       Create nuget.config and insert this into the solution.

       ```xml
       <?xml version="1.0" encoding="utf-8"?>
       <configuration>
           <packageSources>
               <add key="github" value="https://nuget.pkg.github.com/TheDialgaTeam/index.json" />
           </packageSources>
           <packageSourceCredentials>
               <github>
                   <add key="Username" value="<github_username>" />
                   <add key="ClearTextPassword" value="<github_token>" />
               </github>
           </packageSourceCredentials>
       </configuration>
       ```
2. Install package
   
    Install from the command line:
    
    ```Shell
    dotnet add package TheDialgaTeam.Core.Logger --version 1.1.0
    ```
