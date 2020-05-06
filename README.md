- Unit Testing
To reference a project to your unit testing you can do this by point the fule in visual studios or by unig the CLI:

For instance, for adding GradeBook to the unit test GradeBook.Test, using the cmd line we need to use

    ```
    $ dotnet add reference ..\..\src\GradeBook\GradeBook.csproj
    
    ```

### Creating a Solution File
In the gradebook folder using the cmd:
```
    PS C: dotnet new sln
    PS C: dotnet sln add src\GradeBook\GradeBook.csproj
    PS C: dotnet sln add test\GradeBook.Tests\GradeBook.Tests.csproj

```
A solution is a structure for organizing projects in Visual Studio. The solution maintains the state information for projects in two files: . sln file (text-based, shared)