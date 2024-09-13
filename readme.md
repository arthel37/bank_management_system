# Bank Management System

This is a simple, yet functional solution to managing bank database.

## About & features

App allows user to:

- Add, update and delete customers, accounts, transactions, loans and employees to/from the DB,
- Search through the accounts table by owners id
- Dynamically update account balance depending on type of transaction added to the DB,
- View live statistics on a dashbboard

## Technologies used

- C#
- .NET Windows Forms
- MS SQL local server
- MS SQL Server Management Studio

## Installation

1. Clone the repo.
   ```bash
   git clone https://github.com/arthel37/bank_management_system
   ```
2. Using SQL Server Management Studio restore BankDB.bak to your local database (requires local ms
   sql database):
   - Right-click on "Databases"
   - Choose "Restore Database..."
   - Pick "Device" in "Source",
   - Choose "File" as "Backup media type"
   - Click "Add" and then navigate to your cloned repo path
   - Enter "BankDB.bak" as "File name" or click the file
   - Press OK three times
3. Use the app ;)
