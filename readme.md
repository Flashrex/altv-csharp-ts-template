# Alt:V C# Server and TypeScript Client Template

This project serves as a template for creating gamemodes using [Alt:V](https://altv.mp/). It is structured to use C# on the server-side and TypeScript on the client-side.
Is is setup to use [Entity Framework](https://learn.microsoft.com/en-us/ef/core/) as a easy to use ORM.

## Project Structure

The project is divided into two main parts:

1. **Server-side**: The server-side code is written in C#.
2. **Client-side**: The client-side code is written in TypeScript.

## Getting Started

To get started with this template, follow these steps:

1. Clone the repository to your local machine.
2. Navigate to the project directory.
3. Open client-Folder using your favorite editor (like VsCode) and install dependencies `npm install`
4. Open server/altv-csharp-ts-template.sln and update NuGet-Packages.
5. Open server/appsettings.json and update connection string with your database credentials
6. In your Dot-Net-Project rightclick on project > properties > Debug > General > "Open debug launch profiles UI"
7. Update Executable Path (Path to altv-server.exe) and Working Directory (Path to altv-server directory)
8. Run project and have fun

It is recommended to put a updated altv-server.exe in /altv-server directory and run your server from there.

## Developing

To edit client files run `npm run dev` in your client/ directory.
Then you can simply edit or add .ts files and they get automatically compiled and put at the correct place on save.

## License

This project is licensed under the MIT License. See the LICENSE file for more details.
