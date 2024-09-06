# Restaurant Management App

This is a Windows Forms-based Restaurant Management App developed using **VB.NET** and **SQL Server**. It features role-based access for Admins and Cashiers to manage restaurant operations like menus, orders, payments, and reports.

## Features

- **Admins**: Manage menu items, member info, orders, and generate reports.
- **Cashiers**: Handle payment processing.
  
## How to Install

### Prerequisites

- **SQL Server** installed on your system.
- **Visual Studio** (or similar IDE supporting VB.NET development).
  
### Step-by-Step Instructions

1. **Clone the Repository**:  
   Download or clone the repository from [GitHub](https://github.com/your-repo-link) to your local machine.

2. **Setup the Database**:  
   - Ensure SQL Server is installed on your computer.
   - Refer to the **database structure diagram** provided in the repository.
   - Using SQL Server Management Studio (SSMS) or a similar tool, create a new database with the exact structure shown in the diagram.
     - Make sure to match the **Primary Key**, **Foreign Key**, **Allow Null**, etc.
     - Set **MenuID**, **MemberID**, and **OrderDetailID** fields to auto-increment (Identity).
     - The database structure must be **100% identical**. Any discrepancies will require manual changes in the code.
    
3. **Database Structure**:
   ![alt text](https://i.ibb.co/sCB8rT8/database.png)

4. **Configure User Roles**:  
   The two roles provided are:
   - **Admin**
   - **Cashier**

   If you wish to change these roles, you will need to modify the code accordingly.

5. **Run the Application**:  
   Open the project in Visual Studio, ensure that the database connection string in the code matches your SQL Server setup, and run the app.

## Screenshots

![ss1](https://github.com/user-attachments/assets/e226a22f-ce4d-4a35-be65-df7e7345e409)
![ss2](https://github.com/user-attachments/assets/d800e535-5896-408f-9442-d587aff65393)
![ss3](https://github.com/user-attachments/assets/06e7bf0b-282f-4129-9f94-eef9b660ffdf)
![ss4](https://github.com/user-attachments/assets/b6b554eb-728d-4fd4-9abc-9423f8ec4d40)
![ss5](https://github.com/user-attachments/assets/9b11de17-2331-4cfd-8165-80f7520414bf)
![ss6](https://github.com/user-attachments/assets/428f6a6b-7028-40bd-94eb-1526a6cf5b9c)
![ss7](https://github.com/user-attachments/assets/71ecb245-f709-4b0d-aaad-b5a45219da66)
![ss8](https://github.com/user-attachments/assets/bbce24c5-43dc-4056-be1c-f0098093f5bb)
![ss9](https://github.com/user-attachments/assets/fa933d68-f7ce-4758-82b5-19cfe1450715)

