using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Guid userId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9");
        string userName = "System Admin";
        string dateCreated = "DateCreatedUtc"; // Assuming you’ll replace with actual variable in EF seed

        var existingDesignations = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Accounting Expert"
        };

        string rawDesignations = @"
(Epabx) C.Ope
A C Coach Attendent
Aaya
Ac Tech
Accountant 
Accountant Cum Cashier
Accounting Specialist
Admin
Admin Executive
Admin Officer
Admin Receptionist
Advisor (Security)
Agriculture
Ambulance Driver
Area Manager 
Area Officer
Armed Guard
Assistant - Branch Manager
Assistant - Procurement  Site Manager
Assistant - Repair  Maintenance
Assistant Accountant
Assistant Driver
Assistant Engineer
Assistant Engineer (Civil)
Assistant Engineer (Electrical)
Assistant Engineer (Electronics  Comm)
Assistant Engineer (Electronics)
Assistant General Manager
Assistant Lineman
Assistant Manager (Accounts)
Assistant Manager - Business Development
Assistant Manager Accounts
Assistant Manager- Technical
Assistant Manager-Finance
Assistant Manager-Hr
Assistant Manager-Hr Admin
Assistant Manager-Marketing
Assistant Manager-Mis
Assistant Manager-Operation
Assistant Manager-Scm
Assistant Reception
Assistant Security Officer
Assistant Site Manager
Assistant-Finance
Assistant-Hr
Assistant-Hr Admin
Assistant-Marketing
Assistant-Operation
Assistant-Scm
Assitant Manager
Asst. Manager  Taxation 
Attendant
Audit Officer
Bed Bearer
Beldar
Beldar Helper
Bell Bay
Bio.Chem Division
Block Project Manager
Block Resource Person
Bouncer
Branch Head
Branch Manager
Brush Cutter Operator - Ssw
Brush Cutter Operator - Sw
Bss
Business Development Executive
Business Development Manager
Business Development Officer
C.Ope
C.R.Att
Cable Maint
Call Centre Operator
Canteen
Car Driver
Care Taker
Care Taker (Esm)
Care Taker Supervisor
Carpenter
Cashier
Caterpiller Driver
Center Head
Center Manager
Ceo
Ceo/Coo
Ceo/Coo-Operation
Chef
Chemical Sprayer And Handler
Chief Engineer Civil
Chief Technical Officer
Circle Head
Civil Engineer
Class Room Technician
Cleaning Staff
Clerk
Cloak Room
Cluster Engineer
Co-Ordinator
Co-Ordinator Hr
Co-Ordinator Omcr
Commi-I
Commi-Ii
Commi-Iii
Communications Executive
Computer Operator
Computer Operator - Sw
Computer Operator 1
Computer Operator 1 - A
Computer Operator 2
Computer Operator 2 - A
Computer Operator 3
Computer Operator Grade 1
Computer Personnel
Computer Programmer
Computer Teacher
Conductor
Conservancy
Consultant 
Content Writer
Cook
Cook Helper
Cook-Delhi
Creach
Cts+Hk
Cts-Housekeeper
Daftari
Dak Runner
Data  Analysts
Data Analytst
Data Entry Operator
Data Entry Operator 1
Data Entry Operator 2
Data Entry Operator 3 
Data Entry Operator 3 
Day Brc Female
Day Brc Male
Dcpo
Denter
Dentist
Dependent
Deputy General Manager
Deputy Genral Manager-Finance
Deputy Genral Manager-Hr
Deputy Genral Manager-Hr Admin
Deputy Genral Manager-Marketing
Deputy Genral Manager-Operation
Deputy Genral Manager-Scm
Deputy Manager- Technical
Dg Operatort
Diesel Generator Operator
Director
Director Office
District Coordinator
District Programme Manager
District Project Manager
Draft Man
Drawing Section
Driver
Driver (Doctor)
Driver (Hmv)
Driver (Lmv)
Driver - Sw
Driver(Cdm)
Dummy
Education
Electrician
Electrician
Electrician - Sw
Electrician Helper
Electrician-Mst
Electronic Supervisor
Engineer
English And Soft Skill Trainer
Eot Operator - Sw
Epbax Operator
Establishment
Estate Supervisor
Ex - Man
Ex- Gun Man
Executive
Executive - It
Executive - Legal
Executive Accountant
Executive Vice President
Executive(Tender Cell)
Executive-Finance
Executive-Hr
Executive-Hr Admin
Executive-Marketing
Executive-Operation
Executive-Scm
Facilities Management Associate (Ac)
Facilities Management Associate (Carpnt)
Facilities Management Associate (Electr)
Facilities Management Associate (Mesnry)
Facilities Management Associate (Plmbng)
Facilities Management Associate (Swimng)
Facilities Management Associate (Technc)
Facilities Management Associate (Telep)
Facilities Management Associate -Welding
Facilities Management Associate- Welding
Factory
Farmer
Fata Global Helipad
Fata Kreastal Helipad
Fata Thumby Helipad
Feedback
Female Warden
Field Assistant
Field Collector
Field Executive
Field Supervisor
Field Technician
Fire Man
Fire Technician
Fireman
Fireman B
Fitter - Sw
Flt Operator - Sw
Forklift Driver
Front Office Supervisor
Front Office Supervisor - F
Gang Man
Garden
Garden Supervisor
Gardner
Gardner Highly Skilled
Gardner Labour
Gardner Semi-Skilled
Gardner Skilled
Gardner Supervisor 
Gas Cutter
Gateman
Gen Usw
General Manager
General Physician
Genral Manager-Finance
Genral Manager-Hr
Genral Manager-Hr Admin
Genral Manager-Marketing
Genral Manager-Operation
Genral Manager-Scm
Glass Cleaner
Gm - Usw
Graphic Designer
Grievance Redressal Co-Ordinator
Ground Staff - I
Ground Staff - Ii
Ground Staff - Iii
Guard Arms
Guards Without Arms
Guest House
Guest House Manager-Cum-Senior Chef
Gun Man
Gun-Man
Gunman Ii
Guptkashi Helipad 1
Guptkashi Helipad 2
Gym Instructor
Gynecologist
H.R Officer
Head Cashier
Head Cook
Head Mali
Head Of Department
Head Of Department-Finance
Head Of Department-Hr
Head Of Department-Hr Admin
Head Of Department-Marketing
Head Of Department-Operation
Head Of Department-Scm
Head Peon
Health Attendant
Healthcare Supervisor
Helper
Helper - Ssw
Helper 2
Helper-Electrical
Highly Skilled
Horticulture
Horticulturist
Hostel
Hostel Boy
Hostel Boy Clerk
Hostel Boy Un-Skilled
Hostel Sec
House Keeping
House Keeping -  Mcc
House Keeping - Female
House Keeping - Night
House Keeping - Pfr
House Keeping - Pfr - Spl
House Keeping Sever
House Keeping Supervisor
Housekeeper
Housekeeping - Usw
Housekeeping - Usw (Spcl)
Housekeeping Ii
Housekeeping Manager
Housekeeping-Depot
Housekeeping-Intensive Coach
Housekeeping-Mcc-Day
Housekeeping-Mcc-Spl
Housekeeping-Station
Hr Executive
Hr Executive Admin
Hr Executive Payroll
Hr Head
Hvac Operator
Instructor (Gym)
Instructor (Racquet Games)
Instructor (Swimming)
Instrument
It Person
It Trainer
Janitor
Janitor-Fix
Junior Assistant
Junior Assistant  Typist 
Junior Assistant 1
Junior Engineer
Junior Manager- Technical
Kedarnath Helipad
Kitchen Stewarding Supervisor
L.D.C
Lab Assistant
Lab Assistant (Monthly)
Labour
Labour-Watering
Lady Care Taker
Lady Guard
Land Surveyor
Land Surveyor I
Laundry Boy
Laundry Supervisor
Legal Associate
Legal Co-Ordinator
Legal Consultant 
Library Assistant
Life Guard
Lift Operator
Lift Operator
Lineman
Linene Counting
Machine Operator
Machine Operator - Ssw
Machinist - Sw
Manager
Manager - Business Development
Manager - Sw
Manager Accounts
Manager Learning Centre
Manager- Hr (Recruitment)
Manager-Billing  Collection
Manager-Ccmr
Manager-Finance
Manager-Hr
Manager-Hr Admin
Manager-Marketing
Manager-Mis
Manager-Operation
Manager-Scm
Managing Director
Marketing  Consultant 
Marketing - Sr. Executive
Marketing Executive
Marketing Head
Masson
Mate
Mazdoor
Mcc  Depot
Md Medicine 
Md Paediatrics
Md Physician 
Md-Director
Md-Managing Director
Media Consultant
Media Executive
Medical Centre
Medical Consultant
Meson
Mis
Mis  It Trainer
Mis - Repair  Maintenance
Mis Sr
Mis-Scm
Moblizer
Moblizer Cum Placement Cordinator
Moblizer Cum Quailty Member
Monkey Handler
Mta
Mta-Spl
Mts
Mts 1
Multi Tasking Helper
Nayab Tehsildar
Nayab Tehsildar 1
Nayab Tehsildar 2
Night Brc Female
Night Brc Male
Night Female
Night Male
Night Supervisor
None
Nurse
Nursing Associate
Obhs- Ground Staff
Office Assistant
Office Assistant
Office Associate
Office Associate (Marketing)
Office Associate - Junior 
Office Boy
Office Boy - Usw
Office Boy Semi-Skilled
Office Executive
Office Helper
Office Housekeeper
Old House Keeping
Operation Head
Operation Manager
Operator
Operator - Ssw
Operator - Sw
Operator Garbage Collection - Sw
Org.Chem.Div
P. A.  Director
Pa
Painter
Pantry
Pantry Boy
Pat-Roller Supervisor
Pathology Technician
Peon
Peon 15020
Peon Cum Mate
Personal Security Officer
Personnel Officer
Pest Control
Pharmacist
Photographer Cum Technician
Pit Manager
Placement And Moblizer
Placement Coordinator
Planning Assistant
Planning-Assistance
Plantation Manager
Plumber
Plumber Helper
Point Incharge
Private Secretary
Program Assistant
Programmer
Project Assistant
Project Co-Ordinator
Project Head
Project Head Hsw
Project Manager
Project Scientist
Project Stop
Pso
Pump Operator
Purchase Section
Quaility And Placement Head
Rag Picker
Receptionist
Record Keeper
Recruitment Executive
Revenue Inspector
Riger
Roomboy
S  I
Sanitation
Security - Supervisor
Security Guard
Security Guard Cash
Security Guard Cum Sweeper
Security Guard Female
Security Guard Ii
Security Guard Iii
Security Guard Supervisor
Security Officer
Security Staff
Security Supervisor
Security Trainer
Security Trainer Special
Security-Cum-Driver
Security-Guard
Semi Skilled
Semi Skilled Worker
Senior Accountant
Senior Accountant 1
Senior Accountant 2
Senior Accounts Officer
Senior Assistant
Senior Assistant 1
Senior Assistant 2
Senior Carpenter
Senior Co-Ordinator
Senior Electrician
Senior Executive
Senior Executive - It
Senior Executive Accounts
Senior Executive Legal
Senior Executive Mis
Senior Executive- Billing  Collection
Senior Executive-Finance
Senior Executive-Hr
Senior Executive-Hr Admin
Senior Executive-Marketing
Senior Executive-Operation
Senior Executive-Scm
Senior Gardener
Senior Helper
Senior Manager
Senior Office Assistant
Senior Peon
Senior Plumber
Senior Project Manager
Senior Project Manager
Senior Supervisor
Senior Technical Assistant
Sershi Himalayan Helipad
Sershi Krestal Helipad
Sershi Triyuginarayan Helipad
Serveyar Ameen
Service Engineer
Service Manager - Repair  Maintenance
Sewer Man
Shift Supervisor
Site - Admin
Site Engineer
Site Engineer - Civil
Site Engineer - Electrical 
Site Engineer Ii
Site Engineer Iii
Site Engineer Iv
Site Incharge
Site Manager
Site Manager Ucada
Site Supervisor
Skilled
Skilled Worker
Skilled Worker - Ehk
Social Media Expert
Software Developer
Soit
Special Educator
Spl Usw
Sport'S Boy
Sr Office Associate
Sr. Executive- Operation
Sr. Executive-Taxation
Sr. Secretarial Assistant
Sr. Service Engineer
Ss-W
Ssw
State Bank Of Mysore
Stenographer
Stone Keeper
Store Incharge
Store Keeper
Stp Operator
Sugar Engineering
Superintendent
Supervisior - Operation
Supervisior Operation
Supervisior-Finance
Supervisior-Hr
Supervisior-Hr Admin
Supervisior-Marketing
Supervisior-Scm
Supervisor 
Supervisor - Cts
Supervisor - Ehk
Supervisor - Ehk (Fix)
Supervisor - Female
Supervisor - Hk
Supervisor - Hsw
Supervisor - Mcc
Supervisor - Pfr
Supervisor - Repair  Maintenance
Supervisor - Ssw
Supervisor - Sw
Supervisor - Trc
Supervisor - Watering
Supervisor Night
Supervisor- Head
Supervisor-Apdj
Supervisor-Linen
Supervisor-Ncb
Supervisor-Noq
Supervisor-Station
Supervisor-Station(Hk/Cts)
Supervisor-Watering
Sweeper
Sweeper - Buffing
Sweeper - Female
Sweeper Usw
Swimming Coach
Swimming Coach (Daily 710)
Swimming Coach (Daily)
Swimming Coach 1
Syce
T.Ope
Tailor Master
Tandoor Man
Team Leader
Technical
Technical Assistant
Technical Co-Ordinator
Technician
Technology Support Engineer
Tehsildar
Tele Caller
Telephone Technician 
Territory Assistant
Ticket Issuer
Trainee Care Taker
Trainee It
Trainee Lady Care Taker
Trainee Office Associate
Trainee Office Associate 1
Trainee Technician
Trainee-Business Development
Training Assistant
Training Assistant-Accounts
Training Assistant-Finance
Training Assistant-Hr
Training Assistant-Hr Admin
Training Assistant-Marketing
Training Assistant-Operation
Training Assistant-Scm
Unskilled
Unskilled - Chappra
Unskilled - Prayag Raj
Unskilled - Varanasi
Vendor Garbage
Video Studio Production Asst. Manage
Waiter
Ward Aya
Ward Boy
Warden
Warden - Admin Officer
Welder
Welder - Hsw
Worker
Worker - Cts
Worker - Ssw
Worker - Toilet  Cleaning
Worker - Usw
Worker - Usw (Fix)
Worker Special
Worker- Trc
Worker-Apdj
Worker-Ncb
Worker-Noq
Worker-Watering
Worker-Watering Spl 1
Worker-Watering Spl 2
X.Ray Attendante
Yoga Instructor
Young Horticulture
Zonal Head
Zonal Manager

"; // Add your full list here

        var lines = rawDesignations.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        int displayOrder = 2;

        foreach (var rawName in lines)
        {
            string name = rawName.Trim();

            if (string.IsNullOrWhiteSpace(name) || existingDesignations.Contains(name))
                continue;

            string guid = Guid.NewGuid().ToString().ToUpper();

            Console.WriteLine(
                $"new Designation {{ Id = Guid.Parse(\"{guid}\"), DisplayOrder = {displayOrder++}, Code = \"{name}\", Name = \"{name}\", " +
                $"DateCreated = {dateCreated}, DateModified = {dateCreated}, " +
                $"CreatedByUserId = userId, ModifiedByUserId = userId, " +
                $"CreatedByUserName = userName, ModifiedByUserName = userName }},");
        }
    }
}

