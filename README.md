# Matt's Password Manager

Matt's Password Manager (MPM) is a utility for storing passwords on Windows.

The application allows the user to view and store saved usernames and passwords.
The data is encrypted and saved into a repository file using the AES encryption algorithm.

### Requirements

`Microsoft Windows 7` or above.

`.NET Core 8.0` or above.

_For development:_

`.NET SDK 8.0` or above.

## User Instructions

### Installation and Execution

* Download the latest release.

* Extract the `zip` archive to a new directory.

* Run `MattsPasswordManager.exe`.

## Development Instructions

### Installation

* Clone the repository by running:

	``
	git clone https://github.com/CoderMattGH/matts-file-viewer.git
	``

### Building for Development

* Change to the directory `<repo_root_dir>/MattsPasswordManager`.

* Run the command:

	``
	dotnet build
	``

* This will build the executable and other project files which will be accessible from the 
`<repo_root_dir>/MattsPasswordManager/bin/Debug/net8.0-windows/` directory.

### Running the Development Build

* Change to the directory `<repo_root_dir>/MattsPasswordManager`.

* After building the project, run the command

	``
	dotnet build
	``

### Building for Production

* Change to the directory `<repo_root_dir>/MattsPasswordManager`.

* Run the command:

	``
	dotnet publish -c Release
	``

* This will build the executable and other project files which will be accessible from the 
`<repo_root_dir>/MattsPasswordManager/bin/Release/net8.0-windows/publish` directory.

### Testing

To be implemented.

