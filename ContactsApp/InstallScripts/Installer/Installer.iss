#define   Name       "ContactsAppUserInterface"
#define   Version    "0.0.1"
#define   Publisher  "Dyagay Alexandra"
#define   URL        "https://github.com/fo-xi"
#define   ExeName    "ContactsAppUserInterface.exe"

[Setup]
AppId={{AB74535E-E8F1-439B-9D2C-92D9AEAED886}

AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}
AppPublisherURL={#URL}
AppSupportURL={#URL}
AppUpdatesURL={#URL}

DefaultDirName={pf}\{#Name}
DefaultGroupName={#Name}

OutputDir=..\Setup
OutputBaseFileName=Setup

SetupIconFile=..\Installer\contact-form.ico

Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl";
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl";

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "..\Release\ContactsAppUserInterface.exe"; DestDir: "{app}"; Flags: ignoreversion

Source: "..\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]

Name: "{group}\{#Name}"; Filename: "{app}\{#ExeName}"

Name: "{commondesktop}\{#Name}"; Filename: "{app}\{#ExeName}"; Tasks: desktopicon