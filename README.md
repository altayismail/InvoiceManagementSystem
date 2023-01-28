# Invoice Management System
- You are a site administrator. You will manage the utility and common use electricity, water and natural gas bills of the apartments on your site through a system. You have two types of users.

1. Admin
- Can enter apartment information.
- Enter the resident user information.
- Inputs the dues and billing information to be paid per flat (Monthly). Assignments can be made collectively or individually.
- See incoming payment information.
- See incoming messages.
- See monthly debt-credit list.
- Lists, edits, deletes contacts.
- Lists, edits and deletes flat/housing information.
- Can get the excel output of the flat, invoice, dues and user information from the system.

2. User
- He sees the invoice and dues information assigned to him, and sees these invoices by filtering them according to any information.
- Can pay by credit card.
- Can send a message to the administrator.
- In the flat/residence information, In which block, Status (Full-empty), Type (2+1 etc.), Floor where it is located, Flat number, Flat owner or tenant,
- In user information; Name-surname, TC No, E-Mail, Telephone No, Vehicle information (plate number, if any).

3. Payment Service
- Apart from the interface, there is a separate service for users to pay by credit card. In this service, payment is made by checking the bank information (balance, credit card number, etc.) for each user in the system.

## Technologies
- ASP.NET 5 MVC -> ASP.NET 6 MVC (Target Framework Update)
- .NET 5 API -> .NET 6 API (Target Framework Update) - Used for Payments Service
- Database for both Invoice Management System and Paymen Service => Microsoft SQL Server
