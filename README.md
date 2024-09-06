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

![ss1](httpsgithub.comuser-attachmentsassetscb85c15e-35c5-4488-8950-fd51f8b09223)
![ss2](httpsgithub.comuser-attachmentsassets75bfdf73-4bd3-4338-997c-9316c14bcee5)
![ss3](httpsgithub.comuser-attachmentsassets3a4a8af1-7bda-4026-ac34-4785668d878a)
![ss4](httpsgithub.comuser-attachmentsassets6d6e544f-8dd4-463c-9e97-c3a601d95a8e)
![ss5](httpsgithub.comuser-attachmentsassetsbc2e3fee-8196-4661-aa53-0d62936b0aea)
![ss6](httpsgithub.comuser-attachmentsassets1c3547d8-7d6d-4632-965b-6d7b694b2dd3)
![ss7](httpsgithub.comuser-attachmentsassets55211a70-6fd0-4f4c-bd0d-dd8885e6d420)
![ss8](httpsgithub.comuser-attachmentsassets7cdf35d6-7b72-4001-9d17-9dc6b850251c)
![ss9](httpsgithub.comuser-attachmentsassetscb36b32d-3ea1-4a92-a30b-238cabdbf51f)
