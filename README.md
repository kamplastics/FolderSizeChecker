# Folder Size Checker

The Folder Size Checker is a utility that periodically checks the size of a specified folder, including its subdirectories, and logs the size to the console. The program can be configured to check the folder size at a custom interval.

You can use a basic csc command line compilier to create the exe. 

## 📖 Description

Once executed, the program will check the size of the given folder (including all its files and subdirectories) at the specified interval. The default interval is 5 seconds, but it can be modified using command-line arguments. For each check, the program logs the folder size in a human-readable format along with the total number of files in the folder. 

## ✨ Features

- **Folder Size**: Quickly get the total size of a folder, including all its subdirectories.
- **Custom Interval**: Define the time interval for repeated checks.
- **Human-Readable Format**: Display the folder size in an easily understandable format like KB, MB, GB, etc.
- **Error Handling**: In case of errors, such as permission issues, the program logs the error message to the console.

## 🚀 Usage

To execute the program, use the following format:

\```bash
FolderSizeChecker.exe <folderPath> [intervalInSeconds]
\```

### Command-line Arguments:

- `<folderPath>`: The path to the folder whose size you want to check. This is a mandatory argument.
- `[intervalInSeconds]`: (Optional) Time interval, in seconds, at which you want the program to repeatedly check the folder's size. Default is `5` seconds.

### 📝 Examples:

Check the size of the "C:\Documents" folder every 5 seconds:

\```bash
FolderSizeChecker.exe C:\Documents
\```

Check the size of the "C:\Documents" folder every 10 seconds:

\```bash
FolderSizeChecker.exe C:\Documents 10
\```

## 🔧 Troubleshooting

Ensure that the program has the necessary permissions to access the folder. If you encounter permission issues, consider running the program as an administrator or granting it the required permissions.

## 👨‍💻 Author

Daniel L. Van Den Bosch

## 📜 License

Ensure you adhere to licensing terms for any third-party libraries or tools used.

